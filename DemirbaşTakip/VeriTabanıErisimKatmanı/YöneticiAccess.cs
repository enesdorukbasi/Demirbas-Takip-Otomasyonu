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
    public class YöneticiAccess
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");
        public List<Yönetici> Listele()
        {
            List<Yönetici> yöneticis = new List<Yönetici>();
            SqlCommand komut = new SqlCommand("sp_yonetici_listele", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            baglan.Open();
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                Yönetici yönetici = new Yönetici
                {
                    Id = Convert.ToInt32(reader["id"]),
                    AdSoyad = reader["AdSoyad"].ToString(),
                    Unvan = reader["Unvan"].ToString(),
                    Sifre =Convert.ToInt32( reader["Sifre"].ToString())
                };
                yöneticis.Add(yönetici);
            }
            reader.Close();
            baglan.Close();
            return yöneticis;
        }

        public int Ekle(Yönetici yönetici)
        {
            SqlCommand komut = new SqlCommand("sp_yönetici_ekle", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@AdSoyad", yönetici.AdSoyad);
            komut.Parameters.AddWithValue("@Unvan", yönetici.Unvan);
            komut.Parameters.AddWithValue("@Sifre", yönetici.Sifre);
            baglan.Open();
            yönetici.Id = Convert.ToInt32(komut.ExecuteScalar());
            baglan.Close();

            return yönetici.Id;
        }

        public int Sil(int id)
        {
            SqlCommand komut = new SqlCommand("sp_yonetici_sil", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Id", id);
            baglan.Open();
            int Count = komut.ExecuteNonQuery();
            baglan.Close();
            return Count;
        }

        public int Guncelle(Yönetici yönetici)
        {
            SqlCommand komut = new SqlCommand("sp_yönetici_guncelle", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", yönetici.Id);
            komut.Parameters.AddWithValue("@AdSoyad", yönetici.AdSoyad);
            komut.Parameters.AddWithValue("@Unvan", yönetici.Unvan);
            komut.Parameters.AddWithValue("@Sifre", yönetici.Sifre);
            baglan.Open();
            int Count = komut.ExecuteNonQuery();
            baglan.Close();
            return Count;
        }

    }
}
