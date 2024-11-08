//using static System.Runtime.InteropServices.JavaScript.JSType;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using AWS;
using PostGreSQL;
using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using static DeploymentScheduler.DentitekDeploymentSchedulerGui;

namespace DeploymentScheduler
{
    public partial class DentitekDeploymentSchedulerGui : Form
    {
        private bool _Initialization = true;
        private bool _SearchInProgress = false;
        private const string DoubleQuote = "\"";
        private string _ErrorMessage = string.Empty;
        private ImageList _Images = new ImageList();
        private DataTable? _DtClinicInfo = null;
        private string? _LogFilename;
        private System.Windows.Forms.Timer _Timer = new System.Windows.Forms.Timer();
        private List<string>? _GroupsIdSelectedList = null;

        public enum _ClinicRetrieveBy
        {
            Group,
            AllClinic,
            DentistName,
            DentalCorp,
            TelOrCel,
            ForceToVersion,
            ClinicName,
            ForVersion,
            Undefined
        }

        public enum _ClinicWhere
        {
            All,
            ByName,
            ByDentisName,
            ForceToVersion,
            ByVersionInstalled,
            ByTelOrCel,
            ByGroup,
            CustomWhere
        }

        public enum _ClinicColName
        {
            [Description("IdClinic")]
            IdClinic = 0,

            [Description("Environment")]
            Environment = 1,

            [Description("NameClinic")]
            NameClinic = 2,

            [Description("Status")]
            Status = 3,

            [Description("NameDentist")]
            NameDentist = 4,

            [Description("Name")]
            Name = 5,

            [Description("IdGroup")]
            IdGroup = 6,

            [Description("ForceToVersion")]
            ForceToVersion = 7,

            [Description("VersionToInstall")]
            VersionToInstall = 8,

            [Description("VersionInstalled")]
            VersionInstalled = 9,

            [Description("Web_uuid")]
            Web_uuid = 10,

            [Description("Spec1Phone")]
            Spec1Phone = 11,

            [Description("CellNumber")]
            CellNumber = 12,

            [Description("CanInstallFalcon")]
            CanInstallFalcon = 13,

            [Description("FalconChannel")]
            FalconChannel = 14
        }

        private const string SqlGroup = $"Select * " +
                                        $"From {DoubleQuote}t_deploymentGroups{DoubleQuote} " +
                                        $"Order by name";

        private const string _SqlClinicInfo = $"Select t_clinics.{DoubleQuote}idClinic{DoubleQuote}," +
                                             $"t_clinics.environment," +
                                             $"t_clinics.{DoubleQuote}nameClinic{DoubleQuote}," +
                                             $"Case When deleted in (0, 2) Then 'Active' Else 'Inactive' End as Status, " +
                                             $"t_clinics.dsn as nameDentist," +
                                             $"t_clinics.{DoubleQuote}versionToInstall{DoubleQuote} as VersionInstalled," +
                                             $"t_clinics.{DoubleQuote}idDeploymentGroup{DoubleQuote} as IdGroup," +
                                             $"t_clinics.{DoubleQuote}releaseName{DoubleQuote} as ForceToVersion," +
                                             $"t_clinics.web_uuid," +
                                             $"t_clinics.{DoubleQuote}spec1Phone{DoubleQuote}," +
                                             $"t_clinics.{DoubleQuote}cellNumber{DoubleQuote}," +
                                             $"t_clinics.{DoubleQuote}canInstallFalcon{DoubleQuote}," +
                                             $"t_clinics.{DoubleQuote}falconClientVersion{DoubleQuote}," +
                                             $"t_clinics.{DoubleQuote}falconChannel{DoubleQuote}," +
                                             $"{DoubleQuote}t_deploymentGroups{DoubleQuote}.name," +
                                             $"{DoubleQuote}t_deploymentGroups{DoubleQuote}.{DoubleQuote}releaseName{DoubleQuote} as VersionToInstall " +
                                         $"from t_clinics " +
                                            $"Full Outer Join {DoubleQuote}t_deploymentGroups{DoubleQuote} on {DoubleQuote}t_deploymentGroups{DoubleQuote}.{DoubleQuote}idGroup{DoubleQuote} = t_clinics.{DoubleQuote}idDeploymentGroup{DoubleQuote} ";


        private const string SqlClinic = $"Select t_clinics.{DoubleQuote}idClinic{DoubleQuote}," +
                                             $"t_clinics.environment," +
                                             $"t_clinics.{DoubleQuote}nameClinic{DoubleQuote}," +
                                             $"Case When deleted in (0, 2) Then 'Active' Else 'Inactive' End as Status, " +
                                             $"t_clinics.dsn as nameDentist," +
                                             $"t_clinics.{DoubleQuote}versionToInstall{DoubleQuote} as VersionInstalled," +
                                             $"t_clinics.{DoubleQuote}idDeploymentGroup{DoubleQuote} as IdGroup," +
                                             $"t_clinics.{DoubleQuote}releaseName{DoubleQuote} as ForceToVersion," +
                                             $"t_clinics.web_uuid," +
                                             $"t_clinics.{DoubleQuote}spec1Phone{DoubleQuote}," +
                                             $"t_clinics.{DoubleQuote}cellNumber{DoubleQuote}," +
                                             $"t_clinics.{DoubleQuote}canInstallFalcon{DoubleQuote}," +
                                             $"t_clinics.{DoubleQuote}falconClientVersion{DoubleQuote}," +
                                             $"t_clinics.{DoubleQuote}falconChannel{DoubleQuote}," +
                                             $"{DoubleQuote}t_deploymentGroups{DoubleQuote}.name," +
                                             $"{DoubleQuote}t_deploymentGroups{DoubleQuote}.{DoubleQuote}releaseName{DoubleQuote} as VersionToInstall " +
                                         $"from t_clinics " +
                                            $"Full Outer Join {DoubleQuote}t_deploymentGroups{DoubleQuote} on {DoubleQuote}t_deploymentGroups{DoubleQuote}.{DoubleQuote}idGroup{DoubleQuote} = t_clinics.{DoubleQuote}idDeploymentGroup{DoubleQuote} " +
                                         $"Where t_clinics.{DoubleQuote}idDeploymentGroup{DoubleQuote} is not null " +
                                         $"Order by {DoubleQuote}t_deploymentGroups{DoubleQuote}.name, t_clinics.{DoubleQuote}nameClinic{DoubleQuote}";



