using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penjadwalan.model
{
    public class solusi
    {
        private List<jadwal> _solusi;

        public List<jadwal> Solusi
        {
            get {
                if (_solusi == null)
                {
                    _solusi = new List<jadwal>();
                }
                return _solusi; 
            }
            set { _solusi = value; }
        }

        private int tingkat;

        public int Tingkat
        {
            get { return tingkat; }
            set { tingkat = value; }
        }

        private string jurusan;

        public string Jurusan
        {
            get { return jurusan; }
            set { jurusan = value; }
        }

        private string kelas;

        public string Kelas
        {
            get { return kelas; }
            set { kelas = value; }
        }

        private bool visit;

        public bool Visit
        {
            get { return visit; }
            set { visit = value; }
        }

    }

    public class GLobalSolusi
    {
        private List<solusi> globalSolusi;

        public List<solusi> GlobalSolusi
        {
            get {
                if (globalSolusi == null)
                {
                    globalSolusi = new List<solusi>();
                }
                return globalSolusi; 
            }
            set { globalSolusi = value; }
        }
    }
}