namespace DeploymentScheduler
{
    partial class FrmEditScheduler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboGroup = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            tbIdClinic = new TextBox();
            lblVersionToInstall = new Label();
            cboVersionToInstall = new ComboBox();
            btnSave = new Button();
            btnClose = new Button();
            tbClinicName = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cbxDeploymentCompleted = new CheckBox();
            DeployementDate = new DateTimePicker();
            cboDeploymentTime = new ComboBox();
            SuspendLayout();
            // 
            // cboGroup
            // 
            cboGroup.FormattingEnabled = true;
            cboGroup.Location = new Point(165, 26);
            cboGroup.Name = "cboGroup";
            cboGroup.Size = new Size(145, 23);
            cboGroup.TabIndex = 0;
            cboGroup.SelectedIndexChanged += cboGroup_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 30);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 1;
            label1.Text = "Groupe:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(321, 30);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 2;
            label2.Text = "ou     Id Clinique:";
            // 
            // tbIdClinic
            // 
            tbIdClinic.Location = new Point(427, 26);
            tbIdClinic.Name = "tbIdClinic";
            tbIdClinic.Size = new Size(100, 23);
            tbIdClinic.TabIndex = 3;
            tbIdClinic.TextChanged += tbIdClinic_TextChanged;
            // 
            // lblVersionToInstall
            // 
            lblVersionToInstall.AutoSize = true;
            lblVersionToInstall.Location = new Point(48, 78);
            lblVersionToInstall.Name = "lblVersionToInstall";
            lblVersionToInstall.Size = new Size(96, 15);
            lblVersionToInstall.TabIndex = 1;
            lblVersionToInstall.Text = "Version to install:";
            // 
            // cboVersionToInstall
            // 
            cboVersionToInstall.FormattingEnabled = true;
            cboVersionToInstall.Location = new Point(165, 74);
            cboVersionToInstall.Name = "cboVersionToInstall";
            cboVersionToInstall.Size = new Size(145, 23);
            cboVersionToInstall.TabIndex = 4;
            cboVersionToInstall.SelectedIndexChanged += cboVersionToInstall_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(731, 180);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(50, 23);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(675, 180);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(50, 23);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // tbClinicName
            // 
            tbClinicName.Location = new Point(540, 26);
            tbClinicName.Name = "tbClinicName";
            tbClinicName.ReadOnly = true;
            tbClinicName.Size = new Size(235, 23);
            tbClinicName.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 108);
            label4.Name = "label4";
            label4.Size = new Size(120, 15);
            label4.TabIndex = 7;
            label4.Text = "Date de déploiement:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 138);
            label5.Name = "label5";
            label5.Size = new Size(128, 15);
            label5.TabIndex = 7;
            label5.Text = "Heure de déploiement:";
            // 
            // cbxDeploymentCompleted
            // 
            cbxDeploymentCompleted.AutoSize = true;
            cbxDeploymentCompleted.CheckAlign = ContentAlignment.MiddleRight;
            cbxDeploymentCompleted.FlatStyle = FlatStyle.Popup;
            cbxDeploymentCompleted.ImageAlign = ContentAlignment.MiddleRight;
            cbxDeploymentCompleted.Location = new Point(16, 161);
            cbxDeploymentCompleted.Name = "cbxDeploymentCompleted";
            cbxDeploymentCompleted.Size = new Size(145, 19);
            cbxDeploymentCompleted.TabIndex = 8;
            cbxDeploymentCompleted.Text = "Déploiement completé";
            cbxDeploymentCompleted.UseVisualStyleBackColor = true;
            // 
            // DeployementDate
            // 
            DeployementDate.Location = new Point(165, 104);
            DeployementDate.Name = "DeployementDate";
            DeployementDate.Size = new Size(145, 23);
            DeployementDate.TabIndex = 9;
            // 
            // cboDeploymentTime
            // 
            cboDeploymentTime.FormattingEnabled = true;
            cboDeploymentTime.Location = new Point(165, 134);
            cboDeploymentTime.Name = "cboDeploymentTime";
            cboDeploymentTime.Size = new Size(145, 23);
            cboDeploymentTime.TabIndex = 10;
            // 
            // FrmEditScheduler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(783, 205);
            Controls.Add(cboDeploymentTime);
            Controls.Add(DeployementDate);
            Controls.Add(cbxDeploymentCompleted);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tbClinicName);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(cboVersionToInstall);
            Controls.Add(tbIdClinic);
            Controls.Add(label2);
            Controls.Add(lblVersionToInstall);
            Controls.Add(label1);
            Controls.Add(cboGroup);
            Name = "FrmEditScheduler";
            Text = "FrmEditScheduler";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboGroup;
        private Label label1;
        private Label label2;
        private TextBox tbIdClinic;
        private Label lblVersionToInstall;
        private ComboBox cboVersionToInstall;
        private Button btnSave;
        private Button btnClose;
        private TextBox tbClinicName;
        private Label label4;
        private Label label5;
        private CheckBox cbxDeploymentCompleted;
        private DateTimePicker DeployementDate;
        private ComboBox cboDeploymentTime;
    }
}