        private const string SqlDeployment = $"Select {DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}idGroup{DoubleQuote}, " +
                                    $"{DoubleQuote}t_deploymentGroups{DoubleQuote}.name, " +
                                    $"{DoubleQuote}t_deploymentGroups{DoubleQuote}.{DoubleQuote}releaseName{DoubleQuote} as VersionToInstallForGroup, " +
                                    $"t_clinics.{DoubleQuote}nameClinic{DoubleQuote}, " +
                                    $"t_clinics.{DoubleQuote}releaseName{DoubleQuote} as ForceToVersion, " +
                                    $"{DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}idClinic{DoubleQuote}, " +
                                    $"{DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}releaseName{DoubleQuote} as VersionToInstall, " +
                                    $"{DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}deployStartDate{DoubleQuote}, " +
                                    $"{DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}deployStartTime{DoubleQuote}, " +
                                    $"{DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}deploymentCompleted{DoubleQuote}, " +
                                    $"{DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}idDeploymentSchedule{DoubleQuote} " +
                                $"From {DoubleQuote}deploymentSchedule{DoubleQuote} " +
                                $"Left outer Join {DoubleQuote}t_deploymentGroups{DoubleQuote} on {DoubleQuote}t_deploymentGroups{DoubleQuote}.{DoubleQuote}idGroup{DoubleQuote} = {DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}idGroup{DoubleQuote} " +
                                $"Left outer Join t_clinics on t_clinics.{DoubleQuote}idClinic{DoubleQuote} = {DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}idClinic{DoubleQuote} " +
                                $"Order by {DoubleQuote}deployStartDate{DoubleQuote} desc,  {DoubleQuote}deployStartTime{DoubleQuote} desc, {DoubleQuote}t_deploymentGroups{DoubleQuote}.name";

        private const string SqlVersion = $"Select {DoubleQuote}versionName{DoubleQuote} " +
                                                 $"From u_versions " +
                                                 $"Where deployed " +
                                                 $"Order by {DoubleQuote}releaseDate{DoubleQuote} desc";

        public DentitekDeploymentSchedulerGui()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _LogFilename = Application.StartupPath + @"\SchedulerDeployment.log";

            _Images.Images.Add(Image.FromFile(@"..\Images\YellowLight.png"));
            _Images.Images.Add(Image.FromFile(@"..\Images\GreenLight.png"));
            _Images.Images.Add(Image.FromFile(@"..\Images\RedLight.png"));

            lvGroupAndClinic.View = View.Details;
            lvDeploymentSchedule.SmallImageList = _Images;

            pbConnectedAws.Image = _Images.Images[2];
            pbConnectedBD.Image = _Images.Images[2];

            S3.Connect(out _ErrorMessage);

            Application.DoEvents();

            if (!string.IsNullOrEmpty(_ErrorMessage))
            {
                pbConnectedAws.Image = _Images.Images[2];
                MessageBox.Show(_ErrorMessage, "Erreur de branchement a AWS S3");
                return;
            }

            _Initialization = false;


            using (StreamWriter w = File.AppendText("myFile.txt"))
            {
                w.WriteLine(DateTime.Now.ToString("yyyy-MM-dd H:mm") + " - SchedulerDeployment started");
            }

            //using (StreamWriter sw = File.CreateText(_LogFilename))
            //{
            //    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd H:mm") + " - SchedulerDeployment started");
            //}

            this.Text += $" - Version {Assembly.GetEntryAssembly().GetName().Version}";

            _Timer.Interval = 1800000; // 30 Min.
            _Timer.Tick += _Timer_Tick;
            _Timer.Start();
        }

        private void _Timer_Tick(object? sender, EventArgs e)
        {
            btnConnect_Click(btnConnect, new EventArgs());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ErrorMessage = string.Empty;

            TryConnectS3();

            Database.SetCredential();

            if (!Database.TestDatabaseConnection(out ErrorMessage))
            {
                TryConnectS3();
                btnEdit.Enabled = false;
                pbConnectedBD.Image = _Images.Images[2];
                MessageBox.Show($"Branchement a la DB Impossible: {ErrorMessage}", "Erreur de branchement a la DB");
            }
            else
            {
                pbConnectedBD.Image = _Images.Images[1];
                btnEdit.Enabled = true;

                _Initialization = true;

                // If we have Checked the Group Checkbox and we have no Group selected: Change the Filter selection to Version installed
                if (rbFilterByGroupeName.Checked && lvGroupAndClinic.SelectedItems.Count == 0)
                {
                    rbFilterByGroupeName.Checked = false;
                    rbVersion.Checked = true;
                    cboForVersion.Enabled = true;
                }

                RefreshClinicList();
                RefreshS3BucketNameList();
                RetrieveGroupInfo();

                _Initialization = false;
            }
        }

