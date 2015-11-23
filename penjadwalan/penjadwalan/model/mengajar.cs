using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penjadwalan.model
{
    public class mengajar
    {
        private string _guru;

        public string Guru
        {
            get { return _guru; }
            set { _guru = value; }
        }
        private string _mata_pelajaran;

        public string MataPelajaran
        {
            get { return _mata_pelajaran; }
            set { _mata_pelajaran = value; }
        }
        private int _sks;

        public int Sks
        {
            get { return _sks; }
            set { _sks = value; }
        }

        private bool problem;

        public bool Problem
        {
            get { return problem; }
            set { problem = value; }
        }

        private int startMengajar;

        public int StartMengajar
        {
            get { return startMengajar; }
            set { startMengajar = value; }
        }
        private int endMengajar;

        public int EndMengajar
        {
            get { return endMengajar; }
            set { endMengajar = value; }
        }
    }
}
