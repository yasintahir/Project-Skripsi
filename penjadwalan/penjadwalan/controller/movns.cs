using penjadwalan.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penjadwalan.controller
{
    public class movns
    {
        
        private Random gr = new Random();
        private List<jadwal> sulusiaksen;
        private List<jadwal> solusikasen2;
        private Random rg = new Random();
        public solusi proses_movns(solusi Solusi, GLobalSolusi global)
        {
            
            return Solusi;
        }

        /// <summary>
        /// terakhir check bentrok collection yang di interchanging dengan global 
        /// </summary>
        /// <param name=Solusi></param>
        /// <param name=global></param>
        /// <returns></returns>
        public solusi interchanging(solusi Solusi, GLobalSolusi global)
        {
            mengajar temp1 = new mengajar();
            mengajar temp2 = new mengajar();
            int k = rg.Next(0, Solusi.Solusi.Count - 1);
            int q = rg.Next(0, Solusi.Solusi.Count - 1);
            while (k == q)
            {
                q = rg.Next(0, Solusi.Solusi.Count - 1);
            }
            int kk = rg.Next(0, Solusi.Solusi[k].Mengajar.Count - 1);
            int qq = rg.Next(0, Solusi.Solusi[q].Mengajar.Count - 1);
            bool ketemu = false;
            int i = 0;
            while (!ketemu && i < 28)
            {
                var p = global.GlobalSolusi[i].Solusi.Where(a => a.Hari == Solusi.Solusi[k].Hari).Select(b => b.Mengajar);
                i++;
            }
            return Solusi;
        }

    }
}