        private AmazonS3Client? TryConnectS3()
        {
            string AwsErrorMessage = "";
            AmazonS3Client? S3Client = null;

            try
            {
                S3Client = AWS.S3.Connect(out AwsErrorMessage);

                if (S3Client == null || !string.IsNullOrEmpty(AwsErrorMessage))
                {
                    pbConnectedAws.Image = _Images.Images[2];
                    MessageBox.Show("", "Erreur de branchement a AWS S3");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur de branchement a AWS S3");
            }

            pbConnectedAws.Image = _Images.Images[1];

            return S3Client;
        }

        public async void RefreshS3BucketNameList()
        {
            lvS3VersionBucket.Items.Clear();

            string AwsErrorMessage = "";

            AmazonS3Client? S3Client = AWS.S3.Connect(out AwsErrorMessage);

            if (S3Client == null || !string.IsNullOrEmpty(AwsErrorMessage))
            {
                MessageBox.Show("", "Erreur de branchement a AWS");
                return;
            }

            ListObjectsResponse response;

            ListObjectsRequest request = new ListObjectsRequest();
            // Root S3 Bucket
            request.BucketName = "progitek-site-prod-cpz776-files";
            // Specify sub-bucket we want to get content from
            request.Prefix = "update/";
            request.Delimiter = "/";
            request.MaxKeys = 100;

            //request.OptionalObjectAttributes.Add("ClientName");

            // Send request for bucket content
            response = await S3Client.ListObjectsAsync(request);

            var path = response.CommonPrefixes;

            // Get the bucket content
            var Objects = response.S3Objects;

            int ObjectCount = Objects.Count;
        }

        private void DentitekDeploymentScedulerGui_Shown(object sender, EventArgs e)
        {
            pbConnectedAws.Image = _Images.Images[1];

            // Asynchrone call to connect to Amazon and Get the Datbase Credential
            Action<DatabasePostGreSqlCredential?> callback = new Action<DatabasePostGreSqlCredential?>(CreateDB);
            AWS.S3.GetDatabaseCredentials(callback);



            //            RetrieveGroupInfo();

            //            _Db.TestDatabaseConnection(out _ErrorMessage);

            //if (!_Db.TestDatabaseConnection(out _ErrorMessage))
            //{
            //    btnEdit.Enabled = false;
            //    MessageBox.Show("Branchement a la DB Impossible: " + _ErrorMessage, "Erreur de branchement a la DB");
            //}
            //else
            //{
            //    pbConnectedBD.Image = _Images.Images[1];



            //}

            //            RetrieveGroupInfo();
            //            PopulateScheduler();

            _Initialization = false;
        }

        /// <summary>
        /// Create the Database Connection and Retrieve basic info.
        /// </summary>
        /// <param name="DbCredential"></param>
        private void CreateDB(DatabasePostGreSqlCredential? DbCredential)
        {
            Database.SetCredential(DbCredential);

            if (!Database.TestDatabaseConnection(out _ErrorMessage))
            {
                btnEdit.Enabled = false;
                MessageBox.Show("Branchement a la DB Impossible: " + _ErrorMessage, "Erreur de branchement a la DB");
                return;
            }
            else
            {
                pbConnectedBD.Image = _Images.Images[1];
                RetrieveGroupInfo();
            }
        }

        /// <summary>
        /// Retrieve the Clinics List based on user Input & Selection
        /// </summary>
        private void RefreshClinicList()
        {
            lvClinicInfo.Items.Clear();
            lvClinicInfo.Refresh();
            Application.DoEvents();

            // Sql Select for Clinics with the Where clause and Order by.
            string Sql = string.Empty;
            string ErrorMessage = string.Empty;

            RetriveClinicParams.ClinicRetrieveBy = _ClinicRetrieveBy.Undefined;
            RetriveClinicParams.ClinicSortColumnIndicator = _ClinicColName.NameClinic;
            RetriveClinicParams.SqlClinicOrderBy = $"Order by t_clinics.{DoubleQuote}nameClinic{DoubleQuote}";

            if (rbFilterByGroupeName.Checked)
            {
                RetriveClinicParams.ClinicRetrieveBy = _ClinicRetrieveBy.Group;
                RetriveClinicParams.ClinicSortColumnIndicator = _ClinicColName.Name;
                RetriveClinicParams.SqlClinicOrderBy = $"Order by {DoubleQuote}t_deploymentGroups{DoubleQuote}.{DoubleQuote}name{DoubleQuote}";
            }
            else if (rbFilterByAll.Checked)
            {
                RetriveClinicParams.ClinicRetrieveBy = _ClinicRetrieveBy.AllClinic;
            }
            else if (rbFIlterByDentalCorp.Checked)
            {
                RetriveClinicParams.ClinicRetrieveBy = _ClinicRetrieveBy.DentalCorp;
            }
            else if (rbFIlterByDentistName.Checked)
            {
                RetriveClinicParams.ClinicRetrieveBy = _ClinicRetrieveBy.DentistName;
                RetriveClinicParams.ClinicSortColumnIndicator = _ClinicColName.NameDentist;
                RetriveClinicParams.SqlClinicOrderBy = $"Order by dsn";
            }
            else if (rbFilterByCellOrPhone.Checked)
            {
                RetriveClinicParams.ClinicRetrieveBy = _ClinicRetrieveBy.TelOrCel;
                RetriveClinicParams.ClinicSortColumnIndicator = _ClinicColName.NameClinic;
            }
            else if (rbForceToVersion.Checked)
            {
                RetriveClinicParams.ClinicRetrieveBy = _ClinicRetrieveBy.ForceToVersion;
                RetriveClinicParams.ClinicSortColumnIndicator = _ClinicColName.ForceToVersion;
                RetriveClinicParams.SqlClinicOrderBy = $"Order by t_clinics.{DoubleQuote}releaseName{DoubleQuote}";
            }
            else if (rbClinicName.Checked)
            {
                RetriveClinicParams.ClinicRetrieveBy = _ClinicRetrieveBy.ClinicName;
            }
            else if (rbVersion.Checked)
            {
                RetriveClinicParams.ClinicRetrieveBy = _ClinicRetrieveBy.ForVersion;
                RetriveClinicParams.ClinicSortColumnIndicator = _ClinicColName.NameClinic;
            }

            if (RetriveClinicParams.ClinicRetrieveBy != _ClinicRetrieveBy.Undefined)
            {
                RetriveClinicParams.SqlClinicWhere = GetSqlWhereForClinic(RetriveClinicParams.ClinicRetrieveBy, out ErrorMessage);

                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    MessageBox.Show(ErrorMessage, "Erreur");
                    _Initialization = false;
                    return;
                }

                Sql = _SqlClinicInfo + RetriveClinicParams.SqlClinicWhere + RetriveClinicParams.SqlClinicOrderBy;

                _DtClinicInfo = Database.GetData(Sql, out ErrorMessage);

                if (_DtClinicInfo == null || !string.IsNullOrEmpty(ErrorMessage))
                {
                    MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des cliniques");
                    _Initialization = false;
                    return;
                }

                PopulateLvClinic(_DtClinicInfo);
                ResetHeaderSortIndicator();
                SetHeaderSortIndicator(RetriveClinicParams.ClinicSortColumnIndicator, "asc");
            }
        }

