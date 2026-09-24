namespace PDFCutter
{
    partial class MergeForm
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
            this.groupBoxFiles = new System.Windows.Forms.GroupBox();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.chkSameFolder = new System.Windows.Forms.CheckBox();
            this.btnSelectMergeOutput = new System.Windows.Forms.Button();
            this.txtMergeOutput = new System.Windows.Forms.TextBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnCloseMerge = new System.Windows.Forms.Button();
            this.groupBoxFiles.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.SuspendLayout();
            //
            // groupBoxFiles
            //
            this.groupBoxFiles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxFiles.Controls.Add(this.btnClearList);
            this.groupBoxFiles.Controls.Add(this.btnMoveDown);
            this.groupBoxFiles.Controls.Add(this.btnMoveUp);
            this.groupBoxFiles.Controls.Add(this.btnRemoveFile);
            this.groupBoxFiles.Controls.Add(this.btnAddFiles);
            this.groupBoxFiles.Controls.Add(this.lstFiles);
            this.groupBoxFiles.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxFiles.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFiles.Name = "groupBoxFiles";
            this.groupBoxFiles.Padding = new System.Windows.Forms.Padding(8);
            this.groupBoxFiles.Size = new System.Drawing.Size(476, 300);
            this.groupBoxFiles.TabIndex = 0;
            this.groupBoxFiles.TabStop = false;
            this.groupBoxFiles.Text = "PDF 檔案清單（依合併順序排列）";
            //
            // lstFiles
            //
            this.lstFiles.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 25;
            this.lstFiles.Location = new System.Drawing.Point(8, 30);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(340, 254);
            this.lstFiles.TabIndex = 0;
            //
            // btnAddFiles
            //
            this.btnAddFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddFiles.FlatAppearance.BorderSize = 0;
            this.btnAddFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFiles.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddFiles.ForeColor = System.Drawing.Color.White;
            this.btnAddFiles.Location = new System.Drawing.Point(356, 30);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(112, 40);
            this.btnAddFiles.TabIndex = 1;
            this.btnAddFiles.Text = "新增檔案...";
            this.btnAddFiles.UseVisualStyleBackColor = false;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            //
            // btnRemoveFile
            //
            this.btnRemoveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnRemoveFile.FlatAppearance.BorderSize = 0;
            this.btnRemoveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFile.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveFile.ForeColor = System.Drawing.Color.White;
            this.btnRemoveFile.Location = new System.Drawing.Point(356, 78);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(112, 40);
            this.btnRemoveFile.TabIndex = 2;
            this.btnRemoveFile.Text = "移除";
            this.btnRemoveFile.UseVisualStyleBackColor = false;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            //
            // btnMoveUp
            //
            this.btnMoveUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnMoveUp.FlatAppearance.BorderSize = 0;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMoveUp.ForeColor = System.Drawing.Color.White;
            this.btnMoveUp.Location = new System.Drawing.Point(356, 126);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(112, 40);
            this.btnMoveUp.TabIndex = 3;
            this.btnMoveUp.Text = "上移";
            this.btnMoveUp.UseVisualStyleBackColor = false;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            //
            // btnMoveDown
            //
            this.btnMoveDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnMoveDown.FlatAppearance.BorderSize = 0;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMoveDown.ForeColor = System.Drawing.Color.White;
            this.btnMoveDown.Location = new System.Drawing.Point(356, 174);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(112, 40);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.Text = "下移";
            this.btnMoveDown.UseVisualStyleBackColor = false;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            //
            // btnClearList
            //
            this.btnClearList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnClearList.FlatAppearance.BorderSize = 0;
            this.btnClearList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearList.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearList.ForeColor = System.Drawing.Color.White;
            this.btnClearList.Location = new System.Drawing.Point(356, 222);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(112, 40);
            this.btnClearList.TabIndex = 5;
            this.btnClearList.Text = "清除全部";
            this.btnClearList.UseVisualStyleBackColor = false;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            //
            // groupBoxOutput
            //
            this.groupBoxOutput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxOutput.Controls.Add(this.chkSameFolder);
            this.groupBoxOutput.Controls.Add(this.btnSelectMergeOutput);
            this.groupBoxOutput.Controls.Add(this.txtMergeOutput);
            this.groupBoxOutput.Controls.Add(this.labelOutput);
            this.groupBoxOutput.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxOutput.Location = new System.Drawing.Point(12, 324);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Padding = new System.Windows.Forms.Padding(8);
            this.groupBoxOutput.Size = new System.Drawing.Size(476, 90);
            this.groupBoxOutput.TabIndex = 1;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "輸出設定";
            //
            // labelOutput
            //
            this.labelOutput.AutoSize = true;
            this.labelOutput.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelOutput.Location = new System.Drawing.Point(6, 40);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(77, 20);
            this.labelOutput.TabIndex = 0;
            this.labelOutput.Text = "儲存位置：";
            //
            // txtMergeOutput
            //
            this.txtMergeOutput.BackColor = System.Drawing.Color.White;
            this.txtMergeOutput.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMergeOutput.Location = new System.Drawing.Point(89, 37);
            this.txtMergeOutput.Name = "txtMergeOutput";
            this.txtMergeOutput.ReadOnly = true;
            this.txtMergeOutput.Size = new System.Drawing.Size(280, 28);
            this.txtMergeOutput.TabIndex = 1;
            //
            // btnSelectMergeOutput
            //
            this.btnSelectMergeOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSelectMergeOutput.Enabled = false;
            this.btnSelectMergeOutput.FlatAppearance.BorderSize = 0;
            this.btnSelectMergeOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectMergeOutput.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSelectMergeOutput.ForeColor = System.Drawing.Color.White;
            this.btnSelectMergeOutput.Location = new System.Drawing.Point(379, 35);
            this.btnSelectMergeOutput.Name = "btnSelectMergeOutput";
            this.btnSelectMergeOutput.Size = new System.Drawing.Size(85, 32);
            this.btnSelectMergeOutput.TabIndex = 2;
            this.btnSelectMergeOutput.Text = "選擇位置";
            this.btnSelectMergeOutput.UseVisualStyleBackColor = false;
            this.btnSelectMergeOutput.Click += new System.EventHandler(this.btnSelectMergeOutput_Click);
            //
            // chkSameFolder
            //
            this.chkSameFolder.AutoSize = true;
            this.chkSameFolder.Checked = true;
            this.chkSameFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSameFolder.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkSameFolder.Location = new System.Drawing.Point(89, 60);
            this.chkSameFolder.Name = "chkSameFolder";
            this.chkSameFolder.Size = new System.Drawing.Size(172, 24);
            this.chkSameFolder.TabIndex = 3;
            this.chkSameFolder.Text = "與輸入檔案同資料夾";
            this.chkSameFolder.UseVisualStyleBackColor = true;
            this.chkSameFolder.CheckedChanged += new System.EventHandler(this.chkSameFolder_CheckedChanged);
            //
            // btnMerge
            //
            this.btnMerge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnMerge.FlatAppearance.BorderSize = 0;
            this.btnMerge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMerge.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMerge.ForeColor = System.Drawing.Color.White;
            this.btnMerge.Location = new System.Drawing.Point(12, 426);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(226, 40);
            this.btnMerge.TabIndex = 2;
            this.btnMerge.Text = "開始合併";
            this.btnMerge.UseVisualStyleBackColor = false;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            //
            // btnCloseMerge
            //
            this.btnCloseMerge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnCloseMerge.FlatAppearance.BorderSize = 0;
            this.btnCloseMerge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseMerge.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCloseMerge.ForeColor = System.Drawing.Color.White;
            this.btnCloseMerge.Location = new System.Drawing.Point(250, 426);
            this.btnCloseMerge.Name = "btnCloseMerge";
            this.btnCloseMerge.Size = new System.Drawing.Size(238, 40);
            this.btnCloseMerge.TabIndex = 3;
            this.btnCloseMerge.Text = "關閉";
            this.btnCloseMerge.UseVisualStyleBackColor = false;
            this.btnCloseMerge.Click += new System.EventHandler(this.btnCloseMerge_Click);
            //
            // MergeForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 478);
            this.Controls.Add(this.btnCloseMerge);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MergeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "合併 PDF 檔案";
            this.groupBoxFiles.ResumeLayout(false);
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxFiles;
        private ListBox lstFiles;
        private Button btnAddFiles;
        private Button btnRemoveFile;
        private Button btnMoveUp;
        private Button btnMoveDown;
        private Button btnClearList;
        private GroupBox groupBoxOutput;
        private Label labelOutput;
        private TextBox txtMergeOutput;
        private CheckBox chkSameFolder;
        private Button btnSelectMergeOutput;
        private Button btnMerge;
        private Button btnCloseMerge;
    }
}
