using penjadwalan.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace penjadwalan.controller
{
    public class movns
    {
        
        private Random gr = new Random();
        private List<jadwal> sulusiaksen;
        private List<jadwal> solusikasen2;
        private Random rg = new Random();
        private Random rr = new Random();
        private string statusError = string.Empty;
        public Form1 form;
        public movns(Form1 x)
        {
            form = x;
        }
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
        public GLobalSolusi interchanging( GLobalSolusi global, int pos)
        {
            if (pos >= 0)
            {
                int x = -1;
                int xx = -1;
                bool prob = false;
                int i = 0;
                int j = 0;
                while (!prob && i < global.GlobalSolusi[pos].Solusi.Count)
                {
                    while (!prob && j < global.GlobalSolusi[pos].Solusi[i].Mengajar.Count)
                    {
                        if (global.GlobalSolusi[pos].Solusi[i].Mengajar[j].Problem)
                        {
                            x = i;
                            xx = j;
                            prob = true;
                        }
                        j++;
                    }
                    i++;
                }
                if (prob)
                {
                    if (pos > 0)
                    {
                        int xy = -1;
                        int xyy = -1;
                        for (int y = 0; y < global.GlobalSolusi[pos].Solusi.Count; y++)
                        {
                            int startJam = limit(y);
                            for (int yy = 0; yy < global.GlobalSolusi[pos].Solusi[y].Mengajar.Count; yy++)
                            {
                                if (global_penalti_intensifikasi(global.GlobalSolusi[pos].Solusi[x].Mengajar[xx], global, pos, y, yy, startJam) == 0)
                                {
                                    if (Lokal_penalti_intensifikasi(global.GlobalSolusi[pos].Solusi[x].Mengajar[xx], global.GlobalSolusi[pos], pos, y) == 0)
                                    {
                                        xy = y;
                                        xyy = yy;
                                    }
                                }
                                startJam += global.GlobalSolusi[pos].Solusi[y].Mengajar[yy].Sks;
                            }
                        }

                        if (xy >= 0 && xyy >= 0)
                        {
                            mengajar temp = new mengajar();
                            temp = global.GlobalSolusi[pos].Solusi[x].Mengajar[xx];
                            global.GlobalSolusi[pos].Solusi[x].Mengajar[xx] = global.GlobalSolusi[pos].Solusi[xy].Mengajar[xyy];
                            global.GlobalSolusi[pos].Solusi[xy].Mengajar[xyy] = temp;
                            regenerate_jam_mengajar(global.GlobalSolusi[pos]);
                        }
                        else
                        {
                            form.Row = form.Log.NewRow(); form.Row["Status"] = "Interchanging"; form.Row["Keterangan"] = "Gagal meemukan pasangan optimal, mencari pasangan minimum limit";
                            form.Log.Rows.Add(form.Row);
                            int min = 1000;
                            int trial = 100;
                            for (int k = 0; k < trial; k++)
                            {
                                int y = rr.Next(0, global.GlobalSolusi[pos].Solusi.Count);
                                int yy = rg.Next(0, global.GlobalSolusi[pos].Solusi[y].Mengajar.Count);
                                if (min > global_penalti_intensifikasi(global.GlobalSolusi[pos].Solusi[x].Mengajar[xx], global, pos, y, yy, global.GlobalSolusi[pos].Solusi[y].Mengajar[yy].StartMengajar))
                                {
                                    min = global_penalti_intensifikasi(global.GlobalSolusi[pos].Solusi[x].Mengajar[xx], global, pos, y, yy, global.GlobalSolusi[pos].Solusi[y].Mengajar[yy].StartMengajar);
                                    xy = y;
                                    xyy = yy;
                                }
                            }
                            mengajar temp = new mengajar();
                            temp = global.GlobalSolusi[pos].Solusi[x].Mengajar[xx];
                            global.GlobalSolusi[pos].Solusi[x].Mengajar[xx] = global.GlobalSolusi[pos].Solusi[xy].Mengajar[xyy];
                            global.GlobalSolusi[pos].Solusi[xy].Mengajar[xyy] = temp;
                            regenerate_jam_mengajar(global.GlobalSolusi[pos]);
                        }
                    }
                    else
                    {
                        int xy = rr.Next(0,global.GlobalSolusi[pos].Solusi.Count);
                        int xyy = rg.Next(0, global.GlobalSolusi[pos].Solusi[xy].Mengajar.Count);
                        mengajar temp = new mengajar();
                        temp = global.GlobalSolusi[pos].Solusi[x].Mengajar[xx];
                        global.GlobalSolusi[pos].Solusi[x].Mengajar[xx] = global.GlobalSolusi[pos].Solusi[xy].Mengajar[xyy];
                        global.GlobalSolusi[pos].Solusi[xy].Mengajar[xyy] = temp;
                        regenerate_jam_mengajar(global.GlobalSolusi[pos]);
                    }
                }

            }
            else
            {

            }
            for (int i = 0; i < global.GlobalSolusi[pos].Solusi.Count; i++)
            {
                for (int j = 0; j < global.GlobalSolusi[pos].Solusi[i].Mengajar.Count; j++)
                {
                    if (global.GlobalSolusi[pos].Solusi[i].Mengajar[j].Problem)
                    {
                        global.GlobalSolusi[pos].Solusi[i].Mengajar[j].Problem = false;
                    }
                }
            }
            return global;
        }

        public int limit(int x)
        {
            if (x == 0)
            {
                return 9;
            }else if(x == 4){
                return 9;
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
                atur_jam = 2;
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
                    form.Row = form.Log.NewRow(); form.Row["Status"] = "Lokal Penalti"; form.Row["Keterangan"] = "Over limit hari";
                    form.Log.Rows.Add(form.Row);
                    pinalti++;
                }
                //cek limit yang kurang dari 5
                if (jadwal.Solusi[i].Limit > 4)
                {
                    form.Row = form.Log.NewRow(); form.Row["Status"] = "Lokal Penalti"; form.Row["Keterangan"] = "sisa Limit masih banyak";
                    form.Log.Rows.Add(form.Row);
                    pinalti++;
                }
                // cek hari mata pelajaran lebih dari 4
                if (jadwal.Solusi[i].Mengajar.Count > 4)
                {
                    form.Row = form.Log.NewRow(); form.Row["Status"] = "Lokal Penalti"; form.Row["Keterangan"] = "Jadwal Mengajar terlalu padat";
                    form.Log.Rows.Add(form.Row);
                    pinalti++;
                }
            }

                return pinalti;
        }

        public int global_pinalti(GLobalSolusi GLobalJadwal, int pos)
        {
            int pinalti = 0;
            // cek guru ngajar bentrok dengan kelas sebelumnya
          
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
                                if (Math.Abs(GLobalJadwal.GlobalSolusi[pos].Solusi[i].Mengajar.ElementAt(j).StartMengajar - GLobalJadwal.GlobalSolusi[k].Solusi[i].Mengajar.ElementAt(l).StartMengajar) < GLobalJadwal.GlobalSolusi[pos].Solusi[i].Mengajar.ElementAt(j).Sks)
                                {
                                    GLobalJadwal.GlobalSolusi[pos].Solusi[i].Mengajar[j].Problem = true;
                                    form.Row = form.Log.NewRow(); form.Row["Status"] = "Global Penalti"; form.Row["Keterangan"] = "Jadwal Mengajar guru bentrok";
                                    form.Log.Rows.Add(form.Row);
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
                int prob = -1;
                for(int j = 0; j < jadwal.Solusi[i].Mengajar.Count;j++){
                    if (jadwal.Solusi[i].Mengajar[j].Problem)
                    {
                        prob = j;
                        break; 
                    }
                }
                if (jadwal.Solusi[i].Mengajar.Count > 1)
                {
                    random = rr.Next(0, jadwal.Solusi[i].Mengajar.Count);
                    jadwal.Solusi[i].Mengajar.ElementAt(random).Problem = true;
                }
                
            }
            return jadwal;
        }

       /* public List<solusi> intensification(solusi jadwal)
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
        }*/

        public GLobalSolusi intensifikasi(GLobalSolusi globaljadwal, int pos)
        {
            List<mengajar> Job = new List<mengajar>();
            for (int i = 0; i < globaljadwal.GlobalSolusi[pos].Solusi.Count; i++)
            {
                for (int j = 0; j < globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar.Count; j++)
                {
                    if (globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar.ElementAt(j).Problem)
                    {
                        if (globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar.Count == 1)
                        {
                            globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar.ElementAt(j).Problem = false;
                        }
                        else
                        {
                            //lln = new LinkedListNode<mengajar>(jadwal.Solusi[i].Mengajar.ElementAt(j));
                            Job.Add(globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar.ElementAt(j));
                            globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar.Remove(globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar.ElementAt(j));
                        }
                    }
                }
            }

            regenerate_jam_mengajar(globaljadwal.GlobalSolusi[pos]);
            int fin = 0;
            int counterError = 1;
            int rand_hari = rg.Next(0, globaljadwal.GlobalSolusi[pos].Solusi.Count);
            int rand_ngajar = rr.Next(0, globaljadwal.GlobalSolusi[pos].Solusi[rand_hari].Mengajar.Count);
            while (fin < Job.Count)
            {
                //if (global_penalti_intensifikasi(Job[fin], globaljadwal,pos,rand_hari,rand_ngajar) == 0)
                //{
                    //check global
                    if (Lokal_penalti_intensifikasi(Job[fin], globaljadwal.GlobalSolusi[pos], pos, rand_hari) > 0)
                    {
                        rand_hari = rg.Next(0, globaljadwal.GlobalSolusi[pos].Solusi.Count);
                        rand_ngajar = rr.Next(0, globaljadwal.GlobalSolusi[pos].Solusi[rand_hari].Mengajar.Count);
                        form.ErrorLbl.Invoke((MethodInvoker)(()=> form.ErrorLbl.Text = globaljadwal.GlobalSolusi[pos].Kelas + ", Lokal intensifikasi Penalti: "+ Lokal_penalti_intensifikasi(Job[fin],globaljadwal.GlobalSolusi[pos],pos,rand_hari)+counterError.ToString()));
                        counterError++;
                    }
                    else
                    {
                        //lokal fitt
                        form.Row = form.Log.NewRow(); form.Row["Status"] = "Intensifikasi"; form.Row["Keterangan"] = "Generate Barnch sebanyak "+counterError+" pada satu job";
                        form.Log.Rows.Add(form.Row);
                        globaljadwal.GlobalSolusi[pos].Solusi[rand_hari].Mengajar.Insert(rand_ngajar, Job[fin]);
                        int jam = atur_jam_mengajar(rand_hari);
                        int lim = limit(rand_hari);
                        int jam_end = jam;
                        for (int i = 0; i < globaljadwal.GlobalSolusi[pos].Solusi[rand_hari].Mengajar.Count; i++)
                        {

                            globaljadwal.GlobalSolusi[pos].Solusi[rand_hari].Mengajar[i].StartMengajar = jam;
                            globaljadwal.GlobalSolusi[pos].Solusi[rand_hari].Mengajar[i].EndMengajar = jam + globaljadwal.GlobalSolusi[pos].Solusi[rand_hari].Mengajar[i].Sks - 1;
                            lim-= globaljadwal.GlobalSolusi[pos].Solusi[rand_hari].Mengajar[i].Sks;
                            jam += globaljadwal.GlobalSolusi[pos].Solusi[rand_hari].Mengajar[i].Sks;
                        }
                        globaljadwal.GlobalSolusi[pos].Solusi[rand_hari].Limit = lim;
                        fin++;
                        counterError = 1;
                    }

                    if (counterError > 300)//0.5 detik belum menemukan keputusan
                    {
                        form.Row = form.Log.NewRow(); form.Row["Status"] = "Intensifikasi"; form.Row["Keterangan"] = "Jumlah branch melibihi limit melakukan penelusuran fitness";
                        form.Log.Rows.Add(form.Row);
                        int globalHariMin =-1;
                        int globalngajar = -1;
                        int globalMin=9999;
                        for (int i = 0; i < globaljadwal.GlobalSolusi[pos].Solusi.Count; i++)
                        {
                            
                            int jamStart = atur_jam_mengajar(i);
                            for (int j = 0; j <= globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar.Count; j++)
                            {
                                if (globalMin > global_penalti_intensifikasi(Job[fin], globaljadwal, pos, i, j, jamStart))
                                {
                                    globalMin = global_penalti_intensifikasi(Job[fin], globaljadwal, pos, i, j, jamStart);
                                    if (globalMin == 0)
                                    {
                                        if (Lokal_penalti_intensifikasi(Job[fin], globaljadwal.GlobalSolusi[pos], pos, i) == 0)
                                        {
                                            globalHariMin = i;
                                            globalngajar = j;
                                            j = globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar.Count;
                                        }
                                    }
                                }

                                if (j < globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar.Count - 1)
                                {
                                    jamStart += globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar[j].Sks;
                                }
                            }
                            if (pos == 0)
                            {
                                if (globalHariMin >= 0 || globalngajar >= 0)
                                {
                                    i = globaljadwal.GlobalSolusi[pos].Solusi.Count;
                                }
                            }
                            else
                            {
                                if (globalHariMin >= 0 && globalngajar >= 0)
                                {
                                    i = globaljadwal.GlobalSolusi[pos].Solusi.Count;
                                }
                            }
                        }
                        if (globalHariMin >= 0 && globalngajar >= 0)
                        {
                            form.Row = form.Log.NewRow(); form.Row["Status"] = "Intensifikasi"; form.Row["Keterangan"] = "Ketemu branch dengan fitnesh optimal global dan lokal";
                            form.Log.Rows.Add(form.Row);
                            globaljadwal.GlobalSolusi[pos].Solusi[globalHariMin].Mengajar.Insert(globalngajar, Job[fin]);
                            regenerate_jam_mengajar(globaljadwal.GlobalSolusi[pos]);
                        }
                        else
                        {
                            form.Row = form.Log.NewRow(); form.Row["Status"] = "Intensifikasi"; form.Row["Keterangan"] = "tidak ketemu fitness lokal dan global, memasuki job ke limit terbesar";
                            form.Log.Rows.Add(form.Row);
                            int min = 0;
                            for (int i = 1; i < globaljadwal.GlobalSolusi[pos].Solusi.Count; i++)
                            {
                                if (globaljadwal.GlobalSolusi[pos].Solusi[min].Limit < globaljadwal.GlobalSolusi[pos].Solusi[i].Limit)
                                {
                                    min = i;
                                }
                            }
                            int force = rr.Next(0,globaljadwal.GlobalSolusi[pos].Solusi[min].Mengajar.Count);
                            globaljadwal.GlobalSolusi[pos].Solusi[min].Mengajar.Insert(force, Job[fin]);
                            regenerate_jam_mengajar(globaljadwal.GlobalSolusi[pos]);
                        }
                        fin++;
                        counterError = 1;
                    }
                /*}
                else
                {
                    rand_hari = rg.Next(0, globaljadwal.GlobalSolusi[pos].Solusi.Count);
                    rand_ngajar = rr.Next(0, globaljadwal.GlobalSolusi[pos].Solusi[rand_hari].Mengajar.Count);
                   form.GlobalErrorLbl.Invoke((MethodInvoker)(()=> form.GlobalErrorLbl.Text= globaljadwal.GlobalSolusi[pos].Kelas + " , Global Penalti : " + global_penalti_intensifikasi(Job[fin], globaljadwal, pos, rand_hari, rand_ngajar))); 
                }*/


            }
            Job = null;
            for (int i = 0; i < globaljadwal.GlobalSolusi[pos].Solusi.Count; i++)
            {
                for(int j= 0;j < globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar.Count;j++)
                {
                    if (globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar[j].Problem)
                    {
                        globaljadwal.GlobalSolusi[pos].Solusi[i].Mengajar[j].Problem = false;
                    }
                }
            }
                return globaljadwal;
        }

        public string geterror()
        {
            if (string.IsNullOrEmpty(statusError))
            {
                statusError = "Menginisiasi";
            }
            return statusError;
        }


        public int global_penalti_intensifikasi(mengajar job, GLobalSolusi global_jadwal, int pos, int hari, int Mengajar, int startMengajar)
        {
            int penalti  = 0;

            if (pos > 0)
            {
                for (int i = 0; i < pos; i++)
                {
                    for (int j = 0; j < global_jadwal.GlobalSolusi[i].Solusi[hari].Mengajar.Count; j++)
                    {
                        if (global_jadwal.GlobalSolusi[i].Solusi[hari].Mengajar[j].Guru == job.Guru)
                        {
                            if (Math.Abs(global_jadwal.GlobalSolusi[i].Solusi[hari].Mengajar[j].EndMengajar - startMengajar) < job.Sks)
                            {
                                penalti++;
                                form.Row = form.Log.NewRow(); form.Row["Status"] = "Intensifikasi Penalti"; form.Row["Keterangan"] = "Global penalti intensifikasi : "+penalti;
                                form.Log.Rows.Add(form.Row);
                            }
                        }
                    }

                }
            }
            else
            {
                penalti = 0;
            }
            return penalti;
        }


        public int Lokal_penalti_intensifikasi(mengajar job, solusi jadwal, int pos, int hari)
        {
            int penalti = 0;
            int limit_jadwal= limit(hari);
            for (int i = 0; i < jadwal.Solusi[hari].Mengajar.Count;i++)
            {
                limit_jadwal -= jadwal.Solusi[hari].Mengajar[i].Sks;
            }
            limit_jadwal -= job.Sks;
            if(limit_jadwal < 0){
                penalti ++;
                int ran = rr.Next(0, jadwal.Solusi[hari].Mengajar.Count);
                jadwal.Solusi[hari].Mengajar[ran].Problem = true;
                form.Row = form.Log.NewRow(); form.Row["Status"] = "Intensifikasi Penalti"; form.Row["Keterangan"] = "Lokal Intensifikasi penalti :"+penalti;
                form.Log.Rows.Add(form.Row);
            }

            return penalti;
        }

        public void regenerate_jam_mengajar(solusi jadwal)
        {
            for (int i = 0; i < jadwal.Solusi.Count; i++)
            {
                int start_jam = atur_jam_mengajar(i);
                int lim = limit(i);
                for (int j = 0; j < jadwal.Solusi[i].Mengajar.Count; j++)
                {
                    jadwal.Solusi[i].Mengajar[j].StartMengajar = start_jam;
                    jadwal.Solusi[i].Mengajar[j].EndMengajar = start_jam + jadwal.Solusi[i].Mengajar[j].Sks - 1;
                    start_jam += jadwal.Solusi[i].Mengajar[j].Sks;
                    lim -= jadwal.Solusi[i].Mengajar[j].Sks;
                }
                jadwal.Solusi[i].Limit = lim;
            }
        }
    }
}
