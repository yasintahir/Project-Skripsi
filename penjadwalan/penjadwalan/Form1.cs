using penjadwalan.model;
using penjadwalan.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace penjadwalan
{
    public partial class Form1 : Form
    {
        private kon sql = new kon();
        public GLobalSolusi GlobalJadwal= new GLobalSolusi();
        public Dispatch dom_solusi = new Dispatch();
        public movns optimasi;
        public int LokalPinalti,GlobalPinalti;
        public solusi TempIntesifcate = new solusi();
        private Thread AlgoThread;
        public DataTable Log = new DataTable();
        public DataRow Row;
        private bool op = false;
        public Form1()
        {

            InitializeComponent();
            optimasi = new movns(this);
            initUI();
            Log.Columns.Add(new DataColumn() { ColumnName = "Status" });
            Log.Columns.Add(new DataColumn() { ColumnName = "Keterangan" });
           // MessageBox.Show(GlobalJadwal.GlobalSolusi[10].Solusi.Count().ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = sql.data_mengajar().DefaultView;

            
        }

        private void runAlgo()
        {
            LoadAlgo();
            var bw = new BackgroundWorker();
            bw.DoWork += (sender, args) =>
            {
                int done = 0;
                int shuffle = 0;
                while (done < GlobalJadwal.GlobalSolusi.Count)
                {
                    Row = Log.NewRow(); Row["Status"] = "Waktu"; Row["Keterangan"] = "Cek Penalti";
                    Log.Rows.Add(Row);
                    LokalPinalti = optimasi.local_pinalti(GlobalJadwal.GlobalSolusi[done]);
                    Row = Log.NewRow();Row["Status"]="Lokal Penalti";Row["Keterangan"]="Lokal Penalti : "+LokalPinalti;
                    Log.Rows.Add(Row);
                    GlobalPinalti = optimasi.global_pinalti(GlobalJadwal, done);
                    Row = Log.NewRow(); Row["Status"] = "Global Penalti"; Row["Keterangan"] = "Global Penalti : " + GlobalPinalti;
                    Log.Rows.Add(Row);
                    if (GlobalPinalti == 0 && LokalPinalti == 0)
                    {
                        Row = Log.NewRow(); Row["Status"] = "Optimal"; Row["Keterangan"] = "Kelas : " + GlobalJadwal.GlobalSolusi[done].Kelas;
                        Log.Rows.Add(Row);
                        done++;
                        double x = (done * 1.00 / GlobalJadwal.GlobalSolusi.Count * 1.00) * 100.00;
                        x = Math.Floor(x);
                        progress_loading.Invoke((MethodInvoker)(() => progress_loading.Text = x + "%"));
                        loading.Invoke((MethodInvoker)(() => loading.Value = int.Parse(x.ToString())));
                        shuffle = 0;
                    }
                    else
                    {
                        Row = Log.NewRow(); Row["Status"] = "Proses"; Row["Keterangan"] = "Interchanging";
                        Log.Rows.Add(Row);
                        GlobalJadwal = optimasi.interchanging(GlobalJadwal, done);
                        Row = Log.NewRow(); Row["Status"] = "Waktu"; Row["Keterangan"] = "Cek Penalti";
                        Log.Rows.Add(Row);
                        LokalPinalti = optimasi.local_pinalti(GlobalJadwal.GlobalSolusi[done]);
                        Row = Log.NewRow(); Row["Status"] = "Lokal Penalti"; Row["Keterangan"] = "Lokal Penalti : " + LokalPinalti;
                        Log.Rows.Add(Row);
                        GlobalPinalti = optimasi.global_pinalti(GlobalJadwal, done);
                        Row = Log.NewRow(); Row["Status"] = "Global Penalti"; Row["Keterangan"] = "Global Penalti : " + GlobalPinalti;
                        Log.Rows.Add(Row);
                        if (GlobalPinalti > 0 || LokalPinalti > 0)
                        {
                            Row = Log.NewRow(); Row["Status"] = "Proses"; Row["Keterangan"] = "Insertion";
                            Log.Rows.Add(Row);
                            GlobalJadwal.GlobalSolusi[done] = optimasi.insertion(GlobalJadwal.GlobalSolusi[done]);
                            
                                Row = Log.NewRow(); Row["Status"] = "Proses"; Row["Keterangan"] = "Intensifikasi";
                                Log.Rows.Add(Row);
                                GlobalJadwal = optimasi.intensifikasi(GlobalJadwal, done);
                                shuffle++;
                            
                        }
                        else
                        {
                            done++;
                            double x = (done * 1.00 / GlobalJadwal.GlobalSolusi.Count * 1.00) * 100.00;
                            x = Math.Floor(x);
                            progress_loading.Invoke((MethodInvoker)(() => progress_loading.Text = x + "%"));
                            loading.Invoke((MethodInvoker)(() => loading.Value = int.Parse(x.ToString())));
                            shuffle = 0;
                        }

                    }
                    if (done < GlobalJadwal.GlobalSolusi.Count)
                    {
                        ErrorLbl.Invoke((MethodInvoker)(() => ErrorLbl.Text = GlobalJadwal.GlobalSolusi[done].Kelas + " Lokal Penalti: " + LokalPinalti.ToString()));
                        GlobalErrorLbl.Invoke((MethodInvoker)(() => GlobalErrorLbl.Text = GlobalJadwal.GlobalSolusi[done].Kelas + " Global Penalti: " + GlobalPinalti.ToString() + done.ToString()));
                    }
                    if (shuffle > 500)
                    {
                        if (shuffle < 3 && done > 0)
                        {
                            done -= 1;
                        }
                        else if (done >= 3)
                        {
                            done -= 2;
                        }
                        double x = (done * 1.00 / GlobalJadwal.GlobalSolusi.Count * 1.00) * 100.00;
                        x = Math.Floor(x);
                        progress_loading.Invoke((MethodInvoker)(() => progress_loading.Text = x + "%"));
                        loading.Invoke((MethodInvoker)(() => loading.Value = int.Parse(x.ToString())));
                        shuffle = 0;
                        Row = Log.NewRow(); Row["Status"] = "Proses"; Row["Keterangan"] = "Insertion";
                        Log.Rows.Add(Row);
                        GlobalJadwal.GlobalSolusi[done] = optimasi.insertion(GlobalJadwal.GlobalSolusi[done]);
                        Row = Log.NewRow(); Row["Status"] = "Proses"; Row["Keterangan"] = "Intensifikasi";
                        Log.Rows.Add(Row);
                        GlobalJadwal = optimasi.intensifikasi(GlobalJadwal, done);
                        shuffle++;
                    }

                    Thread.Sleep(200);
                }
            };
            bw.RunWorkerCompleted += (sender, args) =>
            {

                hasiljadwal x = new hasiljadwal(this);
                op = true;
                x.Show();
                this.Close();
            };

            bw.RunWorkerAsync();
        }

        private void runThread()
        {
            AlgoThread = new Thread(new ThreadStart(runAlgo));
            AlgoThread.Priority = ThreadPriority.Normal;
            AlgoThread.Start();
        }
        private  void init_golobal_solusi()
        {
            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "Memulai inisial solusi";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            //agro
            //12 agro
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Agro Bisnis", Kelas = "12 AGRO A", Tingkat = 3, Visit = false }));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Agro Bisnis", Kelas = "12 AGRO B", Tingkat = 3, Visit = false }));
            //11 agro
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Agro Bisnis", Kelas = "11 AGRO A", Tingkat = 2, Visit = false }));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Agro Bisnis", Kelas = "11 AGRO B", Tingkat = 2, Visit = false }));
            //10 agro
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Agro Bisnis", Kelas = "10 AGRO A", Tingkat = 1, Visit = false }));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Agro Bisnis", Kelas = "10 AGRO B", Tingkat = 1, Visit = false }));

            //////pm
            ////12 PM
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "12 PM A", Tingkat = 3, Visit = false }));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "12 PM B", Tingkat = 3, Visit = false }));
            ////11 PM
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "11 PM A", Tingkat = 2, Visit = false }));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "11 PM B", Tingkat = 2, Visit = false }));
            ////10 PM
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "10 PM A", Tingkat = 1, Visit = false }));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "10 PM B", Tingkat = 1, Visit = false }));

            ////TKJ
            ////12 TKJ
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "12 TKJ A", Tingkat = 3, Visit = false }));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "12 TKJ B", Tingkat = 3, Visit = false }));
            ////11 TKJ
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "11 TKJ A", Tingkat = 2, Visit = false }));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "11 TKJ B", Tingkat = 2, Visit = false }));
            ////10 TKJ
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "10 TKJ A", Tingkat = 1, Visit = false }));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "10 TKJ B", Tingkat = 1, Visit = false }));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "10 TKJ K", Tingkat = 1, Visit = false }));

            ////RPL
            ////12 RPL
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "12 RPL A", Tingkat = 3, Visit = false }));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "12 RPL B", Tingkat = 3, Visit = false }));
            ////11 PM
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "11 RPL A", Tingkat = 2, Visit = false }));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "11 RPL B", Tingkat = 2, Visit = false }));
            ////10 PM
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "10 RPL A", Tingkat = 1, Visit = false }));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "10 RPL B", Tingkat = 1, Visit = false }));

            ////KI
            ////11 PM
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Kimia Industri", Kelas = "11 KI A", Tingkat = 2, Visit = false}));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Kimia Industri", Kelas = "11 KI B", Tingkat = 2, Visit = false}));
            ////10 PM
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Kimia Industri", Kelas = "10 KI A", Tingkat = 1, Visit = false}));
            //GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Kimia Industri", Kelas = "10 KI B", Tingkat = 1, Visit = false }));

            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "Dispatch 12 Agro A";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            GlobalJadwal.GlobalSolusi[0].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[0].Solusi, sql.data_mengajar(3, 1, "12 AGRO A", "NEWID()"),LoadLog,Log);
            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "selesai Dispatch 12 Agro A";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            Thread.Sleep(500);
            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "Dispatch 12 Agro B";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            GlobalJadwal.GlobalSolusi[1].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[1].Solusi, sql.data_mengajar(3, 1, "12 AGRO B", "detail_mtp.sks asc"),LoadLog,Log);
            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "selesai Dispatch 12 Agro B";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            Thread.Sleep(500);

            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "Dispatch 11 Agro A";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            GlobalJadwal.GlobalSolusi[2].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[2].Solusi, sql.data_mengajar(2, 1, "11 AGRO A", "guru.nama_guru desc"),LoadLog,Log);
            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "selesai Dispatch 1a Agro A";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            Thread.Sleep(500);

            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "Dispatch 11 Agro B";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            GlobalJadwal.GlobalSolusi[3].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[3].Solusi, sql.data_mengajar(2, 1, "11 AGRO B", "mata_pelajaran.mata_pelajaran asc"),LoadLog,Log);
            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "selesai Dispatch 1a Agro A";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            Thread.Sleep(500);

            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "Dispatch 10 Agro A";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            GlobalJadwal.GlobalSolusi[4].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[4].Solusi, sql.data_mengajar(1, 1, "10 AGRO A", "NEWID()"),LoadLog,Log);
            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "selesai Dispatch 10 Agro A";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            Thread.Sleep(500);

            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "Dispatch 10 Agro B";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            GlobalJadwal.GlobalSolusi[5].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[5].Solusi, sql.data_mengajar(1, 1, "10 AGRO B", "detail_mtp.sks asc"),LoadLog,Log);
            Row = Log.NewRow(); Row["Status"] = "Simple Dispatch"; Row["Keterangan"] = "selesai Dispatch 10 Agro B";
            Log.Rows.Add(Row);
            LoadLog.Invoke((MethodInvoker)(() => LoadLog.DataSource = Log));
            Thread.Sleep(500);


            //GlobalJadwal.GlobalSolusi[6].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[6].Solusi, sql.data_mengajar(3, 3, "12 PM A", "guru.nama_guru desc"));
            //GlobalJadwal.GlobalSolusi[7].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[7].Solusi, sql.data_mengajar(3, 3, "12 PM B", "mata_pelajaran.mata_pelajaran asc"));
            //GlobalJadwal.GlobalSolusi[8].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[8].Solusi, sql.data_mengajar(2, 3, "11 PM A", "detail_mtp.sks desc"));
            //GlobalJadwal.GlobalSolusi[9].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[9].Solusi, sql.data_mengajar(2, 3, "11 PM B", "NEWID()"));
            //GlobalJadwal.GlobalSolusi[10].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[10].Solusi, sql.data_mengajar(1, 3, "10 PM A", "guru.nama_guru desc"));
            //GlobalJadwal.GlobalSolusi[11].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[11].Solusi, sql.data_mengajar(1, 3, "10 PM B", "mata_pelajaran.mata_pelajaran asc"));

            //GlobalJadwal.GlobalSolusi[12].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[12].Solusi, sql.data_mengajar(3, 5, "12 TKJ A", "detail_mtp.sks desc"));
            //GlobalJadwal.GlobalSolusi[13].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[13].Solusi, sql.data_mengajar(3, 5, "12 TKJ B", "detail_mtp.sks asc"));
            //GlobalJadwal.GlobalSolusi[14].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[14].Solusi, sql.data_mengajar(2, 5, "11 TKJ A", "detail_mtp.sks desc"));
            //GlobalJadwal.GlobalSolusi[15].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[15].Solusi, sql.data_mengajar(2, 5, "11 TKJ B", "detail_mtp.sks asc"));
            //GlobalJadwal.GlobalSolusi[16].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[16].Solusi, sql.data_mengajar(1, 5, "10 TKJ A", "detail_mtp.sks desc"));
            //GlobalJadwal.GlobalSolusi[17].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[17].Solusi, sql.data_mengajar(1, 5, "10 TKJ B", "detail_mtp.sks asc"));
            //GlobalJadwal.GlobalSolusi[18].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[18].Solusi, sql.data_mengajar(1, 5, "10 TKJ k", "detail_mtp.sks desc"));

            //GlobalJadwal.GlobalSolusi[19].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[19].Solusi, sql.data_mengajar(3, 4, "12 RPL A", "detail_mtp.sks desc"));
            //GlobalJadwal.GlobalSolusi[20].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[20].Solusi, sql.data_mengajar(3, 4, "12 RPL B", "detail_mtp.sks asc"));
            //GlobalJadwal.GlobalSolusi[21].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[21].Solusi, sql.data_mengajar(2, 4, "11 RPL A", "detail_mtp.sks desc"));
            //GlobalJadwal.GlobalSolusi[22].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[22].Solusi, sql.data_mengajar(2, 4, "11 RPL B", "detail_mtp.sks asc"));
            //GlobalJadwal.GlobalSolusi[23].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[23].Solusi, sql.data_mengajar(1, 4, "10 RPL A", "detail_mtp.sks desc"));
            //GlobalJadwal.GlobalSolusi[24].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[24].Solusi, sql.data_mengajar(1, 4, "10 RPL B", "detail_mtp.sks asc"));

            //GlobalJadwal.GlobalSolusi[25].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[25].Solusi, sql.data_mengajar(2, 2, "11 KI A", "rand()"));
            //GlobalJadwal.GlobalSolusi[26].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[26].Solusi, sql.data_mengajar(2, 2, "11 KI B", "rand()"));
            //GlobalJadwal.GlobalSolusi[27].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[27].Solusi, sql.data_mengajar(1, 2, "10 KI A", "rand()"));
            //GlobalJadwal.GlobalSolusi[28].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[28].Solusi, sql.data_mengajar(1, 2, "10 KI B", "rand()"));
        }


        public void initUI()
        {
            ProsesBtn.Visible = true;
            header_loading.Visible = false;
            progress_loading.Visible = false;
            progress_loading.Text = "0%";
            loading.Visible = false;
            loading.Value = 0;
        }

        public void LoadAlgo()
        {
            //ProsesBtn.Invoke((MethodInvoker)(() => ProsesBtn.Visible = false));
            header_loading.Invoke((MethodInvoker)(() => header_loading.Visible = true));
            progress_loading.Invoke((MethodInvoker)(()=> progress_loading.Visible = true));
            loading.Invoke((MethodInvoker)(()=>loading.Visible = true));
        }
        private void ProsesBtn_Click(object sender, EventArgs e)
        {

            init_golobal_solusi();
            runAlgo();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!op)
            {
                Application.Exit();
            }
        }

    }

}