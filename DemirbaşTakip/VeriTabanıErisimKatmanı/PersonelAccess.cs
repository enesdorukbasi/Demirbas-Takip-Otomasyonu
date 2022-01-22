using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlıkKatmanı;
using System.Data;

namespace VeriTabanıErisimKatmanı
{
    public class PersonelAccess
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");
        public List<Personel>Listele()
        {
            List<Personel> personels = new List<Personel>();
            SqlCommand komut = new SqlCommand("sp_personel_listele",baglan);
            komut.CommandType = CommandType.StoredProcedure;
            baglan.Open();
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                Personel personel = new Personel
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Ad = reader["ad"].ToString(),
                    Soyad = reader["soyad"].ToString(),
                    Sicil = reader["sicil"].ToString()
                };
                personels.Add(personel);
            }
            reader.Close();
            baglan.Close();
            return personels;
        }

        public int Ekle(Personel personel)
        {
            SqlCommand komut = new SqlCommand("sp_personel_ekle",baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@ad", personel.Ad);
            komut.Parameters.AddWithValue("@soyad", personel.Soyad);
            komut.Parameters.AddWithValue("@sicil", personel.Sicil);
            baglan.Open();
            personel.Id = Convert.ToInt32(komut.ExecuteScalar());
            baglan.Close();

            return personel.Id;
        }

        public int Sil(int id)
        {
            SqlCommand komut = new SqlCommand("sp_personel_sil", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", id);
            baglan.Open();
            int Count = komut.ExecuteNonQuery();
            baglan.Close();
            return Count;
        }

        public int Guncelle(Personel personel)
        {
            SqlCommand komut = new SqlCommand("sp_personel_guncelle", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", personel.Id);
            komut.Parameters.AddWithValue("@ad", personel.Ad);
            komut.Parameters.AddWithValue("@soyad", personel.Soyad);
            komut.Parameters.AddWithValue("@sicil", personel.Sicil);
            baglan.Open();
            int Count = komut.ExecuteNonQuery();
            baglan.Close();
            return Count;
        }
    }
}
