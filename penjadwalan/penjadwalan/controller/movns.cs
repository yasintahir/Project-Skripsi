using penjadwalan.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            temp = global.Solusi.ElementAt(x).Mengajar.ElementAt(xx);
            global.Solusi.ElementAt(x).Mengajar.ElementAt(xx).EndMengajar = global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).EndMengajar;
            global.Solusi.ElementAt(x).Mengajar.ElementAt(xx).Guru = global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).Guru;
            global.Solusi.ElementAt(x).Mengajar.ElementAt(xx).MataPelajaran = global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).MataPelajaran;
            global.Solusi.ElementAt(x).Mengajar.ElementAt(xx).Problem = global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).Problem;
            global.Solusi.ElementAt(x).Mengajar.ElementAt(xx).Sks = global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).Sks;
            global.Solusi.ElementAt(x).Mengajar.ElementAt(xx).StartMengajar = global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).StartMengajar;
            global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).EndMengajar = temp.EndMengajar;
            global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).Guru = temp.Guru;
            global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).MataPelajaran = temp.MataPelajaran;
            global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).Problem = temp.Problem;
            global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).Sks = temp.Sks;
            global.Solusi.ElementAt(y).Mengajar.ElementAt(yy).StartMengajar = temp.StartMengajar;
            int jam = atur_jam_mengajar(x);
            for (int i = 0; i < global.Solusi[x].Mengajar.Count; i++)
            {
                global.Solusi.ElementAt(x).Mengajar.ElementAt(i).StartMengajar = jam;
                jam = jam + global.Solusi.ElementAt(x).Mengajar.ElementAt(i).Sks;
                global.Solusi.ElementAt(x).Mengajar.ElementAt(i).EndMengajar = jam - 1;
                xlimit -= global.Solusi.ElementAt(x).Mengajar.ElementAt(i).Sks;
            }
            global.Solusi[x].Limit = xlimit;
            jam = atur_jam_mengajar(y);
            for (int i = 0; i < global.Solusi[y].Mengajar.Count; i++)
            {
                global.Solusi.ElementAt(y).Mengajar.ElementAt(i).StartMengajar = jam;
                jam = jam + global.Solusi.ElementAt(y).Mengajar.ElementAt(i).Sks;
                global.Solusi.ElementAt(y).Mengajar.ElementAt(i).EndMengajar = jam - 1;
                ylimit -= global.Solusi.ElementAt(y).Mengajar.ElementAt(i).Sks;
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
                            if (GLobalJadwal.GlobalSolusi[i].Solusi[j].Mengajar.ElementAt(k).Guru == GLobalJadwal.GlobalSolusi[pos].Solusi[j].Mengajar.ElementAt(k).Guru)
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
                            if (GLobalJadwal.GlobalSolusi[pos].Solusi[i].Mengajar.ElementAt(j).Guru == GLobalJadwal.GlobalSolusi[k].Solusi[i].Mengajar.ElementAt(l).Guru)
                            {
                                if (Math.Abs(GLobalJadwal.GlobalSolusi[pos].Solusi[i].Mengajar.ElementAt(j).StartMengajar - GLobalJadwal.GlobalSolusi[k].Solusi[i].Mengajar.ElementAt(l).StartMengajar) <= GLobalJadwal.GlobalSolusi[pos].Solusi[i].Mengajar.ElementAt(j).Sks)
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

        public solusi insertion(solusi jadwal)
        {
            // flag tanda buat intesification
            int random = 0;
            for (int i = 0; i < jadwal.Solusi.Count;i++)
            {
                random = rr.Next(0, jadwal.Solusi[i].Mengajar.Count - 1);
                jadwal.Solusi[i].Mengajar.ElementAt(random).Problem = true;
            }
            return jadwal;
        }

        public List<solusi> intensification(solusi jadwal)
        {
            //pindah mengajar yang ditandain
            List<solusi> temp_jadwal = new List<solusi>();
            List<solusi> temp_job = new List<solusi>();
            List<mengajar> job = new List<mengajar>();
            LinkedListNode<mengajar> lln;
            for (int i = 0; i < jadwal.Solusi.Count; i++)
            {
                for (int j = 0; j < jadwal.Solusi[i].Mengajar.Count; j++)
                {
                    if (jadwal.Solusi[i].Mengajar.ElementAt(j).Problem)
                    {
                        //lln = new LinkedListNode<mengajar>(jadwal.Solusi[i].Mengajar.ElementAt(j));
                        job.Add(jadwal.Solusi[i].Mengajar.ElementAt(j));
                        jadwal.Solusi[i].Mengajar.Remove(jadwal.Solusi[i].Mengajar.ElementAt(j));
                        lln = null;
                    }
                }
            }
            //end pisah ngajar
            temp_jadwal.Add(jadwal);
            // masukin ke tetangga
            for (int i = 0; i < job.Count; i++) // iterasi sebanyak job
            {
                for (int j = 0; j < temp_jadwal.Count; j++)// iterasi per solusi yang fitness di lokal
                {
                    for (int k = 0; k <jadwal.Solusi.Count; k++) // iterasi per hari
                    {
                        for (int l = 0; l <= jadwal.Solusi[k].Mengajar.Count; l++)// iterasi mengajar per hari
                        {
                            List<jadwal> x = temp_jadwal[j].Solusi.ToList();
                            temp_job.Add(new solusi() { Jurusan = temp_jadwal[j].Jurusan, Kelas = temp_jadwal[j].Kelas, Solusi = x, Tingkat = temp_jadwal[j].Tingkat, Visit = temp_jadwal[j].Visit});
                            temp_job.Last().Solusi[k].Mengajar.Insert(l, job[i]);
                        }
                        
                    }
                }

                for (int m = 0; m < temp_job.Count; m++)//periksa lokal fitness temp_job
                {
                    if (local_pinalti(temp_job[m]) > 0)
                    {
                        temp_job.RemoveAt(m);
                    }
                }
                temp_jadwal.Clear();
                temp_jadwal.AddRange(temp_job);
                temp_job.Clear();
            }
            //end tetangga

            for (int i = 0; i < temp_jadwal.Count; i++)
            {
                for (int j = 0; j < temp_jadwal[i].Solusi.Count; j++)
                {
                    for (int k = 0; k < temp_jadwal[i].Solusi[j].Mengajar.Count; k++)
                    {
                        if (temp_jadwal[i].Solusi[j].Mengajar.ElementAt(k).Problem)
                        {
                            temp_jadwal[i].Solusi[j].Mengajar.ElementAt(k).Problem = false;
                        }
                    }
                }
            }
                return temp_jadwal;
        }
    }
}
