using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PostGreSQL;

namespace DeploymentScheduler
{
    public partial class FrmEditClinic : Form
    {
        private int _ClinicId;
        private const string DoubleQuote = "\"";

        public FrmEditClinic(int ClinicId)
        {
            InitializeComponent();

            _ClinicId = ClinicId;

            Init();
        }

        private void Init()
        {
            DataTable? dtGroup = new DataTable();
            DataTable? dtClinic = new DataTable();
            DataTable? dtVersion = new DataTable();
            DataRow dr;

            string ErrorMessage = string.Empty;

            string SqlGroup = $"Select {DoubleQuote}idGroup{DoubleQuote}, name, {DoubleQuote}releaseName{DoubleQuote} " +
                              $"From {DoubleQuote}t_deploymentGroups{DoubleQuote} " +
                              "Order by name";

            string SqlVersion = $"Select {DoubleQuote}versionName{DoubleQuote} " +
                              $"From u_versions " +
                              $"Where deployed " +
                              $"Order by {DoubleQuote}releaseDate{DoubleQuote} desc";


            //string SqlVersion = $"Select Distinct {DoubleQuote}releaseName{DoubleQuote} " +
            //                  $"From {DoubleQuote}t_deploymentGroups{DoubleQuote} " +
            //                  $"Order by {DoubleQuote}releaseName{DoubleQuote} desc";


            string SqlClinic = $"Select t_clinics.{DoubleQuote}idClinic{DoubleQuote}," +
                                $"t_clinics.environment," +
                                $"t_clinics.dsn," +
                                $"t_clinics.{DoubleQuote}nameClinic{DoubleQuote}," +
                                $"t_clinics.{DoubleQuote}versionToInstall{DoubleQuote} as VersionInstalled," +
                                $"t_clinics.{DoubleQuote}idDeploymentGroup{DoubleQuote} as IdGroup," +
                                $"t_clinics.{DoubleQuote}releaseName{DoubleQuote} as ForceToVersion," +
                                $"t_clinics.web_uuid," +
                                $"t_clinics.phone," +
                                $"t_clinics.{DoubleQuote}cellNumber{DoubleQuote}," +
                                $"t_clinics.{DoubleQuote}canInstallFalcon{DoubleQuote}," +
                                $"t_clinics.{DoubleQuote}falconClientVersion{DoubleQuote}," +
                                $"t_clinics.{DoubleQuote}falconChannel{DoubleQuote}," +
                                $"{DoubleQuote}t_deploymentGroups{DoubleQuote}.name," +
                                $"{DoubleQuote}t_deploymentGroups{DoubleQuote}.{DoubleQuote}releaseName{DoubleQuote} as VersionToInstall " +
                            $"from t_clinics " +
                            $"Full Outer Join {DoubleQuote}t_deploymentGroups{DoubleQuote} on {DoubleQuote}t_deploymentGroups{DoubleQuote}.{DoubleQuote}idGroup{DoubleQuote} = t_clinics.{DoubleQuote}idDeploymentGroup{DoubleQuote} " +
                            $"Where   t_clinics.{DoubleQuote}idClinic{DoubleQuote} = {_ClinicId}" +
                            $"Order by {DoubleQuote}t_deploymentGroups{DoubleQuote}.name, t_clinics.{DoubleQuote}nameClinic{DoubleQuote}";

            dtGroup = Database.GetData(SqlGroup, out ErrorMessage);

            if (dtGroup == null || !string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des groupes");
                return;
            }

            cboGroup.DataSource = dtGroup;
            cboGroup.DisplayMember = "name";
            cboGroup.ValueMember = "idGroup";

            dtClinic = Database.GetData(SqlClinic, out ErrorMessage);

            if (dtClinic == null || !string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des cliniques");
                return;
            }

            dtVersion = Database.GetData(SqlVersion, out ErrorMessage);

            if (dtVersion == null || !string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des versions");
                return;
            }

            string expression = $"versionName = '{dtClinic.Rows[0]["ForceToVersion"].ToString()}'";
            DataRow[] foundRows;

            // Use the Select method to find all rows matching the filter.
            foundRows = dtVersion.Select(expression);

            //if (foundRows.Count() == 0)
            //{
            //    dr = dtVersion.NewRow();
            //    //dr["idGroup"] = "-1";
            //    dr["versionName"] = dtClinic.Rows[0]["ForceToVersion"].ToString();
            //    dtVersion.Rows.InsertAt(dr, 0);
            //}

            dr = dtVersion.NewRow();
            dr["versionName"] = "";
            dtVersion.Rows.InsertAt(dr, 0);

            cboVersionToInstalled.DataSource = dtGroup;
            cboVersionToInstalled.DisplayMember = "releaseName";
            cboVersionToInstalled.ValueMember = "idGroup";

            cboForceToVersion.DataSource = dtVersion;
            cboForceToVersion.DisplayMember = "versionName";
            cboForceToVersion.ValueMember = "versionName";

            if (dtClinic.Rows.Count > 0)
            {
                tbIdClinic.Text = dtClinic.Rows[0]["idClinic"].ToString();
                tbClinicName.Text = dtClinic.Rows[0]["nameClinic"].ToString();
                cboEnv.Text = dtClinic.Rows[0]["environment"].ToString();

                if (!string.IsNullOrEmpty(dtClinic.Rows[0]["IdGroup"].ToString()))
                {
                    cboGroup.SelectedValue = dtClinic.Rows[0]["IdGroup"].ToString();
                }
                else
                {
                    cboGroup.SelectedIndex = -1;
                }

                tbInstalledVersion.Text = dtClinic.Rows[0]["VersionInstalled"].ToString();

                if (!string.IsNullOrEmpty(dtClinic.Rows[0]["IdGroup"].ToString()))
                {
                    cboVersionToInstalled.SelectedValue = dtClinic.Rows[0]["IdGroup"].ToString();
                }
                else
                {
                    cboVersionToInstalled.SelectedIndex = -1;
                }

                if (!string.IsNullOrEmpty(dtClinic.Rows[0]["ForceToVersion"].ToString()))
                {
                    cboForceToVersion.SelectedValue = dtClinic.Rows[0]["ForceToVersion"].ToString();
                }

                tbFalconVersion.Text = dtClinic.Rows[0]["falconClientVersion"].ToString();
                tbUuid.Text = dtClinic.Rows[0]["web_uuid"].ToString();


                if (string.IsNullOrEmpty(cboVersionToInstalled.SelectedText))
                {
                    tbUrl.Text = $"https://install.dentitek.ca/files/{dtClinic.Rows[0]["web_uuid"].ToString()}/Dentitek/index.html";
                }
            }
        }

