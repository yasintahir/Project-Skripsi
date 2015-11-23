using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace penjadwalan.model
{
    class jadwal
    {
        private string _NamaGuru;
        private string _MataPelajaran;
        private int _SKS;
        private string _tingkat;
        private string _ruang;

        public string NamaGuru
        {
            get { return _NamaGuru; }
            set { _NamaGuru = value; }
        }

        public string MataPelajaran
        {
            get { return _MataPelajaran; }
            set { _MataPelajaran = value; }
        }

        public int SKS
        {
            get { return _SKS; }
            set { _SKS = value; }
        }

        public string Tingkat
        {
            get { return _tingkat; }
            set { _tingkat = value; }
        }

        public string Ruang
        {
            get { return _ruang; }
            set { _tingkat = value}
        }
    }
}
