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

namespace penjadwalan
{
    public partial class Form1 : Form
    {
        private kon sql = new kon();
        public GLobalSolusi GlobalJadwal= new GLobalSolusi();
        public Dispatch dom_solusi = new Dispatch();
        public Form1()
        {
            InitializeComponent();
            init_golobal_solusi();
            dataGridView1.DataSource = sql.data_mengajar(1,1,"10 AGRO A","desc").DefaultView;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = sql.data_mengajar().DefaultView;
        }

        private  void init_golobal_solusi()
        {
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

            //pm
            //12 PM
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "12 PM A", Tingkat = 3, Visit = false }));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "12 PM B", Tingkat = 3, Visit = false}));
            //11 PM
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "11 PM A", Tingkat = 2, Visit = false }));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "11 PM B", Tingkat = 2, Visit = false }));
            //10 PM
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "10 PM A", Tingkat = 1, Visit = false}));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Bisnis Manajemen", Kelas = "10 PM B", Tingkat = 1, Visit = false }));

            //TKJ
            //12 TKJ
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "12 TKJ A", Tingkat = 3 , Visit= false}));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "12 TKJ B", Tingkat = 3, Visit = false}));
            //11 TKJ
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "11 TKJ A", Tingkat = 2, Visit = false}));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "11 TKJ B", Tingkat = 2, Visit = false}));
            //10 TKJ
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "10 TKJ A", Tingkat = 1, Visit = false}));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "10 TKJ B", Tingkat = 1, Visit = false}));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Teknik Komputer & Jaringan", Kelas = "10 TKJ K", Tingkat = 1, Visit = false}));

            //RPL
            //12 RPL
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "12 RPL A", Tingkat = 3, Visit = false}));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "12 RPL B", Tingkat = 3, Visit = false}));
            //11 PM
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "11 RPL A", Tingkat = 2, Visit = false}));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "11 RPL B", Tingkat = 2, Visit = false}));
            //10 PM
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "10 RPL A", Tingkat = 1, Visit = false}));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Rekayasa Perangkat Lunak", Kelas = "10 RPL B", Tingkat = 1, Visit = false }));

            //KI
            //11 PM
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Kimia Industri", Kelas = "11 KI A", Tingkat = 2, Visit = false}));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Kimia Industri", Kelas = "11 KI B", Tingkat = 2, Visit = false}));
            //10 PM
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Kimia Industri", Kelas = "10 KI A", Tingkat = 1, Visit = false}));
            GlobalJadwal.GlobalSolusi.Add(dom_solusi.init_solusi(new solusi() { Jurusan = "Kimia Industri", Kelas = "10 KI B", Tingkat = 1, Visit = false }));


            GlobalJadwal.GlobalSolusi[0].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[0].Solusi, sql.data_mengajar(3, 1, "12 AGRO A", "RAND()"));
            GlobalJadwal.GlobalSolusi[1].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[1].Solusi, sql.data_mengajar(3, 1, "12 AGRO B", "rand()"));
            GlobalJadwal.GlobalSolusi[2].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[2].Solusi, sql.data_mengajar(2, 1, "11 AGRO A", "rand()"));
            GlobalJadwal.GlobalSolusi[3].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[3].Solusi, sql.data_mengajar(2, 1, "11 AGRO B", "rand()"));
            GlobalJadwal.GlobalSolusi[4].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[4].Solusi, sql.data_mengajar(1, 1, "10 AGRO A", "rand()"));
            GlobalJadwal.GlobalSolusi[5].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[5].Solusi, sql.data_mengajar(1, 1, "10 AGRO B", "rand()"));

            GlobalJadwal.GlobalSolusi[6].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[6].Solusi, sql.data_mengajar(3, 3, "12 PM A", "rand()"));
            GlobalJadwal.GlobalSolusi[7].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[7].Solusi, sql.data_mengajar(3, 3, "12 PM B", "rand()"));
            GlobalJadwal.GlobalSolusi[8].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[8].Solusi, sql.data_mengajar(2, 3, "11 PM A", "rand()"));
            GlobalJadwal.GlobalSolusi[9].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[9].Solusi, sql.data_mengajar(2, 3, "11 PM B", "rand()"));
            GlobalJadwal.GlobalSolusi[10].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[10].Solusi, sql.data_mengajar(1, 3, "10 PM A", "rand()"));
            GlobalJadwal.GlobalSolusi[11].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[11].Solusi, sql.data_mengajar(1, 3, "10 PM B", "rand()"));

            GlobalJadwal.GlobalSolusi[12].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[12].Solusi, sql.data_mengajar(3, 5, "12 TKJ A", "rand()"));
            GlobalJadwal.GlobalSolusi[13].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[13].Solusi, sql.data_mengajar(3, 5, "12 TKJ B", "rand()"));
            GlobalJadwal.GlobalSolusi[14].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[14].Solusi, sql.data_mengajar(2, 5, "11 TKJ A", "rand()"));
            GlobalJadwal.GlobalSolusi[15].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[15].Solusi, sql.data_mengajar(2, 5, "11 TKJ B", "rand()"));
            GlobalJadwal.GlobalSolusi[16].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[16].Solusi, sql.data_mengajar(1, 5, "10 TKJ A", "rand()"));
            GlobalJadwal.GlobalSolusi[17].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[17].Solusi, sql.data_mengajar(1, 5, "10 TKJ B", "rand()"));
            GlobalJadwal.GlobalSolusi[18].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[18].Solusi, sql.data_mengajar(1, 5, "10 TKJ k", "rand()"));

            GlobalJadwal.GlobalSolusi[19].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[19].Solusi, sql.data_mengajar(3, 4, "12 RPL A", "rand()"));
            GlobalJadwal.GlobalSolusi[20].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[20].Solusi, sql.data_mengajar(3, 4, "12 RPL B", "rand()"));
            GlobalJadwal.GlobalSolusi[21].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[21].Solusi, sql.data_mengajar(2, 4, "11 RPL A", "rand()"));
            GlobalJadwal.GlobalSolusi[22].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[22].Solusi, sql.data_mengajar(2, 4, "11 RPL B", "rand()"));
            GlobalJadwal.GlobalSolusi[23].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[23].Solusi, sql.data_mengajar(1, 4, "10 RPL A", "rand()"));
            GlobalJadwal.GlobalSolusi[24].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[24].Solusi, sql.data_mengajar(1, 4, "10 RPL B", "rand()"));

            GlobalJadwal.GlobalSolusi[25].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[25].Solusi, sql.data_mengajar(2, 2, "11 KI A", "rand()"));
            GlobalJadwal.GlobalSolusi[26].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[26].Solusi, sql.data_mengajar(2, 2, "11 KI B", "rand()"));
            GlobalJadwal.GlobalSolusi[27].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[27].Solusi, sql.data_mengajar(1, 2, "10 KI A", "rand()"));
            GlobalJadwal.GlobalSolusi[28].Solusi = dom_solusi.greedy(GlobalJadwal.GlobalSolusi[28].Solusi, sql.data_mengajar(1, 2, "10 KI B", "rand()"));
        }
    }
}
