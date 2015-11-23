using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penjadwalan.model
{
    public class SolusiJadwal:
    {
        private List<jadwal> _solusi;
        private bool _flag;

        public List<jadwal> Solusi{
            get{if(_solusi == null){_solusi = new List<jadwal>();}return _solusi;}
            set{_solusi = value;}
        }

        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
    }
}
