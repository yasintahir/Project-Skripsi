namespace penjadwalan
{
    partial class hasiljadwal
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
            this.TabJadwal = new System.Windows.Forms.TabControl();
            this.JadwalKelas = new System.Windows.Forms.TabPage();
            this.JadwalGuru = new System.Windows.Forms.TabPage();
            this.LogJadwal = new System.Windows.Forms.TabPage();
            this.TingkatCmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.JurusanCmb = new System.Windows.Forms.ComboBox();
            this.KelasHeaderLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.KelasCmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PelajaranSenin = new System.Windows.Forms.DataGridView();
            this.PelajaranSelasa = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.PelajaranRabu = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.PelajaranSabtu = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.PelajaranJumat = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.PelajaranKamis = new System.Windows.Forms.DataGridView();
            this.Kamis = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LogProses = new System.Windows.Forms.DataGridView();
            this.TabJadwal.SuspendLayout();
            this.JadwalKelas.SuspendLayout();
            this.JadwalGuru.SuspendLayout();
            this.LogJadwal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranSenin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranSelasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranRabu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranSabtu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranJumat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranKamis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogProses)).BeginInit();
            this.SuspendLayout();
            // 
            // TabJadwal
            // 
            this.TabJadwal.Controls.Add(this.JadwalKelas);
            this.TabJadwal.Controls.Add(this.JadwalGuru);
            this.TabJadwal.Controls.Add(this.LogJadwal);
            this.TabJadwal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabJadwal.ItemSize = new System.Drawing.Size(90, 18);
            this.TabJadwal.Location = new System.Drawing.Point(2, 1);
            this.TabJadwal.Name = "TabJadwal";
            this.TabJadwal.SelectedIndex = 0;
            this.TabJadwal.Size = new System.Drawing.Size(1282, 560);
            this.TabJadwal.TabIndex = 0;
            // 
            // JadwalKelas
            // 
            this.JadwalKelas.AutoScroll = true;
            this.JadwalKelas.Controls.Add(this.PelajaranSabtu);
            this.JadwalKelas.Controls.Add(this.label7);
            this.JadwalKelas.Controls.Add(this.PelajaranJumat);
            this.JadwalKelas.Controls.Add(this.label8);
            this.JadwalKelas.Controls.Add(this.PelajaranKamis);
            this.JadwalKelas.Controls.Add(this.Kamis);
            this.JadwalKelas.Controls.Add(this.PelajaranRabu);
            this.JadwalKelas.Controls.Add(this.label6);
            this.JadwalKelas.Controls.Add(this.PelajaranSelasa);
            this.JadwalKelas.Controls.Add(this.label5);
            this.JadwalKelas.Controls.Add(this.PelajaranSenin);
            this.JadwalKelas.Controls.Add(this.label4);
            this.JadwalKelas.Controls.Add(this.label3);
            this.JadwalKelas.Controls.Add(this.KelasCmb);
            this.JadwalKelas.Controls.Add(this.KelasHeaderLbl);
            this.JadwalKelas.Controls.Add(this.label2);
            this.JadwalKelas.Controls.Add(this.JurusanCmb);
            this.JadwalKelas.Controls.Add(this.label1);
            this.JadwalKelas.Controls.Add(this.TingkatCmb);
            this.JadwalKelas.Location = new System.Drawing.Point(4, 22);
            this.JadwalKelas.Name = "JadwalKelas";
            this.JadwalKelas.Padding = new System.Windows.Forms.Padding(3);
            this.JadwalKelas.Size = new System.Drawing.Size(1274, 534);
            this.JadwalKelas.TabIndex = 1;
            this.JadwalKelas.Text = "Jadwal Belajar Murid";
            this.JadwalKelas.UseVisualStyleBackColor = true;
            // 
            // JadwalGuru
            // 
            this.JadwalGuru.Controls.Add(this.label9);
            this.JadwalGuru.Location = new System.Drawing.Point(4, 22);
            this.JadwalGuru.Name = "JadwalGuru";
            this.JadwalGuru.Size = new System.Drawing.Size(1274, 534);
            this.JadwalGuru.TabIndex = 2;
            this.JadwalGuru.Text = "Jadwal Mengajar Guru";
            this.JadwalGuru.UseVisualStyleBackColor = true;
            // 
            // LogJadwal
            // 
            this.LogJadwal.Controls.Add(this.LogProses);
            this.LogJadwal.Location = new System.Drawing.Point(4, 22);
            this.LogJadwal.Name = "LogJadwal";
            this.LogJadwal.Size = new System.Drawing.Size(1274, 534);
            this.LogJadwal.TabIndex = 3;
            this.LogJadwal.Text = "Log Proses";
            this.LogJadwal.UseVisualStyleBackColor = true;
            // 
            // TingkatCmb
            // 
            this.TingkatCmb.FormattingEnabled = true;
            this.TingkatCmb.Location = new System.Drawing.Point(135, 6);
            this.TingkatCmb.Name = "TingkatCmb";
            this.TingkatCmb.Size = new System.Drawing.Size(174, 23);
            this.TingkatCmb.TabIndex = 0;
            this.TingkatCmb.SelectedIndexChanged += new System.EventHandler(this.TingkatCmb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tingkat :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jurusan :";
            // 
            // JurusanCmb
            // 
            this.JurusanCmb.FormattingEnabled = true;
            this.JurusanCmb.Location = new System.Drawing.Point(466, 6);
            this.JurusanCmb.Name = "JurusanCmb";
            this.JurusanCmb.Size = new System.Drawing.Size(174, 23);
            this.JurusanCmb.TabIndex = 2;
            this.JurusanCmb.SelectedIndexChanged += new System.EventHandler(this.JurusanCmb_SelectedIndexChanged);
            // 
            // KelasHeaderLbl
            // 
            this.KelasHeaderLbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KelasHeaderLbl.Location = new System.Drawing.Point(0, 56);
            this.KelasHeaderLbl.Name = "KelasHeaderLbl";
            this.KelasHeaderLbl.Size = new System.Drawing.Size(1274, 31);
            this.KelasHeaderLbl.TabIndex = 4;
            this.KelasHeaderLbl.Text = "IX AGRO A";
            this.KelasHeaderLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(721, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kelas :";
            // 
            // KelasCmb
            // 
            this.KelasCmb.FormattingEnabled = true;
            this.KelasCmb.Location = new System.Drawing.Point(818, 6);
            this.KelasCmb.Name = "KelasCmb";
            this.KelasCmb.Size = new System.Drawing.Size(174, 23);
            this.KelasCmb.TabIndex = 5;
            this.KelasCmb.SelectedIndexChanged += new System.EventHandler(this.KelasCmb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Senin";
            // 
            // PelajaranSenin
            // 
            this.PelajaranSenin.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.PelajaranSenin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PelajaranSenin.Location = new System.Drawing.Point(7, 126);
            this.PelajaranSenin.Name = "PelajaranSenin";
            this.PelajaranSenin.Size = new System.Drawing.Size(366, 269);
            this.PelajaranSenin.TabIndex = 9;
            // 
            // PelajaranSelasa
            // 
            this.PelajaranSelasa.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.PelajaranSelasa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PelajaranSelasa.Location = new System.Drawing.Point(425, 126);
            this.PelajaranSelasa.Name = "PelajaranSelasa";
            this.PelajaranSelasa.Size = new System.Drawing.Size(402, 269);
            this.PelajaranSelasa.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(603, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Selasa";
            // 
            // PelajaranRabu
            // 
            this.PelajaranRabu.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.PelajaranRabu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PelajaranRabu.Location = new System.Drawing.Point(880, 126);
            this.PelajaranRabu.Name = "PelajaranRabu";
            this.PelajaranRabu.Size = new System.Drawing.Size(366, 269);
            this.PelajaranRabu.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1030, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Rabu";
            // 
            // PelajaranSabtu
            // 
            this.PelajaranSabtu.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.PelajaranSabtu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PelajaranSabtu.Location = new System.Drawing.Point(881, 487);
            this.PelajaranSabtu.Name = "PelajaranSabtu";
            this.PelajaranSabtu.Size = new System.Drawing.Size(366, 269);
            this.PelajaranSabtu.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1031, 460);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Sabtu";
            // 
            // PelajaranJumat
            // 
            this.PelajaranJumat.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.PelajaranJumat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PelajaranJumat.Location = new System.Drawing.Point(426, 487);
            this.PelajaranJumat.Name = "PelajaranJumat";
            this.PelajaranJumat.Size = new System.Drawing.Size(402, 269);
            this.PelajaranJumat.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(604, 460);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Jumat";
            // 
            // PelajaranKamis
            // 
            this.PelajaranKamis.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.PelajaranKamis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PelajaranKamis.Location = new System.Drawing.Point(7, 487);
            this.PelajaranKamis.Name = "PelajaranKamis";
            this.PelajaranKamis.Size = new System.Drawing.Size(366, 269);
            this.PelajaranKamis.TabIndex = 15;
            // 
            // Kamis
            // 
            this.Kamis.AutoSize = true;
            this.Kamis.Location = new System.Drawing.Point(125, 460);
            this.Kamis.Name = "Kamis";
            this.Kamis.Size = new System.Drawing.Size(41, 15);
            this.Kamis.TabIndex = 14;
            this.Kamis.Text = "Kamis";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(540, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Under Construction";
            // 
            // LogProses
            // 
            this.LogProses.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogProses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogProses.Location = new System.Drawing.Point(6, 3);
            this.LogProses.Name = "LogProses";
            this.LogProses.Size = new System.Drawing.Size(1260, 523);
            this.LogProses.TabIndex = 0;
            // 
            // hasiljadwal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.TabJadwal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "hasiljadwal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "hasiljadwal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.hasiljadwal_FormClosing);
            this.TabJadwal.ResumeLayout(false);
            this.JadwalKelas.ResumeLayout(false);
            this.JadwalKelas.PerformLayout();
            this.JadwalGuru.ResumeLayout(false);
            this.JadwalGuru.PerformLayout();
            this.LogJadwal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranSenin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranSelasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranRabu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranSabtu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranJumat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PelajaranKamis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogProses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabJadwal;
        private System.Windows.Forms.TabPage JadwalKelas;
        private System.Windows.Forms.DataGridView PelajaranSabtu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView PelajaranJumat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView PelajaranKamis;
        private System.Windows.Forms.Label Kamis;
        private System.Windows.Forms.DataGridView PelajaranRabu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView PelajaranSelasa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView PelajaranSenin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox KelasCmb;
        private System.Windows.Forms.Label KelasHeaderLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox JurusanCmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TingkatCmb;
        private System.Windows.Forms.TabPage JadwalGuru;
        private System.Windows.Forms.TabPage LogJadwal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView LogProses;
    }
}