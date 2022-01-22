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
    public class YoneticiGirisAccess
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");
        public bool Login1(Yönetici user)
        {
            SqlCommand komut = new SqlCommand("sp_yönetici_giris", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@AdSoyad", user.AdSoyad);
            komut.Parameters.AddWithValue("@Sifre", user.Sifre);

            baglan.Open();
            bool sonuc = Convert.ToBoolean(komut.ExecuteScalar());
            baglan.Close();
            return sonuc;
        }
    }
}
