namespace DeploymentScheduler
{
    partial class FrmGenerateSchedule
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
            btnClose = new Button();
            btnSave = new Button();
            DeployementStartDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            NumNbrOfDays = new NumericUpDown();
            lvSchedule = new ListView();
            ColGroupName = new ColumnHeader();
            ColDate = new ColumnHeader();
            ColDayName = new ColumnHeader();
            cboVersionToInstall = new ComboBox();
            lblVersionToInstall = new Label();
            lblDayOfWeek = new Label();
            ((System.ComponentModel.ISupportInitialize)NumNbrOfDays).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.DialogResult = DialogResult.OK;
            btnClose.Location = new Point(381, 331);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Fermer";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(295, 331);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(81, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Sauvegarder";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // DeployementStartDate
            // 
            DeployementStartDate.Location = new Point(215, 32);
            DeployementStartDate.Name = "DeployementStartDate";
            DeployementStartDate.Size = new Size(145, 23);
            DeployementStartDate.TabIndex = 10;
            DeployementStartDate.ValueChanged += DeployementStartDate_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 11;
            label1.Text = "Début du déploiement:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 63);
            label2.Name = "label2";
            label2.Size = new Size(168, 15);
            label2.TabIndex = 11;
            label2.Text = "Déployer en combien de jours:";
            // 
            // NumNbrOfDays
            // 
            NumNbrOfDays.Location = new Point(218, 59);
            NumNbrOfDays.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            NumNbrOfDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumNbrOfDays.Name = "NumNbrOfDays";
            NumNbrOfDays.Size = new Size(46, 23);
            NumNbrOfDays.TabIndex = 12;
            NumNbrOfDays.TextAlign = HorizontalAlignment.Center;
            NumNbrOfDays.Value = new decimal(new int[] { 3, 0, 0, 0 });
            NumNbrOfDays.ValueChanged += NumNbrOfDays_ValueChanged;
            // 
            // lvSchedule
            // 
            lvSchedule.Columns.AddRange(new ColumnHeader[] { ColGroupName, ColDate, ColDayName });
            lvSchedule.Location = new Point(14, 126);
            lvSchedule.Name = "lvSchedule";
            lvSchedule.Size = new Size(351, 196);
            lvSchedule.TabIndex = 13;
            lvSchedule.UseCompatibleStateImageBehavior = false;
            lvSchedule.View = View.Details;
            // 
            // ColGroupName
            // 
            ColGroupName.Text = "Nom du Groupe";
            ColGroupName.Width = 100;
            // 
            // ColDate
            // 
            ColDate.Text = "Date de déploiement";
            ColDate.Width = 130;
            // 
            // ColDayName
            // 
            ColDayName.Text = "Jour";
            ColDayName.Width = 90;
            // 
            // cboVersionToInstall
            // 
            cboVersionToInstall.FormattingEnabled = true;
            cboVersionToInstall.Location = new Point(215, 86);
            cboVersionToInstall.Name = "cboVersionToInstall";
            cboVersionToInstall.Size = new Size(145, 23);
            cboVersionToInstall.TabIndex = 14;
            // 
            // lblVersionToInstall
            // 
            lblVersionToInstall.AutoSize = true;
            lblVersionToInstall.Location = new Point(12, 90);
            lblVersionToInstall.Name = "lblVersionToInstall";
            lblVersionToInstall.Size = new Size(107, 15);
            lblVersionToInstall.TabIndex = 15;
            lblVersionToInstall.Text = "Version a Déployer:";
            // 
            // lblDayOfWeek
            // 
            lblDayOfWeek.AutoSize = true;
            lblDayOfWeek.Location = new Point(375, 36);
            lblDayOfWeek.Name = "lblDayOfWeek";
            lblDayOfWeek.Size = new Size(38, 15);
            lblDayOfWeek.TabIndex = 16;
            lblDayOfWeek.Text = "label3";
            // 
            // FrmGenerateSchedule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 356);
            Controls.Add(lblDayOfWeek);
            Controls.Add(lblVersionToInstall);
            Controls.Add(cboVersionToInstall);
            Controls.Add(lvSchedule);
            Controls.Add(NumNbrOfDays);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DeployementStartDate);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Name = "FrmGenerateSchedule";
            Text = "Génération d'une cédule de déploiement";
            ((System.ComponentModel.ISupportInitialize)NumNbrOfDays).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Button btnSave;
        private DateTimePicker DeployementStartDate;
        private Label label1;
        private Label label2;
        private NumericUpDown NumNbrOfDays;
        private ListView lvSchedule;
        private ColumnHeader ColGroupName;
        private ColumnHeader ColDate;
        private ColumnHeader ColDayName;
        private ComboBox cboVersionToInstall;
        private Label lblVersionToInstall;
        private Label lblDayOfWeek;
    }
}