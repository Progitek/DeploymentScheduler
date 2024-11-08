using AWS;
using PostGreSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeploymentScheduler
{
    public partial class FrmEditScheduler : Form
    {
        bool _Initialize = true;
        string ErrorMessage = string.Empty;
        private int _IdScheduler;
        private const string DoubleQuote = "\"";

        private const string SqlDeployment = $"Select {DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}idGroup{DoubleQuote}, " +
                                    $"{DoubleQuote}t_deploymentGroups{DoubleQuote}.name, " +
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



        private const string SqlGroup = $"Select {DoubleQuote}idGroup{DoubleQuote}, name, {DoubleQuote}releaseName{DoubleQuote} " +
                                        $"From {DoubleQuote}t_deploymentGroups{DoubleQuote} " +
                                        "Order by name";

        private const string SqlVersion = $"Select {DoubleQuote}versionName{DoubleQuote} " +
                                          $"From u_versions " +
                                          $"Where deployed " +
                                          $"Order by {DoubleQuote}releaseDate{DoubleQuote} desc";

        private DataTable? dtGroup;
        private DataTable? dtVersion;
        private DataTable? dtSchedule;

        public FrmEditScheduler(int idScheduler)
        {
            InitializeComponent();
            this._IdScheduler = idScheduler;
            Init();
        }

        private void Init()
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

            dtVersion = Database.GetData(SqlVersion, out ErrorMessage);

            if (dtVersion == null || !string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des versions");
                return;
            }

            DataRow dr = dtVersion.NewRow();
            dr["versionName"] = "";
            dtVersion.Rows.InsertAt(dr, 0);

            cboVersionToInstall.DataSource = dtVersion;
            cboVersionToInstall.DisplayMember = "versionName";
            cboVersionToInstall.ValueMember = "versionName";

            for (int Hour = 0; Hour < 25; Hour++)
            {
                cboDeploymentTime.Items.Add($"{Hour.ToString().PadLeft(2, '0')}:00");
            }

            SetScheduleData();

            _Initialize = false;
        }

        private void SetScheduleData()
        {
            DeployementDate.MaxDate = DateTime.Now.AddYears(1);


            if (_IdScheduler > 0)
            {
                string SqlDeploymentById = $"Select {DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}idGroup{DoubleQuote}, " +
                                                     $"{DoubleQuote}t_deploymentGroups{DoubleQuote}.name, " +
                                                     $"t_clinics.{DoubleQuote}idClinic{DoubleQuote}, " +
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
                                                 $"Where {DoubleQuote}deploymentSchedule{DoubleQuote}.{DoubleQuote}idDeploymentSchedule{DoubleQuote} = {_IdScheduler} " +
                                                 $"Order by {DoubleQuote}deployStartDate{DoubleQuote} desc,  {DoubleQuote}deployStartTime{DoubleQuote} desc, {DoubleQuote}t_deploymentGroups{DoubleQuote}.name";

                dtSchedule = Database.GetData(SqlDeploymentById, out ErrorMessage);

                if (dtSchedule == null || !string.IsNullOrEmpty(ErrorMessage))
                {
                    MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la scédule de déploiement");
                    return;
                }

                DeployementDate.MinDate = DateTime.Parse(dtSchedule.Rows[0]["deployStartDate"].ToString());

                if (!string.IsNullOrEmpty(dtSchedule.Rows[0]["idGroup"].ToString()))
                {
                    cboGroup.SelectedValue = dtSchedule.Rows[0]["idGroup"].ToString();
                }
                else
                {
                    tbIdClinic.Text = dtSchedule.Rows[0]["idClinic"].ToString();
                    tbClinicName.Text = dtSchedule.Rows[0]["nameClinic"].ToString();
                }

                cboVersionToInstall.SelectedValue = dtSchedule.Rows[0]["VersionToInstall"].ToString();
                DeployementDate.Value = DateTime.Parse(dtSchedule.Rows[0]["deployStartDate"].ToString());
                cboDeploymentTime.Text = dtSchedule.Rows[0]["deployStartTime"].ToString().Replace(":00:00", ":00");
                cbxDeploymentCompleted.Checked = Boolean.Parse(dtSchedule.Rows[0]["deploymentCompleted"].ToString());
            }
            else
            {
                DeployementDate.MinDate = DateTime.Now;
                cboGroup.SelectedIndex = -1;
                cboDeploymentTime.SelectedIndex = -1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbIdClinic_TextChanged(object sender, EventArgs e)
        {
            string ErrorMessage = string.Empty;
            tbClinicName.Text = "";
            cboGroup.SelectedIndex = -1;
            lblVersionToInstall.Text = "Force to Version:";

            if (!String.IsNullOrEmpty(tbIdClinic.Text))
            {
                DataTable dtClinic = Database.GetData($"Select {DoubleQuote}nameClinic{DoubleQuote} From t_clinics Where {DoubleQuote}idClinic{DoubleQuote} = {tbIdClinic.Text}", out ErrorMessage);

                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des cliiques");
                    return;
                }

                if (dtClinic.Rows.Count > 0)
                {
                    tbClinicName.Text = dtClinic.Rows[0]["nameClinic"].ToString();
                }
                else
                {
                    tbClinicName.Text = string.Empty;
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ErrorMessage = string.Empty;
            string SqlUpdate = "";
            string Version = "null";
            string GroupId = "null";
            string ClinicId = "null";

            if (cboVersionToInstall.SelectedIndex <= 0 && (cboGroup.SelectedIndex >= 0))
            {
                MessageBox.Show("Le champ version est obligatoire", "Erreur");
                return;
            }

            if (cboGroup.SelectedIndex >= 0 && !String.IsNullOrEmpty(tbIdClinic.Text))
            {
                MessageBox.Show("On doit choisir un groupe ou entrer un Id de clinique, mais pas les deux", "Erreur");
                return;
            }

            if (cboGroup.SelectedIndex < 0 && String.IsNullOrEmpty(tbIdClinic.Text))
            {
                MessageBox.Show("On doit choisir un groupe ou entrer un Id de clinique", "Erreur");
                return;
            }

            if (String.IsNullOrEmpty(cboDeploymentTime.Text))
            {
                MessageBox.Show("Le champ heure de déploiement est obligatoire", "Erreur");
                return;
            }

            if (cboGroup.SelectedValue != null && !string.IsNullOrEmpty(cboGroup.SelectedValue.ToString()))
            {
                GroupId = $"{cboGroup.SelectedValue.ToString()}";
            }

            if (!string.IsNullOrEmpty(tbIdClinic.Text))
            {
                ClinicId = $"{tbIdClinic.Text}";
            }

            if (cboVersionToInstall.SelectedValue != null && !string.IsNullOrEmpty(cboVersionToInstall.SelectedValue.ToString()))
            {
                Version = $"'{cboVersionToInstall.SelectedValue}'";
            }

            if (_IdScheduler == -1) // Insert
            {
                // Insert a schedule to be deployment
                SqlUpdate = $"Insert Into {DoubleQuote}deploymentSchedule{DoubleQuote} ({DoubleQuote}idGroup{DoubleQuote}, {DoubleQuote}idClinic{DoubleQuote}, {DoubleQuote}releaseName{DoubleQuote}, {DoubleQuote}deployStartDate{DoubleQuote}, {DoubleQuote}deployStartTime{DoubleQuote}, {DoubleQuote}deploymentCompleted{DoubleQuote}) " +
                $"Values ({GroupId}, {ClinicId}, {Version}, '{DeployementDate.Value.ToString("yyyy-MM-dd")}', '{cboDeploymentTime.Text}', {cbxDeploymentCompleted.Checked})";
            }
            else // Update
            {
                // Update the Schedule for a Group 
                if (cboGroup.SelectedIndex >= 0 && String.IsNullOrEmpty(tbIdClinic.Text))
                {
                    SqlUpdate = $"Update {DoubleQuote}deploymentSchedule{DoubleQuote} " +
                                $"Set  {DoubleQuote}releaseName{DoubleQuote} = {Version}, " +
                                    $" {DoubleQuote}idClinic{DoubleQuote} = null, " +
                                    $" {DoubleQuote}idGroup{DoubleQuote} = {cboGroup.SelectedValue.ToString()}, " +
                                    $" {DoubleQuote}deployStartDate{DoubleQuote} = '{DeployementDate.Value.ToString("yyyy-MM-dd")}', " +
                                    $" {DoubleQuote}deployStartTime{DoubleQuote} = '{cboDeploymentTime.Text}', " +
                                    $" {DoubleQuote}deploymentCompleted{DoubleQuote} = {cbxDeploymentCompleted.Checked} " +
                                $"Where {DoubleQuote}idDeploymentSchedule{DoubleQuote} = {_IdScheduler}";

                }
                else if (cboGroup.SelectedIndex < 0 && !String.IsNullOrEmpty(tbIdClinic.Text))
                {
                    // Update the Schedule for a Clinic
                    SqlUpdate = $"Update {DoubleQuote}deploymentSchedule{DoubleQuote} " +
                                $"Set  {DoubleQuote}releaseName{DoubleQuote} = {Version}, " +
                                    $" {DoubleQuote}idClinic{DoubleQuote} = {tbIdClinic.Text}, " +
                                    $" {DoubleQuote}idGroup{DoubleQuote} = null, " +
                                    $" {DoubleQuote}deployStartDate{DoubleQuote} = '{DeployementDate.Value.ToString("yyyy-MM-dd")}', " +
                                    $" {DoubleQuote}deployStartTime{DoubleQuote} = '{cboDeploymentTime.Text}', " +
                                    $" {DoubleQuote}deploymentCompleted{DoubleQuote} = {cbxDeploymentCompleted.Checked} " +
                                $"Where {DoubleQuote}idDeploymentSchedule{DoubleQuote} = {_IdScheduler}";
                }
            }


            int RowUpdated = Database.ExecuteUpdate(SqlUpdate, out ErrorMessage);

            if (RowUpdated == 1)
            {
                MessageBox.Show("Maj completée", "Succes");
            }
            else
            {
                MessageBox.Show($"Erreur Bd: {ErrorMessage}", "Erreur lors de la Maj");
            }
        }

        private void cboVersionToInstall_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;

            if (!_Initialize && cboVersionToInstall.SelectedIndex >= 0 && !string.IsNullOrEmpty(cboVersionToInstall.SelectedValue.ToString()))
            {
                Action<List<string>?> callback = new Action<List<string>?>(CheckVersionDirectory);

                S3.GetBucketDirectory("progitek-site-prod-cpz776-files", $"update/{cboVersionToInstall.SelectedValue}/", callback);
            }
        }

        private void CheckVersionDirectory(List<string>? VersionDirectory)
        {
            if (VersionDirectory == null || VersionDirectory.Count == 0)
            {
                btnSave.Enabled = false;
                MessageBox.Show("Cette version n'a pas encore été déployée dans AWS S3", "Erreur");
            }
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_Initialize && cboGroup.SelectedIndex >= 0)
            {
                lblVersionToInstall.Text = "Version to install:";
            }
        }

    }
}
