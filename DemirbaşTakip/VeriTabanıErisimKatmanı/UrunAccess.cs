using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlıkKatmanı;

namespace VeriTabanıErisimKatmanı
{
    public class UrunAccess
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");

        public List<Urun> Listele()
        {
            List<Urun> uruns = new List<Urun>();
            SqlCommand komut = new SqlCommand("sp_urun_listele", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            baglan.Open();
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                Urun urun = new Urun
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Ad = reader["ad"].ToString(),
                    StokAdet = Convert.ToInt32(reader["stokAdet"].ToString()),
                    //kategori_id = Convert.ToInt32(reader["kategori_id"].ToString()),
                    kategori_ad = reader["kategori_ad"].ToString(),
                    zimmet = reader["zimmet"].ToString()
                };
                uruns.Add(urun);
            }
            reader.Close();
            baglan.Close();
            return uruns;
        }

        public int Ekle(Urun urun)
        {
            SqlCommand komut = new SqlCommand("sp_urun_ekle", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@ad", urun.Ad);
            komut.Parameters.AddWithValue("@stokAdet", urun.StokAdet);
            //komut.Parameters.AddWithValue("@kategori_id", urun.kategori_id);
            komut.Parameters.AddWithValue("@kategori_ad", urun.kategori_ad);
            komut.Parameters.AddWithValue("@zimmet", urun.zimmet);
            baglan.Open();
            urun.Id = Convert.ToInt32(komut.ExecuteScalar());
            baglan.Close();

            return urun.Id;
        }

        public int Sil(int id)
        {
            SqlCommand komut = new SqlCommand("sp_urun_sil", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", id);
            baglan.Open();
            int Count = komut.ExecuteNonQuery();
            baglan.Close();
            return Count;
        }

        public int Guncelle(Urun urun)
        {
            SqlCommand komut = new SqlCommand("sp_personel_guncelle", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", urun.Id);
            komut.Parameters.AddWithValue("@ad", urun.Ad);
            komut.Parameters.AddWithValue("@stokAdet", urun.StokAdet);
            //komut.Parameters.AddWithValue("@kategori_id", urun.kategori_id);
            komut.Parameters.AddWithValue("@kategori_ad", urun.kategori_ad);
            komut.Parameters.AddWithValue("@zimmet", urun.zimmet);
            baglan.Open();
            int Count = komut.ExecuteNonQuery();
            baglan.Close();
            return Count;
        }
    }
}
