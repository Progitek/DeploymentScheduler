using AWS;
using Microsoft.VisualBasic;
using PostGreSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeploymentScheduler
{
    public partial class FrmGenerateSchedule : Form
    {
        private const string DoubleQuote = "\"";
        private DataTable? _dtGroup;
        private DataTable? dtVersion;

        private const string SqlVersion = $"Select {DoubleQuote}versionName{DoubleQuote} " +
                                          $"From u_versions " +
                                          $"Where deployed " +
                                          $"Order by {DoubleQuote}releaseDate{DoubleQuote} desc";

        public FrmGenerateSchedule()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            string Sql = $"Select {DoubleQuote}idGroup{DoubleQuote}, name From {DoubleQuote}t_deploymentGroups{DoubleQuote}";
            string ErrorMessage = "";
            _dtGroup = Database.GetData(Sql, out ErrorMessage);


            dtVersion = Database.GetData(SqlVersion, out ErrorMessage);

            if (dtVersion == null || !string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Erreur de lecture Bd pour la liste des versions");
                return;
            }

            Action<List<string>?> callback = new Action<List<string>?>(ProcessBucketDirectory);
            S3.GetBucketDirectory("progitek-site-prod-cpz776-files", "update/", callback);


            //cboVersionToInstall.DataSource = dtVersion;
            //cboVersionToInstall.DisplayMember = "versionName";
            //cboVersionToInstall.ValueMember = "versionName";
            //cboVersionToInstall.SelectedIndex = -1;

            GenerateSchedule();
            DeployementStartDate_ValueChanged(DeployementStartDate, new EventArgs());
        }

        private void GenerateSchedule()
        {
            lvSchedule.Items.Clear();

            TimeSpan StartTime = new TimeSpan(20, 00, 0);
            DateTime StartDate = DeployementStartDate.Value.Date.Add(StartTime);

            AddToSchedule("G01", StartDate, false);

            switch (NumNbrOfDays.Value)
            {
                case 1:
                    AddToSchedule("G02", StartDate, false);
                    AddToSchedule("G03", StartDate, false);
                    AddToSchedule("G04", StartDate, false);
                    AddToSchedule("G05", StartDate, false);
                    break;
                case 2:
                    AddToSchedule("G02", StartDate, false);
                    StartDate = AddToSchedule("G03", StartDate, true);
                    AddToSchedule("G04", StartDate, false);
                    AddToSchedule("G05", StartDate, false);
                    break;
                case 3:
                    StartDate = AddToSchedule("G02", StartDate, true);
                    StartDate = AddToSchedule("G03", StartDate, true);
                    AddToSchedule("G04", StartDate, false);
                    AddToSchedule("G05", StartDate, false);
                    break;
                case 4:
                    StartDate = AddToSchedule("G02", StartDate, true);
                    StartDate = AddToSchedule("G03", StartDate, true);
                    StartDate = AddToSchedule("G04", StartDate, true);
                    AddToSchedule("G05", StartDate, false);
                    break;
                case 5:
                    StartDate = AddToSchedule("G02", StartDate, true);
                    StartDate = AddToSchedule("G03", StartDate, true);
                    StartDate = AddToSchedule("G04", StartDate, true);
                    StartDate = AddToSchedule("G05", StartDate, true);
                    break;
            }
        }

        private void ProcessBucketDirectory(List<string>? BucketDirectory)
        {
            var Test = BucketDirectory;

            List<Entities.EntityGroup> Groups = new List<Entities.EntityGroup>();

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

                    Groups.Add(new Entities.EntityGroup { ReleaseName = DirName, ReleaseNoSort = ReleaseNoSort });
                }

                if (Groups.Count > 0)
                {
                    Groups = Groups.OrderByDescending(x => x.ReleaseNoSort).ToList();

                    cboVersionToInstall.DataSource = Groups;
                    cboVersionToInstall.DisplayMember = "ReleaseName";
                    cboVersionToInstall.ValueMember = "ReleaseName";
                    cboVersionToInstall.SelectedIndex = -1;

//                    SetGroupReleaseName();
                }
            }
        }

        private DateTime AddToSchedule(string GroupName, DateTime StartDate, bool AddOneDayToDate)
        {
            if (AddOneDayToDate)
            {
                StartDate = StartDate.AddDays(1);
            }

            ListViewItem lvi = new ListViewItem(GroupName);
            lvi.SubItems.Add(StartDate.ToString("yyyy-MM-dd H:mm"));
            lvi.SubItems.Add(StartDate.DayOfWeek.ToString());
            lvSchedule.Items.Add(lvi);

            return StartDate;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeployementStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (DeployementStartDate.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La date de déploiement ne peut pas être dans le passé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch(DeployementStartDate.Value.Date.DayOfWeek)
            {
                case DayOfWeek.Monday: lblDayOfWeek.Text = "Lundi"; break;
                case DayOfWeek.Tuesday: lblDayOfWeek.Text = "Mardi"; break;
                case DayOfWeek.Wednesday: lblDayOfWeek.Text = "Mercredi"; break;
                case DayOfWeek.Thursday: lblDayOfWeek.Text = "Jeudi"; break;
                case DayOfWeek.Friday: lblDayOfWeek.Text = "Vendredi"; break;
                case DayOfWeek.Saturday: lblDayOfWeek.Text = "Samedi"; break;
                case DayOfWeek.Sunday: lblDayOfWeek.Text = "Dimanche"; break;
            }

            switch (DeployementStartDate.Value.Date.DayOfWeek)
            {
                case DayOfWeek.Thursday: 
                case DayOfWeek.Friday: 
                case DayOfWeek.Saturday: 
                case DayOfWeek.Sunday:
                    MessageBox.Show("Normalement on déploie seulement le Lundi, mardi ou Mercredi, sauf exception...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }

            GenerateSchedule();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime DeploymentDateAndTime;
            string ErrorMessage;
            string GroupId;
            String DeploymentDate;
            String DeploymentTime;
            string Sql;
            // _dtGroup

            if (cboVersionToInstall.SelectedValue == null)
            {
                MessageBox.Show("Choisir une version a déployer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (ListViewItem lvi in lvSchedule.Items)
            {
                DataRow[] dr = _dtGroup.Select($"name = '{lvi.Text}'");

                if (dr != null)
                {
                    GroupId = dr[0]["idGroup"].ToString();

                    DeploymentDateAndTime = DateTime.Parse(lvi.SubItems[1].Text);

                    Sql = $"Insert Into {DoubleQuote}deploymentSchedule{DoubleQuote} ({DoubleQuote}idGroup{DoubleQuote}, {DoubleQuote}releaseName{DoubleQuote}, {DoubleQuote}deployStartDate{DoubleQuote}, {DoubleQuote}deployStartTime{DoubleQuote}, {DoubleQuote}deploymentCompleted{DoubleQuote}) " +
                    $"Values ({GroupId}, '{cboVersionToInstall.SelectedValue}', '{DeploymentDateAndTime.ToString("yyyy-MM-dd")}', '{DeploymentDateAndTime.ToString("H:mm")}', {false})";

                    int RowUpdated = Database.ExecuteUpdate(Sql, out ErrorMessage);

                    if (!string.IsNullOrWhiteSpace(ErrorMessage))
                    {
                        MessageBox.Show($"Erreur SQL. \n{ErrorMessage}\n\nSQL: \n{Sql}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            MessageBox.Show("Cédule de déploiement sauvegarder.");

        }

        private void NumNbrOfDays_ValueChanged(object sender, EventArgs e)
        {
            GenerateSchedule();
        }
    }
}
