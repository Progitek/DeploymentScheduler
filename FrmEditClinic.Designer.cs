namespace DeploymentScheduler
{
    partial class FrmEditClinic
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            tbIdClinic = new TextBox();
            tbClinicName = new TextBox();
            cboEnv = new ComboBox();
            tbTel = new TextBox();
            tbCel = new TextBox();
            tbDsn = new TextBox();
            tbGroupId = new TextBox();
            cboGroup = new ComboBox();
            tbInstalledVersion = new TextBox();
            cboVersionToInstalled = new ComboBox();
            cboForceToVersion = new ComboBox();
            tbFalconVersion = new TextBox();
            tbUuid = new TextBox();
            tbUrl = new TextBox();
            pbCopyToClipboard = new PictureBox();
            bpOpenUrl = new PictureBox();
            btnSave = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pbCopyToClipboard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bpOpenUrl).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 20);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "Id Clinique:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 48);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 0;
            label2.Text = "Nom de la clinique:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 188);
            label3.Name = "label3";
            label3.Size = new Size(135, 15);
            label3.TabIndex = 0;
            label3.Text = "Groupe de déploiement:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 244);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 0;
            label4.Text = "Version installée:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 300);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 0;
            label5.Text = "Version à installée:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 272);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 0;
            label6.Text = "Forcer a la Version:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(61, 216);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 0;
            label7.Text = "Id du groupe:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(33, 360);
            label8.Name = "label8";
            label8.Size = new Size(106, 15);
            label8.TabIndex = 0;
            label8.Text = "Indentifiant (uuid):";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 387);
            label9.Name = "label9";
            label9.Size = new Size(129, 15);
            label9.TabIndex = 0;
            label9.Text = "URL pour déploiement:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(75, 104);
            label10.Name = "label10";
            label10.Size = new Size(64, 15);
            label10.TabIndex = 0;
            label10.Text = "Téléphone:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(80, 132);
            label11.Name = "label11";
            label11.Size = new Size(59, 15);
            label11.TabIndex = 0;
            label11.Text = "Cellulaire:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(109, 160);
            label12.Name = "label12";
            label12.Size = new Size(30, 15);
            label12.TabIndex = 0;
            label12.Text = "Dsn:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(48, 76);
            label13.Name = "label13";
            label13.Size = new Size(91, 15);
            label13.TabIndex = 0;
            label13.Text = "Environnement:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(53, 335);
            label14.Name = "label14";
            label14.Size = new Size(86, 15);
            label14.TabIndex = 0;
            label14.Text = "Version Falcon:";
            // 
            // tbIdClinic
            // 
            tbIdClinic.Location = new Point(151, 16);
            tbIdClinic.Name = "tbIdClinic";
            tbIdClinic.ReadOnly = true;
            tbIdClinic.Size = new Size(121, 23);
            tbIdClinic.TabIndex = 2;
            // 
            // tbClinicName
            // 
            tbClinicName.Location = new Point(151, 44);
            tbClinicName.Name = "tbClinicName";
            tbClinicName.ReadOnly = true;
            tbClinicName.Size = new Size(313, 23);
            tbClinicName.TabIndex = 2;
            // 
            // cboEnv
            // 
            cboEnv.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEnv.FormattingEnabled = true;
            cboEnv.Items.AddRange(new object[] { "prod", "test", "dev", "inactive" });
            cboEnv.Location = new Point(151, 72);
            cboEnv.Name = "cboEnv";
            cboEnv.Size = new Size(121, 23);
            cboEnv.TabIndex = 3;
            // 
            // tbTel
            // 
            tbTel.Location = new Point(151, 100);
            tbTel.Name = "tbTel";
            tbTel.ReadOnly = true;
            tbTel.Size = new Size(121, 23);
            tbTel.TabIndex = 2;
            // 
            // tbCel
            // 
            tbCel.Location = new Point(151, 128);
            tbCel.Name = "tbCel";
            tbCel.ReadOnly = true;
            tbCel.Size = new Size(121, 23);
            tbCel.TabIndex = 2;
            // 
            // tbDsn
            // 
            tbDsn.Location = new Point(151, 156);
            tbDsn.Name = "tbDsn";
            tbDsn.ReadOnly = true;
            tbDsn.Size = new Size(121, 23);
            tbDsn.TabIndex = 2;
            // 
            // tbGroupId
            // 
            tbGroupId.Location = new Point(151, 212);
            tbGroupId.Name = "tbGroupId";
            tbGroupId.ReadOnly = true;
            tbGroupId.Size = new Size(121, 23);
            tbGroupId.TabIndex = 2;
            // 
            // cboGroup
            // 
            cboGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGroup.FormattingEnabled = true;
            cboGroup.Items.AddRange(new object[] { "prod", "test", "inactive" });
            cboGroup.Location = new Point(151, 184);
            cboGroup.Name = "cboGroup";
            cboGroup.Size = new Size(121, 23);
            cboGroup.TabIndex = 3;
            cboGroup.SelectedIndexChanged += cboGroup_SelectedIndexChanged;
            // 
            // tbInstalledVersion
            // 
            tbInstalledVersion.Location = new Point(151, 240);
            tbInstalledVersion.Name = "tbInstalledVersion";
            tbInstalledVersion.ReadOnly = true;
            tbInstalledVersion.Size = new Size(121, 23);
            tbInstalledVersion.TabIndex = 2;
            // 
            // cboVersionToInstalled
            // 
            cboVersionToInstalled.Enabled = false;
            cboVersionToInstalled.FormattingEnabled = true;
            cboVersionToInstalled.Location = new Point(151, 296);
            cboVersionToInstalled.Name = "cboVersionToInstalled";
            cboVersionToInstalled.Size = new Size(121, 23);
            cboVersionToInstalled.TabIndex = 4;
            // 
            // cboForceToVersion
            // 
            cboForceToVersion.FormattingEnabled = true;
            cboForceToVersion.Location = new Point(151, 268);
            cboForceToVersion.Name = "cboForceToVersion";
            cboForceToVersion.Size = new Size(121, 23);
            cboForceToVersion.TabIndex = 4;
            // 
            // tbFalconVersion
            // 
            tbFalconVersion.Location = new Point(151, 325);
            tbFalconVersion.Name = "tbFalconVersion";
            tbFalconVersion.ReadOnly = true;
            tbFalconVersion.Size = new Size(121, 23);
            tbFalconVersion.TabIndex = 2;
            // 
            // tbUuid
            // 
            tbUuid.Location = new Point(151, 357);
            tbUuid.Name = "tbUuid";
            tbUuid.ReadOnly = true;
            tbUuid.Size = new Size(313, 23);
            tbUuid.TabIndex = 2;
            // 
            // tbUrl
            // 
            tbUrl.Location = new Point(151, 387);
            tbUrl.Name = "tbUrl";
            tbUrl.ReadOnly = true;
            tbUrl.Size = new Size(449, 23);
            tbUrl.TabIndex = 2;
            // 
            // pbCopyToClipboard
            // 
            pbCopyToClipboard.Image = Properties.Resources.Copy;
            pbCopyToClipboard.Location = new Point(608, 387);
            pbCopyToClipboard.Name = "pbCopyToClipboard";
            pbCopyToClipboard.Size = new Size(28, 28);
            pbCopyToClipboard.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCopyToClipboard.TabIndex = 5;
            pbCopyToClipboard.TabStop = false;
            pbCopyToClipboard.Click += pbCopyToClipboard_Click;
            // 
            // bpOpenUrl
            // 
            bpOpenUrl.Image = Properties.Resources.OpenBrowser;
            bpOpenUrl.Location = new Point(643, 387);
            bpOpenUrl.Name = "bpOpenUrl";
            bpOpenUrl.Size = new Size(28, 28);
            bpOpenUrl.SizeMode = PictureBoxSizeMode.StretchImage;
            bpOpenUrl.TabIndex = 5;
            bpOpenUrl.TabStop = false;
            bpOpenUrl.Click += bpOpenUrl_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(616, 490);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(56, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(550, 490);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(56, 23);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FrmEditClinic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(678, 520);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(bpOpenUrl);
            Controls.Add(pbCopyToClipboard);
            Controls.Add(cboForceToVersion);
            Controls.Add(cboVersionToInstalled);
            Controls.Add(cboGroup);
            Controls.Add(cboEnv);
            Controls.Add(tbUrl);
            Controls.Add(tbUuid);
            Controls.Add(tbFalconVersion);
            Controls.Add(tbInstalledVersion);
            Controls.Add(tbGroupId);
            Controls.Add(tbDsn);
            Controls.Add(tbCel);
            Controls.Add(tbTel);
            Controls.Add(tbClinicName);
            Controls.Add(tbIdClinic);
            Controls.Add(label7);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label14);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label3);
            Controls.Add(label13);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmEditClinic";
            Text = "Edition d'une Clinique";
            ((System.ComponentModel.ISupportInitialize)pbCopyToClipboard).EndInit();
            ((System.ComponentModel.ISupportInitialize)bpOpenUrl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox tbIdClinic;
        private TextBox tbClinicName;
        private ComboBox cboEnv;
        private TextBox tbTel;
        private TextBox tbCel;
        private TextBox tbDsn;
        private TextBox tbGroupId;
        private ComboBox cboGroup;
        private TextBox tbInstalledVersion;
        private ComboBox cboVersionToInstalled;
        private ComboBox cboForceToVersion;
        private TextBox tbFalconVersion;
        private TextBox tbUuid;
        private TextBox tbUrl;
        private PictureBox pbCopyToClipboard;
        private PictureBox bpOpenUrl;
        private Button btnSave;
        private Button btnClose;
    }
}