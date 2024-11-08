namespace DeploymentScheduler
{
    partial class FrmEditGroup
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
            cboGroup = new ComboBox();
            cboVersion = new ComboBox();
            btnSave = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 20);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Groupe:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 57);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "Version:";
            // 
            // cboGroup
            // 
            cboGroup.FormattingEnabled = true;
            cboGroup.Location = new Point(96, 17);
            cboGroup.Name = "cboGroup";
            cboGroup.Size = new Size(137, 23);
            cboGroup.TabIndex = 2;
            cboGroup.SelectedIndexChanged += cboGroup_SelectedIndexChanged;
            // 
            // cboVersion
            // 
            cboVersion.FormattingEnabled = true;
            cboVersion.Location = new Point(96, 57);
            cboVersion.Name = "cboVersion";
            cboVersion.Size = new Size(137, 23);
            cboVersion.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(314, 124);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(395, 124);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FrmEditGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(478, 153);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(cboVersion);
            Controls.Add(cboGroup);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmEditGroup";
            Text = "Edition d'un groupe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cboGroup;
        private ComboBox cboVersion;
        private Button btnSave;
        private Button btnClose;
    }
}