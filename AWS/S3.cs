using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Internal;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;

using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.IO;

namespace AWS
{
    /// <summary>
    /// Class to connect and obtain information about S3 Buckets and Directories
    /// </summary>
    public static class S3
    {
        private static AmazonS3Client? _S3Client;
        private static AWSCredentials _SsoCreds;
        private static DatabasePostGreSqlCredential? _DatabasePostGreSqlCredential = null;
        private static string _LogFilename = "SchedulerDeployment.log";

        static S3()
        {
        }

        /// <summary>
        /// Connect to Amazon AWS and return an error message if not successfull
        /// </summary>
        /// <returns>AmazonS3Client : The Client pointer to AWS to access Amazon</returns>
        public static AmazonS3Client? Connect (out string ErrorMessage)
        {
            _S3Client = null;

            ErrorMessage = "";

            try
            {
                // Use SSO login info from Aws Config file (%USERPROFILE%\.aws\)
                _SsoCreds = LoadSsoCredentials("prod");

                ((SSOAWSCredentials)_SsoCreds).Options.ClientName = "Dentitek";

                ((SSOAWSCredentials)_SsoCreds).Options.SsoVerificationCallback = new Action<SsoVerificationArguments>(delegate (SsoVerificationArguments ssoArgs)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = ssoArgs.VerificationUriComplete,
                        UseShellExecute = true
                    });
                });

                // Connect to S3 using Aws Config file Credentials

                var Config = new AmazonS3Config();

                _S3Client = new AmazonS3Client(_SsoCreds, Config);

                Action<DatabasePostGreSqlCredential?> callback = new Action<DatabasePostGreSqlCredential?>(SetDentitekOnlineProdCredential);
                GetDatabaseCredentials(callback);

                TestConnect();

                //var Bucket = await test();

                //                var BucketList = _S3Client.ListBucketsAsync();

                // var Test = _S3Client.ListObjectsV2Async(new ListObjectsV2Request());

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return _S3Client;
        }

        /// <summary>
        /// Get the PostGreSQL Dentitek-Online prod database credential (to be use to build the Connection string)
        /// </summary>
        public static async void GetDatabaseCredentials (Action<DatabasePostGreSqlCredential?> callback)
        {
            string SecretName = "database/dentitek-online-prod-database/secret";
            string Secret;
            var Config = new AmazonSecretsManagerConfig();

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(_SsoCreds, Config);

            var response = await GetSecretAsync(client, SecretName);

            if (response is not null)
            {
                Secret = DecodeString(response);
                _DatabasePostGreSqlCredential = Newtonsoft.Json.JsonConvert.DeserializeObject<DatabasePostGreSqlCredential>(Secret);
                if (callback != null) callback(_DatabasePostGreSqlCredential);
            }
        }

        public static DatabasePostGreSqlCredential? GetDentitekOnlineProdCredential()
        {
            return _DatabasePostGreSqlCredential;
        }

        public static void SetDentitekOnlineProdCredential (DatabasePostGreSqlCredential? DbCredential)
        {
            _DatabasePostGreSqlCredential = DbCredential;
        }

        /// <summary>
        /// Retrieves the secret value given the name of the secret to
        /// retrieve.
        /// </summary>
        /// <param name="client">The client object used to retrieve the secret
        /// value for the given secret name.</param>
        /// <param name="secretName">The name of the secret value to retrieve.</param>
        /// <returns>The GetSecretValueReponse object returned by
        /// GetSecretValueAsync.</returns>
        private static async Task<GetSecretValueResponse> GetSecretAsync(IAmazonSecretsManager client, string secretName)
        {
            GetSecretValueRequest request = new GetSecretValueRequest()
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
            };

            GetSecretValueResponse response = null;

            // For the sake of simplicity, this example handles only the most
            // general SecretsManager exception.
            try
            {
                response = await client.GetSecretValueAsync(request);
            }
