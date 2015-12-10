using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace penjadwalan
{
    class kon
    {
        private SqlCommand com = null;
        private string konf = "Data Source=LENOVO-PC;Initial Catalog=Penjadwalan;Integrated Security=True";
        private SqlConnection koneksi = null;
        

        private void open_kon()
        {
            koneksi = new SqlConnection(konf);
            koneksi.Open();
        }

        private void close_kon(){
           koneksi.Close();
           koneksi=null;
        }

       public DataTable  tampil_data(string x)
        {
            DataTable dt = new DataTable();
            try
            {
                
                open_kon();
                com = new SqlCommand();
                com.Connection = koneksi;
                com.CommandType = CommandType.Text;
                com.CommandText = x;
                SqlDataReader mdr = com.ExecuteReader();
                dt.Load(mdr);
                close_kon();
               
            }
            catch (SqlException)
            {
            }
            com = null;
            return dt;
       }
       public void dml(string x)
       {
           open_kon();
           com = new SqlCommand();
           com.Connection = koneksi;
           com.CommandType = CommandType.Text;
           com.CommandText = x;
           com.ExecuteNonQuery();
           com = null;
           close_kon();
       }

       public DataTable data_mengajar(int tingkat, int jurusan, string kelas, string order)
       {
           DataTable mengajar = new DataTable();
           String sql = "select guru.nama_guru,mata_pelajaran.mata_pelajaran, detail_mtp.sks, tingkat.tingkat, jurusan.kode_jurusan, kelas.kelas  from detail_mengajar join detail_mtp on detail_mengajar.kode_mtp = detail_mtp.id_dmp join kelas on detail_mengajar.id_kelas = kelas.id_kelas join guru on detail_mengajar.kode_guru = guru.kode_guru join tingkat on detail_mtp.tingkat = tingkat.kode_tingkat join mata_pelajaran on detail_mtp.mata_pelajaran = mata_pelajaran.kode_mtp join jurusan on detail_mtp.jurusan = jurusan.id_jurusan where tingkat.kode_tingkat = "+tingkat+" and jurusan.id_jurusan = "+jurusan+" and kelas.kelas = '"+kelas+"' order  by NEWID()";
           mengajar = tampil_data(sql);
           return mengajar;
       }
    }
}