        private string GetSqlWhereForClinic(_ClinicRetrieveBy ClinicRetrieveBy, out string ErrorMessage)
        {
            string SqlWhere = string.Empty;

            ErrorMessage = string.Empty;

            switch (ClinicRetrieveBy)
            {
                case _ClinicRetrieveBy.AllClinic:
                    break;

                case _ClinicRetrieveBy.DentalCorp:
                    SqlWhere = $"Where {DoubleQuote}idClinic{DoubleQuote} In (Select {DoubleQuote}idClinic{DoubleQuote} From dc_clinics)";
                    break;

                case _ClinicRetrieveBy.ClinicName:
                    SqlWhere = $"Where {DoubleQuote}nameClinic{DoubleQuote} " + (string.IsNullOrEmpty(tbFilterByName.Text) ? $"is null or {DoubleQuote}nameClinic{DoubleQuote} = '' " : $"ilike '%{tbFilterByName.Text}%' ");
                    break;

                case _ClinicRetrieveBy.ForceToVersion:
                    SqlWhere = $"Where t_clinics.{DoubleQuote}releaseName{DoubleQuote} is not null ";
                    break;

                case _ClinicRetrieveBy.TelOrCel:
                    SqlWhere = $"Where {DoubleQuote}spec1Phone{DoubleQuote} like '%{tbTelOrCel.Text}%' Or {DoubleQuote}cellNumber{DoubleQuote} like '%{tbTelOrCel.Text}%' ";
                    break;

                case _ClinicRetrieveBy.DentistName:
                    SqlWhere = $"Where dsn ilike '%{tbDentistName.Text}%' ";
                    break;

                case _ClinicRetrieveBy.ForVersion:
                    string VersionNo = GetVersionNo();

                    if (!string.IsNullOrEmpty(VersionNo))
                    {
                        int PosLastDot = VersionNo.LastIndexOf('.');

                        if (PosLastDot > 0)
                        {
                            VersionNo = VersionNo.Substring(0, PosLastDot) + ".0";
                            SqlWhere = $"Where t_clinics.{DoubleQuote}versionToInstall{DoubleQuote} = '{VersionNo}' ";
                        }
                    }
                    break;

                case _ClinicRetrieveBy.Group:

                    _GroupsIdSelectedList = GetGroupSlected();

                    string SqlGroupsArray = BuildSqlGroupArray(_GroupsIdSelectedList);

                    if (!string.IsNullOrEmpty(SqlGroupsArray))
                    {
                        SqlWhere = $"Where {DoubleQuote}idDeploymentGroup{DoubleQuote} in ({SqlGroupsArray.ToString()}) ";
                    }
                    else
                    {
                        ErrorMessage = "Vous devez selectionner un/plusieurs groupe.";
                    }
                    break;
            }

            if (rbActive.Checked)
            {
                if (string.IsNullOrEmpty(SqlWhere))
                {
                    SqlWhere = $"Where deleted <> 1 ";
                }
                else
                {
                    SqlWhere += $" and deleted <> 1";
                }
            }
            else if (!rbAll.Checked)
            {
                string Env = "";

                if (rbProd.Checked)
                {
                    Env = "prod";
                }
                else if (rbTest.Checked)
                {
                    Env = "test";
                }
                else if (rbDev.Checked)
                {
                    Env = "dev";
                }
                else if (rbInactive.Checked)
                {
                    Env = "inactive";
                }

                if (string.IsNullOrEmpty(SqlWhere))
                {
                    SqlWhere = $"Where environment = '{Env}'";
                }
                else
                {
                    SqlWhere += $" and environment = '{Env}'";
                }
            }

            return SqlWhere;
        }

        private string BuildSqlGroupArray(List<string> Groups)
        {
            string SqlGroupsArray = "";

            if (Groups.Count > 0)
            {
                SqlGroupsArray = $"{Groups[0]}";

                if (Groups.Count > 1)
                {
                    for (int ptr = 1; ptr < Groups.Count; ptr++)
                    {
                        SqlGroupsArray += $",{Groups[ptr]}";
                    }
                }
            }

            return SqlGroupsArray;
        }

        private List<string> GetGroupSlected()
        {
            ListView.SelectedListViewItemCollection GroupSelected = lvGroupAndClinic.SelectedItems;
            List<string> Groups = new List<string>();

            if (GroupSelected.Count > 0)
            {
                foreach (ListViewItem group in GroupSelected)
                {
                    Groups.Add(group.Text);
                }
            }

            return Groups;
        }