//            catch (AmazonSecretsManagerException e)
            catch (Exception Ex)
            {
                //using (StreamWriter sw = File.CreateText(@"C:\" + _LogFilename))

                using (StreamWriter sw = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + _LogFilename))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd H:mm") + " - Error: " + Ex.Message);
                }
            }

            return response;
        }

        /// <summary>
        /// Decodes the secret returned by the call to GetSecretValueAsync and
        /// returns it to the calling program.
        /// </summary>
        /// <param name="response">A GetSecretValueResponse object containing
        /// the requested secret value returned by GetSecretValueAsync.</param>
        /// <returns>A string representing the decoded secret value.</returns>
        public static string DecodeString (GetSecretValueResponse response)
        {
            // Decrypts secret using the associated AWS Key Management Service
            // Customer Master Key (CMK.) Depending on whether the secret is a
            // string or binary value, one of these fields will be populated.
            if (response.SecretString is not null)
            {
                var secret = response.SecretString;
                return secret;
            }
            else if (response.SecretBinary is not null)
            {
                var memoryStream = response.SecretBinary;
                StreamReader reader = new StreamReader(memoryStream);
                string decodedBinarySecret = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(reader.ReadToEnd()));
                return decodedBinarySecret;
            }
            else
            {
                return string.Empty;
            }
        }

        public static async void TestConnect()
        {
             var Bucket = await GetBucketName();

            int BucketCount = Bucket.Buckets.Count;

            if (BucketCount <= 0)
            {
                throw new Exception("Erreur lors du branchement a AWS S3");
            }
        }

        /// <summary>
        /// Get the list of Bucket name
        /// </summary>
        /// <returns></returns>
        private static async Task<ListBucketsResponse> GetBucketName()
        {
            return await _S3Client.ListBucketsAsync();
        }


        private static AWSCredentials LoadSsoCredentials(string profile)
        {
            var chain = new CredentialProfileStoreChain();
            if (!chain.TryGetAWSCredentials(profile, out var credentials))
            {
                throw new Exception($"Failed to find the {profile} profile");
            }

            return credentials;
        }

        /// <summary>
        /// Get the list of Sub-Directory under a Specific Buket and Folder name.
        /// </summary>
        /// <param name="BucketName"></param>
        /// <param name="FolderName"></param>
        /// <param name="callback"></param>
        public async static void GetBucketDirectory (string BucketName, string FolderName, Action<List<string>?> callback)
        {
            List<string>? BucketDirectores = null;
            List<string>? DirectoyList = null;

            string ErrorMessage = string.Empty;

            _S3Client = Connect(out ErrorMessage);

            if (_S3Client == null || !string.IsNullOrEmpty(ErrorMessage))
            {
                if (callback != null) callback(null);
                return;
            }

            ListObjectsResponse? response = null;

            ListObjectsRequest request = new ListObjectsRequest();
            // Root S3 Bucket
            request.BucketName = BucketName; //  "progitek-site-prod-cpz776-files";
            // Specify sub-bucket we want to get content from
            request.Prefix = FolderName; //  "update/";
            request.MaxKeys = 500; // Max number of folder list return
            request.Delimiter = "/"; // If specified, will return only the 1st level of sub-Directories (in response.CommonPrefixes)

            try
            {
                // Send request for bucket content
                response = await _S3Client.ListObjectsAsync(request);

                // Get list of all directories under Prefix (FolderName)
                DirectoyList = response.CommonPrefixes;

                if (DirectoyList != null && DirectoyList.Count > 0)
                {
                    BucketDirectores = new List<string>();

                    foreach (string DirName in DirectoyList)
                    {
                        BucketDirectores.Add(DirName.Replace(FolderName, "").Replace("/", ""));
                    }

                    BucketDirectores = BucketDirectores.OrderBy(x => x).ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "";
            }

            // Return result
            if (callback != null) callback(BucketDirectores);
        }

        /// <summary>
        /// Get the list of Folders/Files name that exist in a Bucket/Folder name
        /// </summary>
        /// <param name="BucketName"></param>
        /// <param name="FolderName"></param>
        /// <param name="callback"></param>
        public async static void GetDirectoryFile (string BucketName, string FolderName, Action<List<string>?> callback)
        {
            List<string>? BucketDirectores = null;
            List<S3Object>? S3ObjectList = null;

            string ErrorMessage = string.Empty;

            _S3Client = Connect(out ErrorMessage);

            if (_S3Client == null || !string.IsNullOrEmpty(ErrorMessage))
            {
                //return null; //  if (callback != null) callback(null);
            }

            ListObjectsResponse? response = null;

            ListObjectsRequest request = new ListObjectsRequest();
            // Root S3 Bucket
            request.BucketName = BucketName; //  "progitek-site-prod-cpz776-files";
            // Specify sub-bucket we want to get content from
            request.Prefix = FolderName; //  "update/";
            request.MaxKeys = 3000; // Max number of folder list return
            //request.Delimiter = "/"; // If specified, will return only the 1st level of sub-Directories (in response.CommonPrefixes)

            try
            {
                // Send request for bucket content
                response = await _S3Client.ListObjectsAsync(request);

                // Get list of all directories under Prefix (FolderName)
                S3ObjectList = response.S3Objects;

                if (S3ObjectList != null && S3ObjectList.Count > 0)
                {
                    BucketDirectores = new List<string>();

                    foreach (S3Object DirName in S3ObjectList)
                    {
                        BucketDirectores.Add(DirName.Key.Replace(FolderName, ""));
                    }

                    BucketDirectores = BucketDirectores.OrderBy(x => x).ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "";
            }

            // Return result
            if (callback != null) callback(BucketDirectores);
        }

    }
}
