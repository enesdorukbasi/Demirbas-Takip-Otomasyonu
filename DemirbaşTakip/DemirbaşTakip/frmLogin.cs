using IsKatmanı;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VarlıkKatmanı;

namespace DemirbaşTakip
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");


        private void btngiris_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_personel where Ad=@ad and Sicil=@sifre", baglan);
            cmd.Parameters.AddWithValue("@ad", cmbKullanici.Text);
            cmd.Parameters.AddWithValue("@sifre", txtsifre.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                frmPersonelAnaSayfa frmPersonelAnaSayfa = new frmPersonelAnaSayfa();
                frmPersonelAnaSayfa.Show();
                this.Hide();
            }
            else
            {
                lblhata.Visible = true;
                MessageBox.Show("Yanlış Giriş Yaptınız...", "HATA!!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            baglan.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Yönetici where AdSoyad=@adsoyad and Sifre=@sifre", baglan);
            cmd.Parameters.AddWithValue("@adsoyad", cmbKullanici.Text);
            cmd.Parameters.AddWithValue("@sifre", txtsifre.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                frmYönetici frmYönetici = new frmYönetici();
                frmYönetici.Show();
                this.Hide();
            }
            else
            {
                lblhata.Visible = true;
                MessageBox.Show("Yanlış Giriş Yaptınız...", "HATA!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglan.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd1 = new SqlCommand("select * from tbl_Yönetici",baglan);
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read())
            {
                cmbKullanici.Items.Add(rd1[1]);
            }
            baglan.Close();

            baglan.Open();
            SqlCommand cmd2 = new SqlCommand("select * from tbl_personel", baglan);
            SqlDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                cmbKullanici.Items.Add(rd2[1]);
            }
            baglan.Close();
        }

        private void CheckSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSifreGoster.Checked)
            {
                txtsifre.PasswordChar = '\0';
            }
            else
            {
                txtsifre.PasswordChar = '*';
            }
        }
    }
}
