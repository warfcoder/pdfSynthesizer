namespace PDFSynthesizer
{
    partial class Form1
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
            this.btnTogglePlay = new System.Windows.Forms.Button();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.lbxPages = new System.Windows.Forms.ListBox();
            this.pbSpeaking = new System.Windows.Forms.ProgressBar();
            this.rtbPage = new System.Windows.Forms.RichTextBox();
            this.btnResetSpeed = new System.Windows.Forms.Button();
            this.btnReduceSpeed = new System.Windows.Forms.Button();
            this.btnIncreaseSpeed = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtPDFFilePath = new System.Windows.Forms.TextBox();
            this.btnChoosePDF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShowPages = new System.Windows.Forms.CheckBox();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnReadFromCursor = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTogglePlay
            // 
            this.btnTogglePlay.Location = new System.Drawing.Point(212, 34);
            this.btnTogglePlay.Name = "btnTogglePlay";
            this.btnTogglePlay.Size = new System.Drawing.Size(125, 37);
            this.btnTogglePlay.TabIndex = 0;
            this.btnTogglePlay.Text = "Pause";
            this.btnTogglePlay.UseVisualStyleBackColor = true;
            this.btnTogglePlay.Click += new System.EventHandler(this.TogglePlaying);
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Location = new System.Drawing.Point(59, 36);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(92, 13);
            this.lblTotalPages.TabIndex = 2;
            this.lblTotalPages.Text = "#       Total Pages";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Location = new System.Drawing.Point(59, 53);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(104, 13);
            this.lblCurrentPage.TabIndex = 4;
            this.lblCurrentPage.Text = "Current Page#####";
            // 
            // lbxPages
            // 
            this.lbxPages.FormattingEnabled = true;
            this.lbxPages.Location = new System.Drawing.Point(638, 62);
            this.lbxPages.Name = "lbxPages";
            this.lbxPages.Size = new System.Drawing.Size(314, 589);
            this.lbxPages.TabIndex = 6;
            this.lbxPages.SelectedIndexChanged += new System.EventHandler(this.lbxPages_SelectedIndexChanged);
            // 
            // pbSpeaking
            // 
            this.pbSpeaking.Location = new System.Drawing.Point(6, 79);
            this.pbSpeaking.Name = "pbSpeaking";
            this.pbSpeaking.Size = new System.Drawing.Size(613, 12);
            this.pbSpeaking.TabIndex = 7;
            // 
            // rtbPage
            // 
            this.rtbPage.Location = new System.Drawing.Point(6, 97);
            this.rtbPage.Name = "rtbPage";
            this.rtbPage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbPage.Size = new System.Drawing.Size(613, 554);
            this.rtbPage.TabIndex = 8;
            this.rtbPage.Text = "";
            // 
            // btnResetSpeed
            // 
            this.btnResetSpeed.Location = new System.Drawing.Point(495, 49);
            this.btnResetSpeed.Name = "btnResetSpeed";
            this.btnResetSpeed.Size = new System.Drawing.Size(31, 24);
            this.btnResetSpeed.TabIndex = 9;
            this.btnResetSpeed.Text = "0";
            this.btnResetSpeed.UseVisualStyleBackColor = true;
            this.btnResetSpeed.Click += new System.EventHandler(this.btnChangeSpeed_Click);
            // 
            // btnReduceSpeed
            // 
            this.btnReduceSpeed.Location = new System.Drawing.Point(476, 49);
            this.btnReduceSpeed.Name = "btnReduceSpeed";
            this.btnReduceSpeed.Size = new System.Drawing.Size(18, 24);
            this.btnReduceSpeed.TabIndex = 11;
            this.btnReduceSpeed.Text = "<";
            this.btnReduceSpeed.UseVisualStyleBackColor = true;
            this.btnReduceSpeed.Click += new System.EventHandler(this.btnChangeSpeed_Click);
            // 
            // btnIncreaseSpeed
            // 
            this.btnIncreaseSpeed.Location = new System.Drawing.Point(528, 49);
            this.btnIncreaseSpeed.Name = "btnIncreaseSpeed";
            this.btnIncreaseSpeed.Size = new System.Drawing.Size(18, 24);
            this.btnIncreaseSpeed.TabIndex = 12;
            this.btnIncreaseSpeed.Text = ">";
            this.btnIncreaseSpeed.UseVisualStyleBackColor = true;
            this.btnIncreaseSpeed.Click += new System.EventHandler(this.btnChangeSpeed_Click);
            // 
            // txtPDFFilePath
            // 
            this.txtPDFFilePath.Location = new System.Drawing.Point(6, 6);
            this.txtPDFFilePath.Name = "txtPDFFilePath";
            this.txtPDFFilePath.Size = new System.Drawing.Size(543, 20);
            this.txtPDFFilePath.TabIndex = 13;
            this.txtPDFFilePath.Text = "D:\\My Documents\\Military Stuff\\SNCOA Course 14 - Distance\\Self Awareness\\SA04 Cri" +
    "tical Thinking.pdf";
            // 
            // btnChoosePDF
            // 
            this.btnChoosePDF.Location = new System.Drawing.Point(557, 4);
            this.btnChoosePDF.Name = "btnChoosePDF";
            this.btnChoosePDF.Size = new System.Drawing.Size(75, 23);
            this.btnChoosePDF.TabIndex = 14;
            this.btnChoosePDF.Text = "Choose PDF";
            this.btnChoosePDF.UseVisualStyleBackColor = true;
            this.btnChoosePDF.Click += new System.EventHandler(this.btnChoosePDF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Reading Rate";
            // 
            // chkShowPages
            // 
            this.chkShowPages.AutoSize = true;
            this.chkShowPages.Checked = true;
            this.chkShowPages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowPages.Location = new System.Drawing.Point(563, 40);
            this.chkShowPages.Name = "chkShowPages";
            this.chkShowPages.Size = new System.Drawing.Size(56, 30);
            this.chkShowPages.TabIndex = 16;
            this.chkShowPages.Text = "Show\r\nPages";
            this.chkShowPages.UseVisualStyleBackColor = true;
            this.chkShowPages.CheckedChanged += new System.EventHandler(this.chkShowPages_CheckedChanged);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(169, 49);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(18, 24);
            this.btnNextPage.TabIndex = 18;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Location = new System.Drawing.Point(35, 47);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(18, 24);
            this.btnPrevPage.TabIndex = 17;
            this.btnPrevPage.Text = "<";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnReadFromCursor
            // 
            this.btnReadFromCursor.Location = new System.Drawing.Point(364, 36);
            this.btnReadFromCursor.Name = "btnReadFromCursor";
            this.btnReadFromCursor.Size = new System.Drawing.Size(74, 37);
            this.btnReadFromCursor.TabIndex = 19;
            this.btnReadFromCursor.Text = "Read From Cursor";
            this.btnReadFromCursor.UseVisualStyleBackColor = true;
            this.btnReadFromCursor.Click += new System.EventHandler(this.btnReadFromCursor_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(696, 29);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(198, 23);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "Export to Sound Files";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 663);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnReadFromCursor);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.chkShowPages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChoosePDF);
            this.Controls.Add(this.txtPDFFilePath);
            this.Controls.Add(this.btnIncreaseSpeed);
            this.Controls.Add(this.btnReduceSpeed);
            this.Controls.Add(this.btnResetSpeed);
            this.Controls.Add(this.rtbPage);
            this.Controls.Add(this.pbSpeaking);
            this.Controls.Add(this.lbxPages);
            this.Controls.Add(this.lblCurrentPage);
            this.Controls.Add(this.lblTotalPages);
            this.Controls.Add(this.btnTogglePlay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTogglePlay;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.ListBox lbxPages;
        private System.Windows.Forms.ProgressBar pbSpeaking;
        private System.Windows.Forms.RichTextBox rtbPage;
        private System.Windows.Forms.Button btnResetSpeed;
        private System.Windows.Forms.Button btnReduceSpeed;
        private System.Windows.Forms.Button btnIncreaseSpeed;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtPDFFilePath;
        private System.Windows.Forms.Button btnChoosePDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShowPages;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnReadFromCursor;
        private System.Windows.Forms.Button btnExport;
    }
}

