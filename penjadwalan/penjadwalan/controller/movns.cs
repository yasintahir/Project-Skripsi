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
            int xlimit =  limit(x);
            int ylimit = limit(y);
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
                xlimit -= global.Solusi[x].Mengajar[i].Sks;
            }
            global.Solusi[x].Limit = xlimit;
            jam = atur_jam_mengajar(y);
            for (int i = 0; i < global.Solusi[y].Mengajar.Count; i++)
            {
                global.Solusi[y].Mengajar[i].StartMengajar = jam;
                jam = jam + global.Solusi[y].Mengajar[i].Sks;
                global.Solusi[y].Mengajar[i].EndMengajar = jam - 1;
                ylimit -= global.Solusi[y].Mengajar[i].Sks;
            }
            global.Solusi[y].Limit = ylimit;
                return global;
        }

        public int limit(int x)
        {
            if (x == 0)
            {
                return 9;
            }else if(x == 4){
                return 8;
            }
            else
            {
                return 10;
            }
            
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

        public int local_pinalti(solusi jadwal)
        {
            int pinalti = 0;

            for (int i = 0; i < jadwal.Solusi.Count; i++)
            {
                //cek limit hari yang minus
                if (jadwal.Solusi[i].Limit < 0)
                {
                    pinalti++;
                }
                //cek limit yang kurang dari 5
                if (jadwal.Solusi[i].Limit > 3)
                {
                    pinalti++;
                }

                // cek hari mata pelajaran cuma ada satu
                if (jadwal.Solusi[i].Mengajar.Count == 1)
                {
                    pinalti++;
                }
                // cek hari mata pelajaran lebih dari 4
                if (jadwal.Solusi[i].Mengajar.Count > 4)
                {
                    pinalti++;
                }
            }

                return pinalti;
        }

        public int global_pinalti(GLobalSolusi GLobalJadwal, int pos)
        {
            int pinalti = 0;
            // cek guru ngajar bentrok dengan kelas sebelumnya
            for (int i = 0; i < pos; i++)
            {
                for (int j = 0; j < GLobalJadwal.GlobalSolusi[i].Solusi.Count; j++)
                {
                    for (int k = 0; k < GLobalJadwal.GlobalSolusi[pos].Solusi[j].Mengajar.Count; k++)
                    {
                        if (GLobalJadwal.GlobalSolusi[i].Solusi[j].Mengajar.Count - 1 > k)
                        {
                            if (GLobalJadwal.GlobalSolusi[i].Solusi[j].Mengajar[k].Guru == GLobalJadwal.GlobalSolusi[pos].Solusi[j].Mengajar[k].Guru)
                            {
                                pinalti++;
                            }
                        }
                    }
                }
            }

            //cek rentang guru ngajar terlalu dempet ex : kelas-a mp x jam 1-3, kelas-b mp y 4-6
            for (int i = 0; i < GLobalJadwal.GlobalSolusi[pos].Solusi.Count; i++)
            {
                for (int j = 0; j < GLobalJadwal.GlobalSolusi[pos].Solusi[i].Mengajar.Count; j++)
                {
                    for (int k = 0; k < pos; k++)
                    {
                        for (int l = 0; l < GLobalJadwal.GlobalSolusi[k].Solusi[i].Mengajar.Count; l++)
                        {
                            if (GLobalJadwal.GlobalSolusi[pos].Solusi[i].Mengajar[j].Guru == GLobalJadwal.GlobalSolusi[k].Solusi[i].Mengajar[l].Guru)
                            {
                                if (Math.Abs(GLobalJadwal.GlobalSolusi[pos].Solusi[i].Mengajar[j].StartMengajar - GLobalJadwal.GlobalSolusi[k].Solusi[i].Mengajar[l].StartMengajar) <= GLobalJadwal.GlobalSolusi[pos].Solusi[i].Mengajar[j].Sks)
                                {
                                    pinalti++;
                                }
                            }
                        }
                    }
                }
            }

                return pinalti;
        }

        public List<int> insertion(solusi jadwal)
        {
            int random = 0;
            List<int> x = new List<int>();
            for(int i = 0; i < jadwal.Solusi.Count){
                    random = rr.Next(0, jadwal.Solusi[i].Mengajar.Count-1);
                x.Add(random);
            }
            return x;
        }

        public List<solusi> intensification(solusi jadwal)
        {
            List<solusi> x;
            List<solusi> temp;
            solusi temp_jadwal = jadwal;
            List<int> job = insertion(jadwal);
            for (int i = 0; i < temp_jadwal.Solusi.Count; i++)
            {
               //intensification macet
            }
                return x;
        }
    }
}
