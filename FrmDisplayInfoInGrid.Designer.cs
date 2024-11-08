namespace DeploymentScheduler
{
    partial class FrmDisplayInfoInGrid
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
            DgData = new DataGridView();
            BtnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)DgData).BeginInit();
            SuspendLayout();
            // 
            // DgData
            // 
            DgData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DgData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgData.Location = new Point(12, 5);
            DgData.Name = "DgData";
            DgData.Size = new Size(671, 426);
            DgData.TabIndex = 0;
            // 
            // BtnClose
            // 
            BtnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnClose.Location = new Point(617, 438);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(75, 23);
            BtnClose.TabIndex = 1;
            BtnClose.Text = "Close";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnClose_Click;
            // 
            // FrmDisplayInfoInGrid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnClose;
            ClientSize = new Size(695, 466);
            Controls.Add(BtnClose);
            Controls.Add(DgData);
            Name = "FrmDisplayInfoInGrid";
            Text = "FrmDisplayInfoInGrid";
            Resize += FrmDisplayInfoInGrid_Resize;
            ((System.ComponentModel.ISupportInitialize)DgData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgData;
        private Button BtnClose;
    }
}