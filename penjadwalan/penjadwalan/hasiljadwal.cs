using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using penjadwalan.model;

namespace penjadwalan
{
    public partial class hasiljadwal : Form
    {

        private kon sql = new kon();
        private Form1 parent;
        public hasiljadwal(Form1 x)
        {
            InitializeComponent();
            parent = x;
            LogProses.DataSource = parent.Log.DefaultView;
            LogProses.Columns[0].Width = 400;
            LogProses.Columns[1].Width = 900;
            inti_tingkat();
        }

        private void inti_tingkat()
        {
            string com = "select kode_tingkat, tingkat from tingkat order by kode_tingkat desc";
            TingkatCmb.DataSource = sql.tampil_data(com);
            TingkatCmb.DisplayMember = "tingkat";
            TingkatCmb.ValueMember = "kode_tingkat";
        }

        private void TingkatCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> x = new List<string>();
            DataRowView temp;
            temp = TingkatCmb.Items[TingkatCmb.SelectedIndex] as DataRowView;
            var p = parent.GlobalJadwal.GlobalSolusi.Where(t => t.Tingkat == int.Parse(temp.Row.ItemArray[0].ToString())).Select( j => j.Jurusan).Distinct();
            foreach (var y in p)
            {
                x.Add(y.ToString());
            }
            JurusanCmb.DataSource = x;
            JurusanCmb.DisplayMember = "Jurusan";
        }

        private void reset()
        {
            KelasCmb.Enabled = false;
            //data pelajaran;
        }

        private void JurusanCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> x = new List<string>();
            DataRowView temp;
            temp = TingkatCmb.Items[TingkatCmb.SelectedIndex] as DataRowView;
            var p = parent.GlobalJadwal.GlobalSolusi.Where(t => t.Tingkat == int.Parse(temp.Row.ItemArray[0].ToString()) && t.Jurusan == JurusanCmb.SelectedItem.ToString()).Select(j => j.Kelas).Distinct();
            foreach (var y in p)
            {
                x.Add(y.ToString());
            }
           KelasCmb.DataSource = x;
            KelasCmb.DisplayMember = "Jurusan";
        }

        public void susun_jadwal()
        {
            #region jamBelajar
            List<string> jam = new List<string>();
            jam.Add("07.00-07.45");
            jam.Add("07.45-08.30");
            jam.Add("08.30-09.15");
            jam.Add("09.15-10.00");
            jam.Add("10.00-10.15");
            jam.Add("10.15-11.00");
            jam.Add("11.00-11.45");
            jam.Add("11.45-12.15");
            jam.Add("12.15-13.00");
            jam.Add("13.00-13.45");
            jam.Add("13.45-14.30");
            jam.Add("14.30-15.15");
            jam.Add("15.15 -16.00");
            #endregion
            DataRowView temp;
            temp = TingkatCmb.Items[TingkatCmb.SelectedIndex] as DataRowView;
            var p = parent.GlobalJadwal.GlobalSolusi.Where(t => t.Tingkat == int.Parse(temp.Row.ItemArray[0].ToString()) && t.Jurusan == JurusanCmb.SelectedItem.ToString() && t.Kelas == KelasCmb.SelectedItem.ToString()).Select(jad => jad.Solusi);

            List<jadwal> ajar = new List<jadwal>();
            foreach (var jar in p)
            {
                ajar.AddRange(jar);
            }
            DataSet DataTemp = new DataSet();
            DataTable tabel = new DataTable();
            tabel.Columns.Add(new DataColumn() { ColumnName = "Jam" });
            tabel.Columns.Add(new DataColumn() { ColumnName = "Mata Pelajaran" });
            tabel.Columns.Add(new DataColumn() { ColumnName = "Guru" });
            for (int i = 0; i < ajar.Count; i++)
            {
                int lim=0;
                if (i == 4)
                {
                    DataRow row = tabel.NewRow();
                    row["jam"] = jam[lim];
                    row["Mata Pelajaran"] = "Jumat Bersih";
                    row["Guru"] = "-";
                    tabel.Rows.Add(row);
                    lim++;
                }

                if (i == 0)
                {
                    DataRow row = tabel.NewRow();
                    row["jam"] = jam[lim];
                    row["Mata Pelajaran"] = "Upacara";
                    row["Guru"] = "-";
                    tabel.Rows.Add(row);
                    lim++;
                }
                for (int j = 0; j < ajar[i].Mengajar.Count; j++)
                {
                    int CounterPel = 0;
                    while (CounterPel < ajar[i].Mengajar[j].Sks)
                    {
                        if (lim == 4 || lim == 6)
                        {
                            DataRow row = tabel.NewRow();
                            row["jam"] = jam[lim];
                            row["Mata Pelajaran"] = "Istirahat";
                            row["Guru"] = "-";
                            tabel.Rows.Add(row);
                            lim++;
                        }
                        else
                        {
                            DataRow row = tabel.NewRow();
                            row["jam"] = jam[lim];
                            row["Mata Pelajaran"] = ajar[i].Mengajar[j].MataPelajaran;
                            row["Guru"] = ajar[i].Mengajar[j].Guru;
                            tabel.Rows.Add(row);
                            lim++;
                            CounterPel++;
                        }
                    }
                }
                DataTemp.Tables.Add(tabel);
                tabel = new DataTable();
                tabel.Columns.Add(new DataColumn() { ColumnName = "Jam" });
                tabel.Columns.Add(new DataColumn() { ColumnName = "Mata Pelajaran" });
                tabel.Columns.Add(new DataColumn() { ColumnName = "Guru" });
            }
            PelajaranSenin.DataSource = DataTemp.Tables[0].DefaultView;
            PelajaranSelasa.DataSource = DataTemp.Tables[1].DefaultView;
            PelajaranRabu.DataSource = DataTemp.Tables[2].DefaultView;
            PelajaranKamis.DataSource = DataTemp.Tables[3].DefaultView;
            PelajaranJumat.DataSource = DataTemp.Tables[4].DefaultView;
            PelajaranSabtu.DataSource = DataTemp.Tables[5].DefaultView;
        }

        

        private void KelasCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            KelasHeaderLbl.Text = KelasCmb.SelectedItem as string;
            susun_jadwal();
        }

        private void hasiljadwal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