        private void RetrieveGroupInfo()
        {
            string ErrorMessage = string.Empty;
            DataTable? dt;
            ListViewItem lvi;

            /*****************************************************************
             *   Retrieve and Display info about the Groups for deployment   *
             *****************************************************************/
            DataTable? dtVersion = Database.GetData(SqlVersion, out ErrorMessage);

            cboForVersion.DataSource = null;

            if (dtVersion == null || !string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Erreur de lecture la liste des versions");
                return;
            }

            cboForVersion.DataSource = dtVersion;
            cboForVersion.DisplayMember = "versionName";
            cboForVersion.ValueMember = "versionName";

            PopulateGroup();
            PopulateScheduler();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvClinicInfo.SelectedItems.Count > 0)
            {
                int idClinic = int.Parse(lvClinicInfo.SelectedItems[0].Text);

                if (idClinic > 0)
                {
                    FrmEditClinic EditClinic = new FrmEditClinic(idClinic);
                    EditClinic.ShowDialog(this);
                }
            }

        }

        private void rbFilterByAll_Click(object sender, EventArgs e)
        {
            DisableControls();
            RefreshClinicList();
        }

        private void rbFIlterByDentistName_Click(object sender, EventArgs e)
        {
            DisableControls();
            tbDentistName.Enabled = true;

            RefreshClinicList();

            //string ErrorMessage = string.Empty;
            //string Where = $"Where dsn ilike '%{tbDentistName.Text}%' ";

            //string SqlAllClinic = BuildClinicSql(_ClinicWhere.ByDentisName, Where);

            //_DtClinicInfo = _Db.GetData(SqlAllClinic, out ErrorMessage);

            //if (_DtClinicInfo == null || !string.IsNullOrEmpty(ErrorMessage))
            //{
            //    MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des cliniques");
            //    return;
            //}

            //PopulateLvClinic(_DtClinicInfo);
        }

        private void tbFilterByName_TextChanged(object sender, EventArgs e)
        {
            if (!_SearchInProgress)
            {
                _SearchInProgress = true;
                RefreshClinicList();
                _SearchInProgress = false;

                //FilterClinicByName(tbFilterByName.Text);
            }
        }

        //private void DisplayAllClinicByName()
        //{
        //    /******************************************************************
        //    *   Retrieve and Display info about the Clinics for deployment   *
        //    ******************************************************************/
        //    string ErrorMessage = string.Empty;
        //    string SqlClinicLikeName = BuildClinicSql(_ClinicWhere.All);

        //    _DtClinicInfo = _Db.GetData(SqlClinicLikeName, out ErrorMessage);

        //    if (_DtClinicInfo == null || !string.IsNullOrEmpty(ErrorMessage))
        //    {
        //        MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des cliniques");
        //        return;
        //    }

        //    PopulateLvClinic(_DtClinicInfo);
        //}

        //private void FilterClinicByName(string ClinicName)
        //{
        //    _DtClinicInfo = null;

        //    _SearchInProgress = true;

        //    /******************************************************************
        //    *   Retrieve and Display info about the Clinics for deployment   *
        //    ******************************************************************/

        //    string ErrorMessage = string.Empty;
        //    string Where = $"Where {DoubleQuote}nameClinic{DoubleQuote} " + (string.IsNullOrEmpty(ClinicName) ? $"is null or {DoubleQuote}nameClinic{DoubleQuote} = '' " : $"ilike '%{ClinicName}%' ");
        //    string SqlClinicLikeName = BuildClinicSql(_ClinicWhere.ByName, Where);

        //    _DtClinicInfo = _Db.GetData(SqlClinicLikeName, out ErrorMessage);

        //    if (_DtClinicInfo == null || !string.IsNullOrEmpty(ErrorMessage))
        //    {
        //        MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des cliniques");
        //        return;
        //    }

        //    PopulateLvClinic(_DtClinicInfo);

        //    _SearchInProgress = false;
        //}

        //private void FilterByTelOrCel()
        //{
        //    if (!_SearchInProgress)
        //    {
        //        _SearchInProgress = true;

        //        DisableControls();

        //        string ErrorMessage = string.Empty;
        //        string Where = $"Where {DoubleQuote}spec1Phone{DoubleQuote} like '%{tbTelOrCel.Text}%' Or {DoubleQuote}cellNumber{DoubleQuote} like '%{tbTelOrCel.Text}%'";
        //        string SqlAllClinic = BuildClinicSql(_ClinicWhere.ByTelOrCel, Where);

        //        _DtClinicInfo = _Db.GetData(SqlAllClinic, out ErrorMessage);

        //        if (_DtClinicInfo == null || !string.IsNullOrEmpty(ErrorMessage))
        //        {
        //            MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des cliniques");
        //            return;
        //        }

        //        PopulateLvClinic(_DtClinicInfo);

        //        _SearchInProgress = false;
        //    }
        //}

        private void PopulateLvClinic(DataTable dt)
        {
            ListViewItem lvi;

            lvClinicInfo.SuspendLayout();

            lvClinicInfo.Items.Clear();

            lblClinicCount.Text = "";

            if (dt != null)
            {
                string? VersionToInstall;
                string? VersionInstalled;
                int PtrLastDot;

                foreach (DataRow dr in dt.Rows)
                {
                    VersionToInstall = dr["VersionToInstall"] == null ? "" : dr["VersionToInstall"].ToString();
                    VersionInstalled = dr["VersionInstalled"] == null ? "" : dr["VersionInstalled"].ToString();

                    PtrLastDot = VersionToInstall.LastIndexOf('.');

                    if (PtrLastDot >= 0)
                    {
                        VersionToInstall = VersionToInstall.Substring(0, PtrLastDot);
                    }

                    PtrLastDot = VersionInstalled.LastIndexOf('.');

                    if (PtrLastDot >= 0)
                    {
                        VersionInstalled = VersionInstalled.Substring(0, PtrLastDot);
                    }

                    lvi = new ListViewItem(dr["idClinic"].ToString());
                    lvi.UseItemStyleForSubItems = false;

                    lvi.SubItems.Add(dr["environment"].ToString());
                    lvi.SubItems.Add(dr["nameClinic"].ToString());
                    lvi.SubItems.Add(dr["Status"].ToString());
                    lvi.SubItems.Add(dr["nameDentist"].ToString());
                    lvi.SubItems.Add(dr["name"].ToString());
                    lvi.SubItems.Add(dr["IdGroup"].ToString());
                    lvi.SubItems.Add(dr["ForceToVersion"].ToString());
                    lvi.SubItems.Add(dr["VersionToInstall"].ToString());

                    lvi.SubItems.Add(dr["VersionInstalled"].ToString());

                    //lvi.SubItems[1].BackColor = Color.Green;

                    //lvi.SubItems[7].BackColor = VersionToInstall == VersionInstalled ? Color.Green : Color.Red;
                    lvi.SubItems[8].BackColor = VersionToInstall == VersionInstalled ? Color.Green : Color.Red;

                    lvi.SubItems.Add(dr["web_uuid"].ToString());
                    lvi.SubItems.Add(dr["Spec1Phone"].ToString());
                    lvi.SubItems.Add(dr["cellNumber"].ToString());
                    lvi.SubItems.Add(dr["canInstallFalcon"].ToString());
                    lvi.SubItems.Add(dr["falconChannel"].ToString());

                    lvClinicInfo.Items.Add(lvi);
                }

                lblClinicCount.Text = $"{dt.Rows.Count} cliniques";
            }

            lvClinicInfo.ResumeLayout();
        }

        private void PopulateGroup()
        {
            string ErrorMessage = string.Empty;
            DataTable? dt;
            ListViewItem lvi;

            lvGroupAndClinic.Items.Clear();

            dt = Database.GetData(SqlGroup, out ErrorMessage);

            if (!_Initialization && (dt == null || !string.IsNullOrEmpty(ErrorMessage)))
            {
                MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des Groupes");
                return;
            }

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lvi = new ListViewItem(dr["idGroup"].ToString());
                    lvi.SubItems.Add(dr["name"].ToString());
                    lvi.SubItems.Add(dr["releaseName"].ToString());

                    // If any Group was selected before the Refresh, Reselect the groups.
                    if (_GroupsIdSelectedList != null && _GroupsIdSelectedList.Count(x => x == dr["idGroup"].ToString()) > 0)
                    {
                        lvi.Selected = true;
                        //lvi.BackColor = Color.Blue;
                    }

                    lvGroupAndClinic.Items.Add(lvi);
                }

                if (rbFilterByGroupeName.Checked)
                {
                    lvGroupAndClinic.Focus();
                }
            }
        }

        private void PopulateScheduler()
        {
            string ErrorMessage = string.Empty;
            DataTable? dt;
            ListViewItem lvi;

            dt = Database.GetData(SqlDeployment, out ErrorMessage);

            if (dt == null || !string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des cédule de déploiement");
                return;
            }

            lvDeploymentSchedule.SuspendLayout();
            lvDeploymentSchedule.Items.Clear();
            lvDeploymentSchedule.Text = $"{dt.Rows.Count} cliniques";

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime StartDate = DateTime.Parse(dr["deployStartDate"].ToString());

                    lvi = new ListViewItem("");
                    lvi.SubItems.Add(StartDate.ToString("yyyy-MM-dd"));

                    var StartTime = dr["deploystarttime"].ToString();

                    if (!string.IsNullOrEmpty(StartTime))
                    {
                        lvi.SubItems.Add(DateTime.Parse(StartTime).ToString("H:mm"));
                    }
                    else
                    {
                        lvi.SubItems.Add("");
                    }

                    lvi.SubItems.Add(dr["name"].ToString());
                    lvi.SubItems.Add(dr["nameClinic"].ToString());
                    lvi.SubItems.Add(dr["ForceToVersion"].ToString());
                    lvi.SubItems.Add(dr["VersionToInstall"].ToString());
                    lvi.SubItems.Add(dr["idDeploymentSchedule"].ToString());

                    bool DeploymentDone = Boolean.Parse(dr["deploymentCompleted"].ToString());

                    if (DeploymentDone)
                    {
                        var group = dr["idGroup"];

                        if (dr["idGroup"] != null && !string.IsNullOrEmpty(dr["idGroup"].ToString()))
                        {
                            if (dr["VersionToInstall"].ToString() == dr["VersionToInstallForGroup"].ToString())
                            {
                                lvi.ImageIndex = 1; // Green
                            }
                            else
                            {
                                lvi.ImageIndex = 2; // Red
                            }
                        }
                        else // Id Clinic
                        {
                            if (dr["VersionToInstall"].ToString() == dr["ForceToVersion"].ToString())
                            {
                                lvi.ImageIndex = 1; // Green
                            }
                            else
                            {
                                lvi.ImageIndex = 2; // Red
                            }
                        }
                    }
                    else
                    {
                        lvi.ImageIndex = 0; // Yellow
                    }

                    lvDeploymentSchedule.Items.Add(lvi);
                }
            }

            lvDeploymentSchedule.ResumeLayout();
        }

        private void DentitekDeploymentSchedulerGui_Resize(object sender, EventArgs e)
        {
            lvClinicInfo.Height = this.Height - lvClinicInfo.Top - btnEdit.Height - 50;
            lvClinicInfo.Width = this.Width - 40;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvDeploymentSchedule.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvDeploymentSchedule.SelectedItems[0];

                int idScheduler = int.Parse(lvi.SubItems[7].Text);

                if (idScheduler > 0)
                {
                    FrmEditScheduler FrmEdit = new FrmEditScheduler(idScheduler);
                    if (FrmEdit.ShowDialog(this) == DialogResult.OK)
                    {
                        PopulateScheduler();
                    }
                }
            }
        }

        private void rbFilterByGroupeName_Click(object sender, EventArgs e)
        {
            DisableControls();

            ListView.SelectedListViewItemCollection GroupSelected = lvGroupAndClinic.SelectedItems;

            if (GroupSelected.Count > 0)
            {
                RefreshClinicList();
                lvGroupAndClinic.Focus();
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un/plusieurs groupe.", "Information");
            }
        }

        private void rbForceToVersion_Click(object sender, EventArgs e)
        {
            DisableControls();
            RefreshClinicList();
        }

        private void rbClinicName_Click(object sender, EventArgs e)
        {
            DisableControls();
            tbFilterByName.Enabled = true;
            RefreshClinicList();
        }

        private void rbVersion_Click(object sender, EventArgs e)
        {
            DisableControls();
            cboForVersion.Enabled = true;
            RefreshClinicList();
        }

        private void cboForVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_Initialization)
            {
                RefreshClinicList();
            }
        }

        private void DisableControls()
        {
            tbFilterByName.Enabled = false;
            tbDentistName.Enabled = false;
            tbTelOrCel.Enabled = false;
            cboForVersion.Enabled = false;
        }

        private string GetVersionNo()
        {
            string VersionNo = "";

            if (cboForVersion.SelectedIndex >= 0)
            {
                VersionNo = cboForVersion.Text;
            }

            return VersionNo;
        }

        // Method to get SSO credentials from the information in the shared config file.
        static AWSCredentials LoadSsoCredentials(string profile)
        {
            var chain = new CredentialProfileStoreChain();
            if (!chain.TryGetAWSCredentials(profile, out var credentials))
            {
                throw new Exception($"Failed to find the {profile} profile");
            }

            return credentials;
        }

        //private delegate void DelegateGetBucketDirectory(List<string>?);

        private void ProcessBucketDirectory(List<string>? BucketDirectory)
        {
            var Test = BucketDirectory;

            lvS3VersionBucket.Items.Clear();

            if (BucketDirectory != null && BucketDirectory.Count > 0)
            {
                foreach (string DirName in BucketDirectory)
                {
                    lvS3VersionBucket.Items.Add(DirName);
                }
            }

        }

        private void btnS3VersionList_Click(object sender, EventArgs e)
        {
            Action<List<string>?> callback = new Action<List<string>?>(ProcessBucketDirectory);
            S3.GetBucketDirectory("progitek-site-prod-cpz776-files", "update/", callback);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Action<List<string>?> callback = new Action<List<string>?>(ProcessBucketDirectory);

            S3.GetBucketDirectory("progitek-site-prod-cpz776-files", "update/", callback);

            return;

            string AwsErrorMessage = "";

            AmazonS3Client? S3Client = AWS.S3.Connect(out AwsErrorMessage);

            if (S3Client == null || !string.IsNullOrEmpty(AwsErrorMessage))
            {
                MessageBox.Show("", "Erreur de branchement a AWS");
                return;
            }
        }

        private void lvGroupAndClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            //rbFilterByGroupeName.Checked = true;
            //rbFilterByGroupeName_Click(lvGroupAndClinic, new EventArgs());
        }

        private void lvGroupAndClinic_Click(object sender, EventArgs e)
        {
            DisableControls();
            rbFilterByGroupeName.Checked = true;
            RefreshClinicList();
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            FrmEditScheduler FrmEdit = new FrmEditScheduler(-1);
            FrmEdit.ShowDialog(this);

        }

        /// <summary>
        /// Sort the Clinic info by the Column header that the user has clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvClinicInfo_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _ClinicColName ColNameForSortEnum = (_ClinicColName)e.Column;
            SortClinicInfo(ColNameForSortEnum);
        }

        private void SortClinicInfo(_ClinicColName ColNameForSortEnum)
        {
            string SortOrder = "asc";

            ResetHeaderSortIndicator();

            if (_DtClinicInfo != null && _DtClinicInfo.Rows.Count > 1)
            {
                var ColNameForSort = ColNameForSortEnum.ToDescriptionString();

                string CurrentSortOrder = lvClinicInfo.Columns[(int)ColNameForSortEnum].Tag as string;

                if (CurrentSortOrder != null && CurrentSortOrder == "asc")
                {
                    SortOrder = "desc";
                }

                _DtClinicInfo.DefaultView.Sort = $"{ColNameForSort} {SortOrder}";
                _DtClinicInfo = _DtClinicInfo.DefaultView.ToTable();

                PopulateLvClinic(_DtClinicInfo);
                SetHeaderSortIndicator(ColNameForSortEnum, SortOrder);
            }
        }

        private void ResetHeaderSortIndicator()
        {
            foreach (ColumnHeader Col in lvClinicInfo.Columns)
            {
                Col.Text = Col.Text.Replace(" ▲", "").Replace(" ▼", "");
            }
        }

        private void SetHeaderSortIndicator(_ClinicColName ColNameForSortEnum, string SortOrder)
        {
            int ColumnNo = (int)ColNameForSortEnum;

            lvClinicInfo.Columns[ColumnNo].Text += (SortOrder == "asc" ? " ▲" : " ▼");
            lvClinicInfo.Columns[ColumnNo].Tag = SortOrder;
        }

        private string BuildClinicSql(_ClinicWhere ClinicWhere, string SqlWhere = "")
        {
            string SqlClinic = _SqlClinicInfo;

            switch (ClinicWhere)
            {
                case _ClinicWhere.All:
                    break;
                case _ClinicWhere.ByName:
                    SqlClinic += SqlWhere;
                    break;
                case _ClinicWhere.ByDentisName:
                    SqlClinic += SqlWhere;
                    break;
                case _ClinicWhere.ForceToVersion:
                    SqlClinic += $"Where t_clinics.{DoubleQuote}releaseName{DoubleQuote} is not null ";
                    break;
                case _ClinicWhere.ByVersionInstalled:
                    SqlClinic += SqlWhere;
                    break;
                case _ClinicWhere.ByTelOrCel:
                    SqlClinic += SqlWhere;
                    break;
                case _ClinicWhere.ByGroup:
                    SqlClinic += SqlWhere;
                    break;

                case _ClinicWhere.CustomWhere:
                    SqlClinic += SqlWhere;
                    break;
            }

            SqlClinic += $"Order by t_clinics.{DoubleQuote}nameClinic{DoubleQuote}";

            return SqlClinic;
        }

        private void tbDentistName_TextChanged(object sender, EventArgs e)
        {
            if (!_SearchInProgress)
            {
                _SearchInProgress = true;
                RefreshClinicList();
                _SearchInProgress = false;
            }
        }

        private void rbFilterByCellOrPhone_Click(object sender, EventArgs e)
        {
            DisableControls();
            tbTelOrCel.Enabled = true;
            RefreshClinicList();

            //            FilterByTelOrCel();
        }

        private void tbTelOrCel_TextChanged(object sender, EventArgs e)
        {
            if (!_SearchInProgress)
            {
                _SearchInProgress = true;
                RefreshClinicList();
                _SearchInProgress = false;
            }

            //FilterByTelOrCel();
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            int GroupId = 0;
            ListView.SelectedListViewItemCollection GroupSelected = lvGroupAndClinic.SelectedItems;


            if (GroupSelected.Count > 0)
            {
                ListViewItem Lvi = GroupSelected[0] as ListViewItem;

                if (Lvi != null)
                {
                    GroupId = int.Parse(Lvi.Text);
                }
            }

            FrmEditGroup EditGoup = new FrmEditGroup(GroupId);
            EditGoup.ShowDialog(this);

            PopulateGroup();
        }

        public static class RetriveClinicParams
        {
            public static string? Sql { get; set; }
            public static _ClinicRetrieveBy ClinicRetrieveBy { get; set; }
            public static string? SqlClinicWhere { get; set; }
            public static string? SqlClinicOrderBy { get; set; }
            public static _ClinicColName ClinicSortColumnIndicator { get; set; }
        }

        private void rbProd_Click(object sender, EventArgs e)
        {
            RefreshClinicList();
        }

        private void rbTest_Click(object sender, EventArgs e)
        {
            RefreshClinicList();
        }

        private void rbDev_Click(object sender, EventArgs e)
        {
            RefreshClinicList();
        }

        private void rbAll_Click(object sender, EventArgs e)
        {
            RefreshClinicList();
        }

        private void rbInactive_CheckedChanged(object sender, EventArgs e)
        {
            RefreshClinicList();
        }

        private void btnGeneerateSchedule_Click(object sender, EventArgs e)
        {
            FrmGenerateSchedule frmGenerateSchedule = new FrmGenerateSchedule();
            if (frmGenerateSchedule.ShowDialog() == DialogResult.OK)
            {
                PopulateScheduler();
            }
        }

        private void rbFIlterByDentalCorp_Click(object sender, EventArgs e)
        {
            DisableControls();
            RefreshClinicList();
        }

        private void MenuItemClinic_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem? MenuItemClinic = sender as ToolStripMenuItem;

            if (lvClinicInfo.SelectedItems.Count > 0)
            {
                int idClinic = int.Parse(lvClinicInfo.SelectedItems[0].Text);
                string ClinicName = lvClinicInfo.SelectedItems[0].SubItems[2].Text;

                if (idClinic > 0)
                {
                    if (MenuItemClinic != null)
                    {
                        String? Sql = null;
                        FrmDisplayInfoInGrid Frm;

                        switch (MenuItemClinic.Name)
                        {
                            case "MenuItemClinicEdit":
                                FrmEditClinic EditClinic = new FrmEditClinic(idClinic);
                                EditClinic.ShowDialog(this);
                                break;

                            case "MenuItemFalconSynchroProgress":
                                Sql = "Select * " +
                                          "From u_glogs " +
                                          $"Where {DoubleQuote}idClinic{DoubleQuote} = {idClinic} " +
                                          $"Order by {DoubleQuote}dateCreated{DoubleQuote} Desc";

                                Frm = new(Sql, $"Falcon Synchronization for Clinic '{ClinicName}' ({idClinic})");
                                Frm.ShowDialog(this);
                                break;

                            case "MenuItemFalconSettings":
                                Sql = "Select Case When deleted in (0, 2) Then 'Active' Else 'Inactive' End as Status, " +
                                        $"{DoubleQuote}canInstallFalcon{DoubleQuote} as {DoubleQuote}Can Installed{DoubleQuote}, " +
                                        $"{DoubleQuote}falconClientDownloadUrl{DoubleQuote} as URL, " +
                                        $"{DoubleQuote}falconClientVersion{DoubleQuote} as {DoubleQuote}Client Version{DoubleQuote}, " +
                                        $"{DoubleQuote}falconChannel{DoubleQuote} as Channel, " +
                                        $"{DoubleQuote}falconServerName{DoubleQuote} as {DoubleQuote}Server Name{DoubleQuote}, " +
                                        $"{DoubleQuote}falconServerPort{DoubleQuote} as Port, " +
                                        $"{DoubleQuote}falconServerToken{DoubleQuote} as Token, " +
                                        $"{DoubleQuote}falconFullSyncYears{DoubleQuote} as {DoubleQuote}Sync Year{DoubleQuote}" +
                                      $"From t_clinics " +
                                      $"Where {DoubleQuote}idClinic{DoubleQuote} = {idClinic}";

                                Frm = new(Sql, $"Falcon Synchronization for Clinic '{ClinicName}' ({idClinic})");
                                Frm.ShowDialog(this);
                                break;


                            case "MenuItemServicesLog":
                                Sql = "Select * " +
                                          "From u_glogs " +
                                          $"Where {DoubleQuote}idClinic{DoubleQuote} = {idClinic} " +
                                          $"Order by {DoubleQuote}dateCreated{DoubleQuote} Desc";

                                Frm = new(Sql, $"Logs for Clinic '{ClinicName}' ({idClinic})");
                                Frm.ShowDialog(this);
                                break;

                            case "MenuItemAgentsList":
                                Sql = $"Select {DoubleQuote}t_relToolAgents{DoubleQuote}.{DoubleQuote}idTool{DoubleQuote}, " +
                                         $"u_agents.{DoubleQuote}isServerDate{DoubleQuote}, " +
                                         $"u_agents.{DoubleQuote}osVersion{DoubleQuote}, " +
                                         $"u_agents.* " +
                                         $"From t_clinics " +
                                         $"Join {DoubleQuote}u_relAgentClinics{DoubleQuote} ON {DoubleQuote}u_relAgentClinics{DoubleQuote}.{DoubleQuote}idClinic{DoubleQuote} = t_clinics.{DoubleQuote}idClinic{DoubleQuote} " +
                                         $"Join u_agents ON u_agents.{DoubleQuote}idAgent{DoubleQuote} = {DoubleQuote}u_relAgentClinics{DoubleQuote}.{DoubleQuote}idAgent{DoubleQuote} " +
                                         $"Left outer join {DoubleQuote}t_relToolAgents{DoubleQuote} on {DoubleQuote}t_relToolAgents{DoubleQuote}.{DoubleQuote}idAgent{DoubleQuote} = {DoubleQuote}u_relAgentClinics{DoubleQuote}.{DoubleQuote}idAgent{DoubleQuote} " +
                                         $"Where t_clinics.{DoubleQuote}idClinic{DoubleQuote} = {idClinic}  " +
                                         $"  and u_agents.{DoubleQuote}isServerDate{DoubleQuote} is Not null " +
                                         $"Order By {DoubleQuote}u_relAgentClinics{DoubleQuote}.{DoubleQuote}lastTelemetry{DoubleQuote} Desc";

                                Frm = new(Sql, $"Agent list for Clinic '{ClinicName}' ({idClinic})");
                                Frm.ShowDialog(this);
                                break;

                        }
                    }
                }
            }
        }

        private void lvClinicInfo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lvClinicInfo.ContextMenuStrip = MenuContextualClinic;
                lvClinicInfo.ContextMenuStrip.Show(System.Windows.Forms.Control.MousePosition);
                lvClinicInfo.ContextMenuStrip = null;
            }
        }

        private void rbActive_Click(object sender, EventArgs e)
        {
            RefreshClinicList();
        }
    }

    public static class MyEnumExtensions
        {
            public static string ToDescriptionString(this DentitekDeploymentSchedulerGui._ClinicColName val)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                   .GetType()
                   .GetField(val.ToString())
                   .GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : string.Empty;
            }
        }

    }
