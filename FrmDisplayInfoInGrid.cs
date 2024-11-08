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
    public partial class FrmDisplayInfoInGrid : Form
    {
        private string _FromTitle;

        public FrmDisplayInfoInGrid(string Sql, string FromTitle = "Display Data")
        {
            InitializeComponent();

            _FromTitle = FromTitle;

            Init(Sql);
        }

        private void Init (string Sql)
        {
            string ErrorMessage = "";
            DataTable? Dt = Database.GetData(Sql, out ErrorMessage);

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show($"Error: {ErrorMessage}", "Database Error");
            }
            else
            {
                DgData.DataSource = Dt;
            }

            this.Text = _FromTitle;

            FrmDisplayInfoInGrid_Resize(this, new EventArgs());
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDisplayInfoInGrid_Resize(object sender, EventArgs e)
        {
            DgData.Width = this.Width - 35;
            DgData.Height = this.Height - BtnClose.Height - 55;
        }
    }
}
