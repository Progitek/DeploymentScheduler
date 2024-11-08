namespace DeploymentScheduler
{
    partial class DentitekDeploymentSchedulerGui
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lvGroupAndClinic = new ListView();
            IdGroup = new ColumnHeader();
            ColName = new ColumnHeader();
            ColVersion = new ColumnHeader();
            label1 = new Label();
            btnConnect = new Button();
            lvClinicInfo = new ListView();
            IdClinic = new ColumnHeader();
            Env = new ColumnHeader();
            ClinicName = new ColumnHeader();
            Statut = new ColumnHeader();
            NomDentiste = new ColumnHeader();
            GroupName = new ColumnHeader();
            GroupId = new ColumnHeader();
            VersionForced = new ColumnHeader();
            DeployedVersion = new ColumnHeader();
            InstalledVersion = new ColumnHeader();
            Uuid = new ColumnHeader();
            Phone = new ColumnHeader();
            Cellular = new ColumnHeader();
            FalconInstalled = new ColumnHeader();
            FalconChannel = new ColumnHeader();
            btnEdit = new Button();
            rbFilterByGroupeName = new RadioButton();
            rbFilterByAll = new RadioButton();
            tbFilterByName = new TextBox();
            lblClinicCount = new Label();
            label4 = new Label();
            lvDeploymentSchedule = new ListView();
            Status = new ColumnHeader();
            StartDate = new ColumnHeader();
            StartTime = new ColumnHeader();
            DeploymentGroupName = new ColumnHeader();
            DeploymentClinicName = new ColumnHeader();
            ForceToVersion = new ColumnHeader();
            DeploymentVersion = new ColumnHeader();
            btnEditSchedule = new Button();
            rbForceToVersion = new RadioButton();
            rbClinicName = new RadioButton();
            cboForVersion = new ComboBox();
            rbVersion = new RadioButton();
            btnS3VersionList = new Button();
            lvS3VersionBucket = new ListView();
            ColFolderName = new ColumnHeader();
            label3 = new Label();
            btnAddSchedule = new Button();
            label5 = new Label();
            label6 = new Label();
            pbConnectedAws = new PictureBox();
            pbConnectedBD = new PictureBox();
            rbFIlterByDentistName = new RadioButton();
            rbFilterByCellOrPhone = new RadioButton();
            tbDentistName = new TextBox();
            tbTelOrCel = new TextBox();
            btnEditGroup = new Button();
            btnGeneerateSchedule = new Button();
            gbFilterClinic = new GroupBox();
            rbFIlterByDentalCorp = new RadioButton();
            gbEnv = new GroupBox();
            rbActive = new RadioButton();
            rbInactive = new RadioButton();
            rbAll = new RadioButton();
            rbDev = new RadioButton();
            rbTest = new RadioButton();
            rbProd = new RadioButton();
            MenuContextualClinic = new ContextMenuStrip(components);
            MenuItemClinicEdit = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            MenuItemFalconSynchroProgress = new ToolStripMenuItem();
            MenuItemFalconSettings = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            MenuItemServicesLog = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            MenuItemAgentsList = new ToolStripMenuItem();
            gbTools = new GroupBox();
            btnSql = new Button();
            ((System.ComponentModel.ISupportInitialize)pbConnectedAws).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbConnectedBD).BeginInit();
            gbFilterClinic.SuspendLayout();
            gbEnv.SuspendLayout();
            MenuContextualClinic.SuspendLayout();
            gbTools.SuspendLayout();
            SuspendLayout();
            // 
            // lvGroupAndClinic
            // 
            lvGroupAndClinic.Columns.AddRange(new ColumnHeader[] { IdGroup, ColName, ColVersion });
            lvGroupAndClinic.FullRowSelect = true;
            lvGroupAndClinic.GridLines = true;
            lvGroupAndClinic.Location = new Point(12, 23);
            lvGroupAndClinic.Name = "lvGroupAndClinic";
            lvGroupAndClinic.ShowGroups = false;
            lvGroupAndClinic.Size = new Size(242, 237);
            lvGroupAndClinic.TabIndex = 0;
            lvGroupAndClinic.UseCompatibleStateImageBehavior = false;
            lvGroupAndClinic.View = View.Details;
            lvGroupAndClinic.Click += lvGroupAndClinic_Click;
            // 
            // IdGroup
            // 
            IdGroup.Text = "Id Group";
            // 
            // ColName
            // 
            ColName.Text = "Name";
            // 
            // ColVersion
            // 
            ColVersion.Text = "Version";
            ColVersion.Width = 100;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 1;
            label1.Text = "Groupe et Version:";
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConnect.Location = new Point(1101, 829);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Refresh";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lvClinicInfo
            // 
            lvClinicInfo.Columns.AddRange(new ColumnHeader[] { IdClinic, Env, ClinicName, Statut, NomDentiste, GroupName, GroupId, VersionForced, DeployedVersion, InstalledVersion, Uuid, Phone, Cellular, FalconInstalled, FalconChannel });
            lvClinicInfo.ForeColor = Color.DarkBlue;
            lvClinicInfo.FullRowSelect = true;
            lvClinicInfo.GridLines = true;
            lvClinicInfo.Location = new Point(12, 505);
            lvClinicInfo.MultiSelect = false;
            lvClinicInfo.Name = "lvClinicInfo";
            lvClinicInfo.ShowGroups = false;
            lvClinicInfo.Size = new Size(1264, 313);
            lvClinicInfo.TabIndex = 3;
            lvClinicInfo.UseCompatibleStateImageBehavior = false;
            lvClinicInfo.View = View.Details;
            lvClinicInfo.ColumnClick += lvClinicInfo_ColumnClick;
            lvClinicInfo.MouseClick += lvClinicInfo_MouseClick;
            // 
            // IdClinic
            // 
            IdClinic.Text = "Id Clinique";
            IdClinic.Width = 85;
            // 
            // Env
            // 
            Env.Text = "Env";
            // 
            // ClinicName
            // 
            ClinicName.Text = "Nom Clinique";
            ClinicName.Width = 200;
            // 
            // Statut
            // 
            Statut.Text = "Status";
            // 
            // NomDentiste
            // 
            NomDentiste.Text = "Nom Dentiste";
            NomDentiste.Width = 100;
            // 
            // GroupName
            // 
            GroupName.Text = "Nom Groupe";
            GroupName.Width = 95;
            // 
            // GroupId
            // 
            GroupId.Text = "Id Groupe";
            GroupId.Width = 75;
            // 
            // VersionForced
            // 
            VersionForced.Text = "Forcer a version";
            VersionForced.Width = 110;
            // 
            // DeployedVersion
            // 
            DeployedVersion.Text = "Version à Installer";
            DeployedVersion.Width = 110;
            // 
            // InstalledVersion
            // 
            InstalledVersion.Text = "Version installé";
            InstalledVersion.Width = 105;
            // 
            // Uuid
            // 
            Uuid.Text = "Uuid pour URL";
            Uuid.Width = 100;
            // 
            // Phone
            // 
            Phone.Text = "Téléphone";
            Phone.Width = 80;
            // 
            // Cellular
            // 
            Cellular.Text = "Cellulaire";
            Cellular.Width = 75;
            // 
            // FalconInstalled
            // 
            FalconInstalled.Text = "Falcon";
            // 
            // FalconChannel
            // 
            FalconChannel.Text = "Falcon Channel";
            FalconChannel.Width = 100;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEdit.Location = new Point(1191, 829);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // rbFilterByGroupeName
            // 
            rbFilterByGroupeName.AutoSize = true;
            rbFilterByGroupeName.Location = new Point(6, 22);
            rbFilterByGroupeName.Name = "rbFilterByGroupeName";
            rbFilterByGroupeName.Size = new Size(145, 19);
            rbFilterByGroupeName.TabIndex = 6;
            rbFilterByGroupeName.TabStop = true;
            rbFilterByGroupeName.Text = "Par groupe slectionnés";
            rbFilterByGroupeName.UseVisualStyleBackColor = true;
            rbFilterByGroupeName.Click += rbFilterByGroupeName_Click;
            // 
            // rbFilterByAll
            // 
            rbFilterByAll.AutoSize = true;
            rbFilterByAll.Location = new Point(6, 44);
            rbFilterByAll.Name = "rbFilterByAll";
            rbFilterByAll.Size = new Size(126, 19);
            rbFilterByAll.TabIndex = 7;
            rbFilterByAll.TabStop = true;
            rbFilterByAll.Text = "Toutes les cliniques";
            rbFilterByAll.UseVisualStyleBackColor = true;
            rbFilterByAll.Click += rbFilterByAll_Click;
            // 
            // tbFilterByName
            // 
            tbFilterByName.Location = new Point(153, 132);
            tbFilterByName.Name = "tbFilterByName";
            tbFilterByName.Size = new Size(260, 23);
            tbFilterByName.TabIndex = 9;
            tbFilterByName.TextChanged += tbFilterByName_TextChanged;
            // 
            // lblClinicCount
            // 
            lblClinicCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblClinicCount.AutoSize = true;
            lblClinicCount.Location = new Point(12, 829);
            lblClinicCount.Name = "lblClinicCount";
            lblClinicCount.Size = new Size(38, 15);
            lblClinicCount.TabIndex = 10;
            lblClinicCount.Text = "label4";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(604, 6);
            label4.Name = "label4";
            label4.Size = new Size(136, 15);
            label4.TabIndex = 12;
            label4.Text = "Horaire de Déploiement:";
            // 
            // lvDeploymentSchedule
            // 
            lvDeploymentSchedule.Columns.AddRange(new ColumnHeader[] { Status, StartDate, StartTime, DeploymentGroupName, DeploymentClinicName, ForceToVersion, DeploymentVersion });
            lvDeploymentSchedule.FullRowSelect = true;
            lvDeploymentSchedule.GridLines = true;
            lvDeploymentSchedule.Location = new Point(604, 23);
            lvDeploymentSchedule.MultiSelect = false;
            lvDeploymentSchedule.Name = "lvDeploymentSchedule";
            lvDeploymentSchedule.ShowGroups = false;
            lvDeploymentSchedule.Size = new Size(672, 237);
            lvDeploymentSchedule.TabIndex = 11;
            lvDeploymentSchedule.UseCompatibleStateImageBehavior = false;
            lvDeploymentSchedule.View = View.Details;
            // 
            // Status
            // 
            Status.Text = "Status";
            Status.TextAlign = HorizontalAlignment.Center;
            // 
            // StartDate
            // 
            StartDate.Text = "Start Date";
            StartDate.Width = 90;
            // 
            // StartTime
            // 
            StartTime.Text = "Start Time";
            StartTime.Width = 70;
            // 
            // DeploymentGroupName
            // 
            DeploymentGroupName.Text = "Group Name";
            DeploymentGroupName.Width = 80;
            // 
            // DeploymentClinicName
            // 
            DeploymentClinicName.Text = "Clinic Name";
            DeploymentClinicName.Width = 150;
            // 
            // ForceToVersion
            // 
            ForceToVersion.Text = "Forcer à Version";
            ForceToVersion.Width = 100;
            // 
            // DeploymentVersion
            // 
            DeploymentVersion.Text = "Version a Installée";
            DeploymentVersion.Width = 110;
            // 
            // btnEditSchedule
            // 
            btnEditSchedule.Location = new Point(1201, 267);
            btnEditSchedule.Name = "btnEditSchedule";
            btnEditSchedule.Size = new Size(75, 23);
            btnEditSchedule.TabIndex = 5;
            btnEditSchedule.Text = "Edit";
            btnEditSchedule.UseVisualStyleBackColor = true;
            btnEditSchedule.Click += button1_Click;
            // 
            // rbForceToVersion
            // 
            rbForceToVersion.AutoSize = true;
            rbForceToVersion.Location = new Point(6, 181);
            rbForceToVersion.Name = "rbForceToVersion";
            rbForceToVersion.Size = new Size(131, 19);
            rbForceToVersion.TabIndex = 7;
            rbForceToVersion.TabStop = true;
            rbForceToVersion.Text = "Forcer a une version";
            rbForceToVersion.UseVisualStyleBackColor = true;
            rbForceToVersion.Click += rbForceToVersion_Click;
            // 
            // rbClinicName
            // 
            rbClinicName.AutoSize = true;
            rbClinicName.Location = new Point(6, 134);
            rbClinicName.Name = "rbClinicName";
            rbClinicName.Size = new Size(113, 19);
            rbClinicName.TabIndex = 7;
            rbClinicName.TabStop = true;
            rbClinicName.Text = "Nom de clinique";
            rbClinicName.UseVisualStyleBackColor = true;
            rbClinicName.Click += rbClinicName_Click;
            // 
            // cboForVersion
            // 
            cboForVersion.Enabled = false;
            cboForVersion.FormattingEnabled = true;
            cboForVersion.Location = new Point(153, 156);
            cboForVersion.Name = "cboForVersion";
            cboForVersion.Size = new Size(121, 23);
            cboForVersion.TabIndex = 13;
            cboForVersion.SelectedIndexChanged += cboForVersion_SelectedIndexChanged;
            // 
            // rbVersion
            // 
            rbVersion.AutoSize = true;
            rbVersion.Location = new Point(6, 158);
            rbVersion.Name = "rbVersion";
            rbVersion.Size = new Size(114, 19);
            rbVersion.TabIndex = 7;
            rbVersion.TabStop = true;
            rbVersion.Text = "Pour une Version";
            rbVersion.UseVisualStyleBackColor = true;
            rbVersion.Click += rbVersion_Click;
            // 
            // btnS3VersionList
            // 
            btnS3VersionList.Location = new Point(300, 263);
            btnS3VersionList.Name = "btnS3VersionList";
            btnS3VersionList.Size = new Size(112, 23);
            btnS3VersionList.TabIndex = 14;
            btnS3VersionList.Text = "Liste Version (S3)";
            btnS3VersionList.UseVisualStyleBackColor = true;
            btnS3VersionList.Click += btnS3VersionList_Click;
            // 
            // lvS3VersionBucket
            // 
            lvS3VersionBucket.Columns.AddRange(new ColumnHeader[] { ColFolderName });
            lvS3VersionBucket.FullRowSelect = true;
            lvS3VersionBucket.GridLines = true;
            lvS3VersionBucket.LabelWrap = false;
            lvS3VersionBucket.Location = new Point(300, 23);
            lvS3VersionBucket.MultiSelect = false;
            lvS3VersionBucket.Name = "lvS3VersionBucket";
            lvS3VersionBucket.ShowGroups = false;
            lvS3VersionBucket.Size = new Size(239, 237);
            lvS3VersionBucket.TabIndex = 15;
            lvS3VersionBucket.UseCompatibleStateImageBehavior = false;
            lvS3VersionBucket.View = View.Details;
            // 
            // ColFolderName
            // 
            ColFolderName.Text = "Folder Name";
            ColFolderName.Width = 235;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(300, 6);
            label3.Name = "label3";
            label3.Size = new Size(129, 15);
            label3.TabIndex = 16;
            label3.Text = "AWS S3 Version Bucket:";
            // 
            // btnAddSchedule
            // 
            btnAddSchedule.Location = new Point(1120, 267);
            btnAddSchedule.Name = "btnAddSchedule";
            btnAddSchedule.Size = new Size(75, 23);
            btnAddSchedule.TabIndex = 17;
            btnAddSchedule.Text = "Add";
            btnAddSchedule.UseVisualStyleBackColor = true;
            btnAddSchedule.Click += btnAddSchedule_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(807, 833);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 18;
            label5.Text = "Brancher a AWS";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(937, 833);
            label6.Name = "label6";
            label6.Size = new Size(109, 15);
            label6.TabIndex = 19;
            label6.Text = "Brancher a BD Prod";
            // 
            // pbConnectedAws
            // 
            pbConnectedAws.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pbConnectedAws.Location = new Point(903, 828);
            pbConnectedAws.Name = "pbConnectedAws";
            pbConnectedAws.Size = new Size(24, 24);
            pbConnectedAws.SizeMode = PictureBoxSizeMode.StretchImage;
            pbConnectedAws.TabIndex = 20;
            pbConnectedAws.TabStop = false;
            // 
            // pbConnectedBD
            // 
            pbConnectedBD.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pbConnectedBD.Location = new Point(1052, 828);
            pbConnectedBD.Name = "pbConnectedBD";
            pbConnectedBD.Size = new Size(24, 24);
            pbConnectedBD.SizeMode = PictureBoxSizeMode.StretchImage;
            pbConnectedBD.TabIndex = 21;
            pbConnectedBD.TabStop = false;
            // 
            // rbFIlterByDentistName
            // 
            rbFIlterByDentistName.AutoSize = true;
            rbFIlterByDentistName.Location = new Point(6, 85);
            rbFIlterByDentistName.Name = "rbFIlterByDentistName";
            rbFIlterByDentistName.Size = new Size(131, 19);
            rbFIlterByDentistName.TabIndex = 22;
            rbFIlterByDentistName.TabStop = true;
            rbFIlterByDentistName.Text = "Par nom de dentiste";
            rbFIlterByDentistName.UseVisualStyleBackColor = true;
            rbFIlterByDentistName.Click += rbFIlterByDentistName_Click;
            // 
            // rbFilterByCellOrPhone
            // 
            rbFilterByCellOrPhone.AutoSize = true;
            rbFilterByCellOrPhone.Location = new Point(6, 109);
            rbFilterByCellOrPhone.Name = "rbFilterByCellOrPhone";
            rbFilterByCellOrPhone.Size = new Size(96, 19);
            rbFilterByCellOrPhone.TabIndex = 23;
            rbFilterByCellOrPhone.TabStop = true;
            rbFilterByCellOrPhone.Text = "Par Tel ou Cel";
            rbFilterByCellOrPhone.UseVisualStyleBackColor = true;
            rbFilterByCellOrPhone.Click += rbFilterByCellOrPhone_Click;
            // 
            // tbDentistName
            // 
            tbDentistName.Location = new Point(153, 83);
            tbDentistName.Name = "tbDentistName";
            tbDentistName.Size = new Size(260, 23);
            tbDentistName.TabIndex = 9;
            tbDentistName.TextChanged += tbDentistName_TextChanged;
            // 
            // tbTelOrCel
            // 
            tbTelOrCel.Location = new Point(153, 107);
            tbTelOrCel.Name = "tbTelOrCel";
            tbTelOrCel.Size = new Size(260, 23);
            tbTelOrCel.TabIndex = 9;
            tbTelOrCel.TextChanged += tbTelOrCel_TextChanged;
            // 
            // btnEditGroup
            // 
            btnEditGroup.Location = new Point(12, 263);
            btnEditGroup.Name = "btnEditGroup";
            btnEditGroup.Size = new Size(75, 23);
            btnEditGroup.TabIndex = 24;
            btnEditGroup.Text = "Edit";
            btnEditGroup.UseVisualStyleBackColor = true;
            btnEditGroup.Click += btnEditGroup_Click;
            // 
            // btnGeneerateSchedule
            // 
            btnGeneerateSchedule.Location = new Point(1036, 267);
            btnGeneerateSchedule.Name = "btnGeneerateSchedule";
            btnGeneerateSchedule.Size = new Size(75, 23);
            btnGeneerateSchedule.TabIndex = 25;
            btnGeneerateSchedule.Text = "Générer";
            btnGeneerateSchedule.UseVisualStyleBackColor = true;
            btnGeneerateSchedule.Click += btnGeneerateSchedule_Click;
            // 
            // gbFilterClinic
            // 
            gbFilterClinic.Controls.Add(rbFilterByGroupeName);
            gbFilterClinic.Controls.Add(rbFIlterByDentalCorp);
            gbFilterClinic.Controls.Add(rbFilterByAll);
            gbFilterClinic.Controls.Add(rbForceToVersion);
            gbFilterClinic.Controls.Add(rbFilterByCellOrPhone);
            gbFilterClinic.Controls.Add(rbClinicName);
            gbFilterClinic.Controls.Add(rbFIlterByDentistName);
            gbFilterClinic.Controls.Add(rbVersion);
            gbFilterClinic.Controls.Add(tbFilterByName);
            gbFilterClinic.Controls.Add(tbDentistName);
            gbFilterClinic.Controls.Add(tbTelOrCel);
            gbFilterClinic.Controls.Add(cboForVersion);
            gbFilterClinic.Location = new Point(12, 292);
            gbFilterClinic.Name = "gbFilterClinic";
            gbFilterClinic.Size = new Size(464, 207);
            gbFilterClinic.TabIndex = 26;
            gbFilterClinic.TabStop = false;
            gbFilterClinic.Text = "Filtrer liste des cliniques";
            // 
            // rbFIlterByDentalCorp
            // 
            rbFIlterByDentalCorp.AutoSize = true;
            rbFIlterByDentalCorp.Location = new Point(6, 65);
            rbFIlterByDentalCorp.Name = "rbFIlterByDentalCorp";
            rbFIlterByDentalCorp.Size = new Size(143, 19);
            rbFIlterByDentalCorp.TabIndex = 7;
            rbFIlterByDentalCorp.TabStop = true;
            rbFIlterByDentalCorp.Text = "Cliniques Dental Corp.";
            rbFIlterByDentalCorp.UseVisualStyleBackColor = true;
            rbFIlterByDentalCorp.Click += rbFIlterByDentalCorp_Click;
            // 
            // gbEnv
            // 
            gbEnv.Controls.Add(rbActive);
            gbEnv.Controls.Add(rbInactive);
            gbEnv.Controls.Add(rbAll);
            gbEnv.Controls.Add(rbDev);
            gbEnv.Controls.Add(rbTest);
            gbEnv.Controls.Add(rbProd);
            gbEnv.Location = new Point(90, 819);
            gbEnv.Name = "gbEnv";
            gbEnv.Size = new Size(375, 33);
            gbEnv.TabIndex = 27;
            gbEnv.TabStop = false;
            // 
            // rbActive
            // 
            rbActive.AutoSize = true;
            rbActive.Checked = true;
            rbActive.Location = new Point(6, 12);
            rbActive.Name = "rbActive";
            rbActive.Size = new Size(58, 19);
            rbActive.TabIndex = 28;
            rbActive.TabStop = true;
            rbActive.Text = "Active";
            rbActive.UseVisualStyleBackColor = true;
            rbActive.Click += rbActive_Click;
            // 
            // rbInactive
            // 
            rbInactive.AutoSize = true;
            rbInactive.Location = new Point(240, 12);
            rbInactive.Name = "rbInactive";
            rbInactive.Size = new Size(66, 19);
            rbInactive.TabIndex = 0;
            rbInactive.Text = "Inactive";
            rbInactive.UseVisualStyleBackColor = true;
            rbInactive.CheckedChanged += rbInactive_CheckedChanged;
            // 
            // rbAll
            // 
            rbAll.AutoSize = true;
            rbAll.Location = new Point(315, 12);
            rbAll.Name = "rbAll";
            rbAll.Size = new Size(59, 19);
            rbAll.TabIndex = 0;
            rbAll.Text = "Toutes";
            rbAll.UseVisualStyleBackColor = true;
            rbAll.Click += rbAll_Click;
            // 
            // rbDev
            // 
            rbDev.AutoSize = true;
            rbDev.Location = new Point(186, 12);
            rbDev.Name = "rbDev";
            rbDev.Size = new Size(45, 19);
            rbDev.TabIndex = 0;
            rbDev.Text = "Dev";
            rbDev.UseVisualStyleBackColor = true;
            rbDev.Click += rbDev_Click;
            // 
            // rbTest
            // 
            rbTest.AutoSize = true;
            rbTest.Location = new Point(132, 12);
            rbTest.Name = "rbTest";
            rbTest.Size = new Size(45, 19);
            rbTest.TabIndex = 0;
            rbTest.Text = "Test";
            rbTest.UseVisualStyleBackColor = true;
            rbTest.Click += rbTest_Click;
            // 
            // rbProd
            // 
            rbProd.AutoSize = true;
            rbProd.Location = new Point(73, 12);
            rbProd.Name = "rbProd";
            rbProd.Size = new Size(50, 19);
            rbProd.TabIndex = 0;
            rbProd.Text = "Prod";
            rbProd.UseVisualStyleBackColor = true;
            rbProd.Click += rbProd_Click;
            // 
            // MenuContextualClinic
            // 
            MenuContextualClinic.Items.AddRange(new ToolStripItem[] { MenuItemClinicEdit, toolStripSeparator1, MenuItemFalconSynchroProgress, MenuItemFalconSettings, toolStripSeparator2, MenuItemServicesLog, toolStripSeparator3, MenuItemAgentsList });
            MenuContextualClinic.Name = "MenuContextualClinic";
            MenuContextualClinic.Size = new Size(204, 132);
            // 
            // MenuItemClinicEdit
            // 
            MenuItemClinicEdit.Name = "MenuItemClinicEdit";
            MenuItemClinicEdit.Size = new Size(203, 22);
            MenuItemClinicEdit.Text = "Edit";
            MenuItemClinicEdit.Click += MenuItemClinic_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(200, 6);
            // 
            // MenuItemFalconSynchroProgress
            // 
            MenuItemFalconSynchroProgress.Name = "MenuItemFalconSynchroProgress";
            MenuItemFalconSynchroProgress.Size = new Size(203, 22);
            MenuItemFalconSynchroProgress.Text = "Falcon Synchro Progress";
            MenuItemFalconSynchroProgress.Click += MenuItemClinic_Click;
            // 
            // MenuItemFalconSettings
            // 
            MenuItemFalconSettings.Name = "MenuItemFalconSettings";
            MenuItemFalconSettings.Size = new Size(203, 22);
            MenuItemFalconSettings.Text = "Falcon Settings";
            MenuItemFalconSettings.Click += MenuItemClinic_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(200, 6);
            // 
            // MenuItemServicesLog
            // 
            MenuItemServicesLog.Name = "MenuItemServicesLog";
            MenuItemServicesLog.Size = new Size(203, 22);
            MenuItemServicesLog.Text = "Service C# Logs";
            MenuItemServicesLog.Click += MenuItemClinic_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(200, 6);
            // 
            // MenuItemAgentsList
            // 
            MenuItemAgentsList.Name = "MenuItemAgentsList";
            MenuItemAgentsList.Size = new Size(203, 22);
            MenuItemAgentsList.Text = "Agents List";
            MenuItemAgentsList.Click += MenuItemClinic_Click;
            // 
            // gbTools
            // 
            gbTools.Controls.Add(btnSql);
            gbTools.Location = new Point(483, 292);
            gbTools.Name = "gbTools";
            gbTools.Size = new Size(268, 207);
            gbTools.TabIndex = 28;
            gbTools.TabStop = false;
            gbTools.Text = "Outils";
            // 
            // btnSql
            // 
            btnSql.Location = new Point(13, 22);
            btnSql.Name = "btnSql";
            btnSql.Size = new Size(75, 23);
            btnSql.TabIndex = 0;
            btnSql.Text = "Sql";
            btnSql.UseVisualStyleBackColor = true;
            btnSql.Click += btnSql_Click;
            // 
            // DentitekDeploymentSchedulerGui
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 858);
            Controls.Add(gbTools);
            Controls.Add(gbFilterClinic);
            Controls.Add(btnGeneerateSchedule);
            Controls.Add(btnEditGroup);
            Controls.Add(pbConnectedBD);
            Controls.Add(pbConnectedAws);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnAddSchedule);
            Controls.Add(label3);
            Controls.Add(lvS3VersionBucket);
            Controls.Add(btnS3VersionList);
            Controls.Add(label4);
            Controls.Add(lvDeploymentSchedule);
            Controls.Add(lblClinicCount);
            Controls.Add(btnEditSchedule);
            Controls.Add(btnEdit);
            Controls.Add(lvClinicInfo);
            Controls.Add(btnConnect);
            Controls.Add(label1);
            Controls.Add(lvGroupAndClinic);
            Controls.Add(gbEnv);
            Name = "DentitekDeploymentSchedulerGui";
            Text = "Dentitek Deployment Scheduler";
            Shown += DentitekDeploymentScedulerGui_Shown;
            Resize += DentitekDeploymentSchedulerGui_Resize;
            ((System.ComponentModel.ISupportInitialize)pbConnectedAws).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbConnectedBD).EndInit();
            gbFilterClinic.ResumeLayout(false);
            gbFilterClinic.PerformLayout();
            gbEnv.ResumeLayout(false);
            gbEnv.PerformLayout();
            MenuContextualClinic.ResumeLayout(false);
            gbTools.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvGroupAndClinic;
        private Label label1;
        private Button btnConnect;
        private ColumnHeader ColName;
        private ColumnHeader ColVersion;
        private ColumnHeader IdGroup;
        private ListView lvClinicInfo;
        private ColumnHeader IdClinic;
        private ColumnHeader Env;
        private ColumnHeader ClinicName;
        private ColumnHeader GroupName;
        private ColumnHeader GroupId;
        private ColumnHeader DeployedVersion;
        private ColumnHeader InstalledVersion;
        private ColumnHeader Uuid;
        private ColumnHeader Phone;
        private ColumnHeader Cellular;
        private ColumnHeader FalconInstalled;
        private ColumnHeader FalconChannel;
        private ColumnHeader VersionForced;
        private Button btnEdit;
        private RadioButton rbFilterByGroupeName;
        private RadioButton rbFilterByAll;
        private TextBox tbFilterByName;
        private Label lblClinicCount;
        private Label label4;
        private ListView lvDeploymentSchedule;
        private ColumnHeader StartDate;
        private ColumnHeader StartTime;
        private ColumnHeader DeploymentGroupName;
        private ColumnHeader DeploymentClinicName;
        private ColumnHeader DeploymentVersion;
        private ColumnHeader Status;
        private ColumnHeader ForceToVersion;
        private Button btnEditSchedule;
        private RadioButton rbForceToVersion;
        private RadioButton rbClinicName;
        private ComboBox cboForVersion;
        private RadioButton rbVersion;
        private Button btnS3VersionList;
        private ColumnHeader NomDentiste;
        private ListView lvS3VersionBucket;
        private Label label3;
        private ColumnHeader ColFolderName;
        private Button btnAddSchedule;
        private Label label5;
        private Label label6;
        private PictureBox pbConnectedAws;
        private PictureBox pbConnectedBD;
        private RadioButton rbFIlterByDentistName;
        private RadioButton rbFilterByCellOrPhone;
        private TextBox tbDentistName;
        private TextBox tbTelOrCel;
        private Button btnEditGroup;
        private Button btnGeneerateSchedule;
        private GroupBox gbFilterClinic;
        private GroupBox gbEnv;
        private RadioButton rbAll;
        private RadioButton rbDev;
        private RadioButton rbTest;
        private RadioButton rbProd;
        private RadioButton rbInactive;
        private RadioButton rbFIlterByDentalCorp;
        private ContextMenuStrip MenuContextualClinic;
        private ToolStripMenuItem MenuItemClinicEdit;
        private ToolStripMenuItem MenuItemFalconSynchroProgress;
        private ToolStripMenuItem MenuItemServicesLog;
        private ToolStripMenuItem MenuItemAgentsList;
        private ToolStripMenuItem MenuItemFalconSettings;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private RadioButton rbActive;
        private ColumnHeader Statut;
        private GroupBox gbTools;
        private Button btnSql;
    }
}