        private void pbCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbUrl.Text);
        }

        private void bpOpenUrl_Click(object sender, EventArgs e)
        {
            Process.Start($@"C:\Program Files\Google\Chrome\Application\chrome.exe", tbUrl.Text);
            //Process.Start("Chrome.exe", $"{tbUrl.Text}");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idGroup = "null";
            string ErrorMessage = string.Empty;
            string ForceToVersion = "null";
            string Sql = "";

            if (cboGroup.SelectedValue != null)
            {
                idGroup = cboGroup.SelectedValue.ToString();
            }

            if (!string.IsNullOrEmpty(cboForceToVersion.Text))
            {
                ForceToVersion = $"'{cboForceToVersion.Text}'";
            }

            Sql = $"Update t_clinics " +
                $"Set {DoubleQuote}idDeploymentGroup{DoubleQuote} = {idGroup}, " +
                $"environment = '{cboEnv.Text}', " +
                $"{DoubleQuote}releaseName{DoubleQuote} = {ForceToVersion} " +
                $"Where  t_clinics.{DoubleQuote}idClinic{DoubleQuote} = {tbIdClinic.Text}";

            var RowUpdated = Database.ExecuteUpdate(Sql, out ErrorMessage);

            if (RowUpdated == 1)
            {
                MessageBox.Show("Maj completée", "Succes");
            }
            else
            {
                MessageBox.Show($"Erreur Bd: {ErrorMessage}", "Erreur lors de la Maj");
            }
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbGroupId.Text = "";

            if (cboGroup.SelectedIndex >= 0)
            {
                tbGroupId.Text = cboGroup.SelectedValue.ToString();
            }
        }
    }
}
