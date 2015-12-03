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
        private Random rr = new Random();
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
        public solusi interchanging( solusi global)
        {

            int x = rg.Next(0, global.Solusi.Count-1);
            int y = rg.Next(0, global.Solusi.Count-1);
            while (y == x)
            {
                y = rg.Next(0, global.Solusi.Count-1);
            }
            int xx = rg.Next(0, global.Solusi[x].Mengajar.Count - 1);
            int yy = rg.Next(0, global.Solusi[y].Mengajar.Count - 1);
            mengajar temp = new mengajar();
            temp = global.Solusi[x].Mengajar[xx];
            global.Solusi[x].Mengajar[xx] = global.Solusi[y].Mengajar[yy];
            global.Solusi[y].Mengajar[yy] = temp;
            int jam = atur_jam_mengajar(x);
            for (int i = 0; i < global.Solusi[x].Mengajar.Count; i++)
            {
                global.Solusi[x].Mengajar[i].StartMengajar = jam;
                jam = jam + global.Solusi[x].Mengajar[i].Sks;
                global.Solusi[x].Mengajar[i].EndMengajar = jam - 1;
            }

            jam = atur_jam_mengajar(y);
            for (int i = 0; i < global.Solusi[y].Mengajar.Count; i++)
            {
                global.Solusi[y].Mengajar[i].StartMengajar = jam;
                jam = jam + global.Solusi[y].Mengajar[i].Sks;
                global.Solusi[y].Mengajar[i].EndMengajar = jam - 1;
            }
                return global;
        }


        public static int atur_jam_mengajar(int x)
        {
            int atur_jam = 0;
            if (x == 0)
            {
                atur_jam = 2;
            }
            else if (x == 4)
            {
                atur_jam = 3;
            }
            else
            {
                atur_jam = 1;
            }
            return atur_jam;
        }
    }
}
