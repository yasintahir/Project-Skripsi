namespace penjadwalan
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
            this.Header = new System.Windows.Forms.Label();
            this.loading = new System.Windows.Forms.ProgressBar();
            this.header_loading = new System.Windows.Forms.Label();
            this.progress_loading = new System.Windows.Forms.Label();
            this.ProsesBtn = new System.Windows.Forms.Button();
            this.ErrorLbl = new System.Windows.Forms.Label();
            this.GlobalErrorLbl = new System.Windows.Forms.Label();
            this.LoadLog = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.LoadLog)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Header.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Header.Location = new System.Drawing.Point(65, 9);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(362, 33);
            this.Header.TabIndex = 0;
            this.Header.Text = "SMK Negeri 4 Pada Ngga Boleh";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loading
            // 
            this.loading.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.loading.Location = new System.Drawing.Point(12, 249);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(484, 23);
            this.loading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.loading.TabIndex = 1;
            this.loading.Value = 50;
            // 
            // header_loading
            // 
            this.header_loading.AutoSize = true;
            this.header_loading.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_loading.Location = new System.Drawing.Point(153, 203);
            this.header_loading.Name = "header_loading";
            this.header_loading.Size = new System.Drawing.Size(203, 15);
            this.header_loading.TabIndex = 2;
            this.header_loading.Text = "Sedang memproses Silahkan tunggu";
            // 
            // progress_loading
            // 
            this.progress_loading.AutoSize = true;
            this.progress_loading.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progress_loading.Location = new System.Drawing.Point(240, 231);
            this.progress_loading.Name = "progress_loading";
            this.progress_loading.Size = new System.Drawing.Size(30, 15);
            this.progress_loading.TabIndex = 3;
            this.progress_loading.Text = "10%";
            // 
            // ProsesBtn
            // 
            this.ProsesBtn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ProsesBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ProsesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProsesBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ProsesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProsesBtn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProsesBtn.Location = new System.Drawing.Point(12, 569);
            this.ProsesBtn.Name = "ProsesBtn";
            this.ProsesBtn.Size = new System.Drawing.Size(484, 52);
            this.ProsesBtn.TabIndex = 4;
            this.ProsesBtn.Text = "Proses";
            this.ProsesBtn.UseVisualStyleBackColor = false;
            this.ProsesBtn.Click += new System.EventHandler(this.ProsesBtn_Click);
            // 
            // ErrorLbl
            // 
            this.ErrorLbl.AutoSize = true;
            this.ErrorLbl.Location = new System.Drawing.Point(13, 279);
            this.ErrorLbl.Name = "ErrorLbl";
            this.ErrorLbl.Size = new System.Drawing.Size(0, 13);
            this.ErrorLbl.TabIndex = 5;
            // 
            // GlobalErrorLbl
            // 
            this.GlobalErrorLbl.AutoSize = true;
            this.GlobalErrorLbl.Location = new System.Drawing.Point(13, 306);
            this.GlobalErrorLbl.Name = "GlobalErrorLbl";
            this.GlobalErrorLbl.Size = new System.Drawing.Size(0, 13);
            this.GlobalErrorLbl.TabIndex = 6;
            // 
            // LoadLog
            // 
            this.LoadLog.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.LoadLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LoadLog.Location = new System.Drawing.Point(12, 346);
            this.LoadLog.Name = "LoadLog";
            this.LoadLog.Size = new System.Drawing.Size(484, 192);
            this.LoadLog.TabIndex = 7;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(508, 633);
            this.Controls.Add(this.LoadLog);
            this.Controls.Add(this.GlobalErrorLbl);
            this.Controls.Add(this.ErrorLbl);
            this.Controls.Add(this.ProsesBtn);
            this.Controls.Add(this.progress_loading);
            this.Controls.Add(this.header_loading);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.LoadLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.ProgressBar loading;
        private System.Windows.Forms.Label header_loading;
        private System.Windows.Forms.Label progress_loading;
        private System.Windows.Forms.Button ProsesBtn;
        public System.Windows.Forms.Label ErrorLbl;
        public System.Windows.Forms.Label GlobalErrorLbl;
        private System.Windows.Forms.DataGridView LoadLog;




    }
}

