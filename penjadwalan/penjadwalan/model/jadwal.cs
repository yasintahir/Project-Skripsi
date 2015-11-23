using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace penjadwalan.model
{
    public class jadwal
    {
        private List<mengajar> _mengajar;

        public List<mengajar> Mengajar
        {
            get {
                if (_mengajar == null)
                {
                    _mengajar = new List<mengajar>();
                }
                return _mengajar; }
            set { _mengajar = value; }
        }

        private string _hari;

        public string Hari
        {
            get { return _hari; }
            set { _hari = value; }
        }

        private int limit;

        public int Limit
        {
            get { return limit; }
            set { limit = value; }
        }

    }
}
