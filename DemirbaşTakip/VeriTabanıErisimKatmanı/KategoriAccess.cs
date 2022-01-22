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
    public class KategoriAccess
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");

        public List<Kategori> Listele()
        {
            List<Kategori> kategoris = new List<Kategori>();
            SqlCommand komut = new SqlCommand("sp_kategori_listele", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            baglan.Open();
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                Kategori kategori = new Kategori
                {
                    kategori_id = Convert.ToInt32(reader["kategori_id"]),
                    kategori_ad = reader["kategori_ad"].ToString(),
                };
                kategoris.Add(kategori);
            }
            reader.Close();
            baglan.Close();
            return kategoris;
        }

        public int Ekle(Kategori kategori)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("sp_kategori_ekle", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@kategori_ad", kategori.kategori_ad);
            
            kategori.kategori_id = Convert.ToInt32(komut.ExecuteScalar());
            baglan.Close();

            return kategori.kategori_id;
        }

        public int Sil(int id)
        {
            SqlCommand komut = new SqlCommand("sp_kategori_sil", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@kategori_id", id);
            baglan.Open();
            int Count = komut.ExecuteNonQuery();
            baglan.Close();
            return Count;
        }

        public int Guncelle(Kategori kategori)
        {
            SqlCommand komut = new SqlCommand("sp_kategori_guncelle", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@kategori_id", kategori.kategori_id);
            komut.Parameters.AddWithValue("@kategori_ad", kategori.kategori_ad);
            baglan.Open();
            int Count = komut.ExecuteNonQuery();
            baglan.Close();
            return Count;
        }
    }
}
