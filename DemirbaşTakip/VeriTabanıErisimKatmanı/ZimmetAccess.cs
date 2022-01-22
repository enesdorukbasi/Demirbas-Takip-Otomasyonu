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
    public class ZimmetAccess
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");
        public List<Zimmet> Listele()
        {
            List<Zimmet> zimmets = new List<Zimmet>();
            SqlCommand komut = new SqlCommand("sp_zimmet_listele", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            baglan.Open();
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                Zimmet zimmet = new Zimmet
                {
                    zimmetid = Convert.ToInt32(reader["zimmet_id"]),
                    zimmetad = reader["zimmet_ad"].ToString(),
                    date = Convert.ToDateTime(reader["zimmet_tarih"].ToString()),
                    //kategorid=Convert.ToInt32( reader["kategori_id"].ToString()),
                    kategoriad = reader["kategori_ad"].ToString(),
                    urunad = reader["urunad"].ToString(),
                    perad = reader["perad"].ToString(),
                    persoyad = reader["persoyad"].ToString()

                };
                zimmets.Add(zimmet);
            }
            reader.Close();
            baglan.Close();
            return zimmets;
        }

        public int Ekle(Zimmet zimmet)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_Zimmet (zimmet_ad,zimmet_tarih,kategori_ad,urunad,perad,persoyad)values(@zad,@tarih,@kad,@uad,@pad,@psoyad)", baglan);
            //komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@zad", zimmet.zimmetad);
            komut.Parameters.AddWithValue("@tarih", zimmet.date.ToString());
            komut.Parameters.AddWithValue("@kad", zimmet.kategoriad);
            komut.Parameters.AddWithValue("@uad", zimmet.urunad);
            komut.Parameters.AddWithValue("@pad", zimmet.perad);
            komut.Parameters.AddWithValue("@psoyad", zimmet.persoyad);
            komut.ExecuteNonQuery();
            zimmet.zimmetid = Convert.ToInt32(komut.ExecuteScalar());
            baglan.Close();

            return zimmet.zimmetid;
        }

        public int Sil(int id)
        {
            SqlCommand komut = new SqlCommand("sp_zimmet_sil", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@zimmet_id", id);
            baglan.Open();
            int Count = komut.ExecuteNonQuery();
            baglan.Close();
            return Count;
        }

        public int Guncelle(Zimmet zimmet)
        {
            SqlCommand komut = new SqlCommand("sp_zimmet_guncelle", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@zimmet_id", zimmet.zimmetid);
            komut.Parameters.AddWithValue("@zimmet_ad", zimmet.zimmetad);
            komut.Parameters.AddWithValue("@zimmet_tarih", zimmet.date);
            komut.Parameters.AddWithValue("@kategori_ad", zimmet.kategoriad);
            komut.Parameters.AddWithValue("@urunad", zimmet.urunad);
            komut.Parameters.AddWithValue("@perad", zimmet.perad);
            komut.Parameters.AddWithValue("@persoyad", zimmet.persoyad);
            baglan.Open();
            int Count = komut.ExecuteNonQuery();
            baglan.Close();
            return Count;
        }

    }
}
