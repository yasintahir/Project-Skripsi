using System;
using penjadwalan.model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace penjadwalan.controller
{
    public class Dispatch
    {

        public solusi init_solusi(solusi x)
        {
            x.Solusi.Add(new jadwal() { Limit = 9, Hari = "senin"});
            x.Solusi.Add(new jadwal() { Limit = 10, Hari = "selasa"});
            x.Solusi.Add(new jadwal() { Limit = 10, Hari = "rabu"});
            x.Solusi.Add(new jadwal() { Limit = 10, Hari = "kamis"});
            x.Solusi.Add(new jadwal() { Limit = 9, Hari = "Jumat"});
            x.Solusi.Add(new jadwal() { Limit = 10, Hari = "sabtu"});
            return x;
        }

        public List<jadwal> greedy(List<jadwal> x, DataTable y)
        {
            bool optim = false;
            int hari = 0;
            int temp_sks = 0;
            int i = 0;
            int limit_loop = 0;
            int[] jam_ngajar = new int[6] { 2, 1, 1, 1, 2, 1 };
            int start_ngajar = 0;
            while (!optim)
            {

                    temp_sks = int.Parse(y.Rows[i].ItemArray[2].ToString());
                if (limit_loop < 100)
                {
                    if (x[hari].Limit > temp_sks)
                    {
                        x[hari].Limit -= temp_sks;
                        start_ngajar = jam_ngajar[hari];
                        jam_ngajar[hari] += temp_sks;
                        x[hari].Mengajar.Add(new mengajar() { Guru = y.Rows[i].ItemArray[0].ToString(), MataPelajaran = y.Rows[i].ItemArray[1].ToString(), Sks = temp_sks , Problem=false , StartMengajar = start_ngajar, EndMengajar = jam_ngajar[hari]-1});
                        hari++;
                        i++;
                    }
                   
                    if (!optim && hari > 5)
                    {
                        hari = 0;
                    }
                }
                else
                {
                    int max = 0;
                    while (i < y.Rows.Count)
                    {
                        for (int j = 1; j < x.Count; j++)
                        {
                            if (x[max].Limit < x[j].Limit)
                            {
                                max = j;
                            }
                        }
                        x[max].Limit -= temp_sks;
                        start_ngajar = jam_ngajar[hari];
                        jam_ngajar[hari] += temp_sks - 1;
                        x[max].Mengajar.Add(new mengajar() { Guru = y.Rows[i].ItemArray[0].ToString(), MataPelajaran = y.Rows[i].ItemArray[1].ToString(), Sks = temp_sks , Problem = true, StartMengajar = start_ngajar , EndMengajar = jam_ngajar[hari]});
                        i++;
                    }
                }
                limit_loop++;
                if (i >= y.Rows.Count)
                {
                    optim = true;
                }
            }
            return x;
        }
    }
}
