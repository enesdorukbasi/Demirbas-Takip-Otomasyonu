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
    public partial class frmYöneticiLogin : Form
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");

        YöneticiManager manager = new YöneticiManager();
        BindingList<Yönetici> yöneticis;

        public frmYöneticiLogin()
        {
            InitializeComponent();
            yöneticis = new BindingList<Yönetici>(manager.Listele());
            lstId.DataSource = lstAadSoyad.DataSource = lstUnvan.DataSource = lstSifre.DataSource = yöneticis;

            lstId.DisplayMember = "Id";
            lstAadSoyad.DisplayMember = "AdSoyad";
            lstSifre.DisplayMember = "Unvan";
            lstUnvan.DisplayMember = "Sifre";
        }

        private void frmYöneticiLogin_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from tbl_Yönetici", baglan);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frYoneticiEkle perfrm = new frYoneticiEkle();
            if (perfrm.ShowDialog() == DialogResult.OK)
            {
                perfrm.yönetici.Id = manager.Ekle(perfrm.yönetici);
                yöneticis.Add(perfrm.yönetici);
            }
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstId.SelectedItem != null)
            {
                Yönetici yönetici = lstId.SelectedItem as Yönetici;
                if (MessageBox.Show(yönetici.AdSoyad+" adlı kişiyi silmek istiyor musunuz?", "Kişi Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (manager.Sil(yönetici) > 0)
                    {
                        yöneticis.Remove(yönetici);
                    }
                    else
                    {
                        MessageBox.Show("Kişi Silinemedi!!!", "Kisi Sil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lstAadSoyad.SelectedItem != null)
            {
                Yönetici yönetici = lstId.SelectedItem as Yönetici;
                frYoneticiEkle frYonetici = new frYoneticiEkle(yönetici);
                if (frYonetici.ShowDialog() == DialogResult.OK)
                {
                    if (manager.Guncelle(frYonetici.yönetici) > 0)
                    {
                        yöneticis[lstAadSoyad.SelectedIndex] = frYonetici.yönetici;
                    }
                }
            }
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
