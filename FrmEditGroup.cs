using Amazon.IdentityManagement.Model;
using AWS;
using PostGreSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeploymentScheduler
{
    public partial class FrmEditGroup : Form
    {
        private bool _Initialize = true;
        private string? ErrorMessage;
        private const string DoubleQuote = "\"";
        private DataTable? dtVersion;
        private DataTable? dtGroup;
        private List<Entities.EntityGroup> _Groups = new();

        private const string SqlGroup = $"Select {DoubleQuote}idGroup{DoubleQuote}, name, {DoubleQuote}releaseName{DoubleQuote} " +
                                        $"From {DoubleQuote}t_deploymentGroups{DoubleQuote} " +
                                        "Order by name";

        private const string SqlVersion = $"Select {DoubleQuote}versionName{DoubleQuote} " +
                                                  $"From u_versions " +
                                                  $"Where deployed " +
                                                  $"Order by {DoubleQuote}releaseDate{DoubleQuote} desc";

        public FrmEditGroup(int GroupId = 0)
        {
            InitializeComponent();
            Init(GroupId);
        }


        private void Init(int GroupId)
        {
            dtGroup = Database.GetData(SqlGroup, out ErrorMessage);

            if (dtGroup == null || !string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des groupes");
                return;
            }

            cboGroup.DataSource = dtGroup;
            cboGroup.DisplayMember = "name";
            cboGroup.ValueMember = "idGroup";

            //dtVersion = Database.GetData(SqlVersion, out ErrorMessage);

            //if (dtVersion == null || !string.IsNullOrEmpty(ErrorMessage))
            //{
            //    MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des versions");
            //    return;
            //}

            Action<List<string>?> callback = new Action<List<string>?>(ProcessBucketDirectory);
            S3.GetBucketDirectory("progitek-site-prod-cpz776-files", "update/", callback);

            //cboVersion.DataSource = dtVersion;
            //cboVersion.DisplayMember = "versionName";
            //cboVersion.ValueMember = "versionName";

            _Initialize = false;

            if (GroupId > 0)
            {
                cboGroup.SelectedValue = GroupId;
            }
            else
            {
                cboGroup.SelectedIndex = -1;
            }
        }

        private void ProcessBucketDirectory(List<string>? BucketDirectory)
        {
            var Test = BucketDirectory;

            _Groups.Clear();

            if (BucketDirectory != null && BucketDirectory.Count > 0)
            {
                foreach (string DirName in BucketDirectory)
                {
                    Int64 ReleaseNoSort = -1;
                    Int64 Output = -1;

                    if (Int64.TryParse(DirName.Replace(".", ""), out Output))
                    {
                        ReleaseNoSort = Output;
                    }

                    _Groups.Add(new Entities.EntityGroup { ReleaseName = DirName, ReleaseNoSort = ReleaseNoSort });
                }

                if (_Groups.Count > 0)
                {
                    _Groups = _Groups.OrderByDescending(x => x.ReleaseNoSort).ToList();

                    cboVersion.DataSource = _Groups;
                    cboVersion.DisplayMember = "ReleaseName";
                    cboVersion.ValueMember = "ReleaseName";

                    SetGroupReleaseName();
                }
            }
        }

        private void SetGroupReleaseName()
        {
            if (!_Initialize && cboGroup.SelectedIndex >= 0)
            {
                string? GroupId = cboGroup.SelectedValue.ToString();
                string? Expression = $"idGroup = {GroupId}";

                DataRow[] drVersion = dtGroup.Select(Expression);

                if (drVersion.Count() > 0)
                {
                    cboVersion.SelectedValue = drVersion[0]["releaseName"].ToString();
                }
            }
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGroupReleaseName();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ErrorMessage;

            if (cboGroup.SelectedValue == null || cboVersion.SelectedValue == null)
            {
                MessageBox.Show("Vous devez choisir un groupe ainsi qu'une version.", "Erreur de validation");
                return;
            }

            string? GroupId = cboGroup.SelectedValue.ToString();
            string? VersionNo = cboVersion.SelectedValue.ToString();

            // Update the Schedule for a Clinic
            string SqlUpdate = $"Update {DoubleQuote}t_deploymentGroups{DoubleQuote} " +
                        $"Set  {DoubleQuote}releaseName{DoubleQuote} = '{VersionNo}' " +
                        $"Where {DoubleQuote}idGroup{DoubleQuote} = {GroupId}";

            int RowUpdated = Database.ExecuteUpdate(SqlUpdate, out ErrorMessage);

            if (RowUpdated == 1)
            {
                MessageBox.Show("Maj completée", "Succès");
            }
            else
            {
                MessageBox.Show($"Erreur Bd: {ErrorMessage}", "Erreur lors de la Maj");
            }

            this.Close();
        }

    }
}
