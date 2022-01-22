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
    public class KullaniciGirisAccess
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");
        public bool Login(Personel user)
        {
            SqlCommand komut = new SqlCommand("sp_per_giris", baglan);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@ad", user.Ad);
            komut.Parameters.AddWithValue("@sicil", user.Sicil);

            baglan.Open();
            bool sonuc = Convert.ToBoolean(komut.ExecuteScalar());
            baglan.Close();
            return sonuc;
        }
    }
}
