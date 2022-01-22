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
    public partial class frmUrunler : Form
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");

        UrunManager manager = new UrunManager();
        BindingList<Urun> uruns;

        public frmUrunler()
        {
            InitializeComponent();
            uruns = new BindingList<Urun>(manager.Listele());

            lstId.DataSource =lstId.DataSource= lstAd.DataSource = lstStokAdet.DataSource = lstKategori.DataSource =uruns;
            lstId.DisplayMember = "Id";
            lstAd.DisplayMember = "ad";
            lstStokAdet.DisplayMember = "stokAdet";
            //lstkategorid.DisplayMember = "kategori_id";
            lstKategori.DisplayMember = "kategori_ad";
            //lstZimmet.DisplayMember = "zimmet";
        }

        private void frmUrunler_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_Kategoriler", baglan);
            SqlDataReader rd = komut.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd["kategori_ad"] );
            }
            baglan.Close();
            Listele();

            
            

        }

        void Listele()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select Id,ad,StokAdet,kategori_ad from tbl_urunler ",baglan);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //frmUrunEkle ekle = new frmUrunEkle();
            //if (ekle.ShowDialog() == DialogResult.OK)
            //{
            //    ekle.urun.Id = manager.Ekle(ekle.urun);
            //    uruns.Add(ekle.urun);
            //}
            //Listele();

            if (txtAd.Text == "" || txtStok.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz!!!");
            }
            else
            {
                baglan.Open();
                SqlCommand ekle = new SqlCommand("insert into tbl_urunler (ad,StokAdet,kategori_ad)values(@ad,@stok,@kat)", baglan);
                ekle.Parameters.AddWithValue("@ad", txtAd.Text);
                ekle.Parameters.AddWithValue("@stok", txtStok.Text);
                ekle.Parameters.AddWithValue("@kat", comboBox1.Text);
                //ekle.Parameters.AddWithValue("@zim", cmbzimmetli.Text);
                ekle.ExecuteNonQuery();
                baglan.Close();
                Listele();
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //if (lstId.SelectedItem != null)
            //{
            //    Urun urun = lstId.SelectedItem as Urun;
            //    if (MessageBox.Show(urun.Ad + " adlı urunü silmek istiyor musunuz?", "Kişi Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        if (manager.Sil(urun) > 0)
            //        {
            //            uruns.Remove(urun);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Urun Silinemedi!!!", "Kisi Sil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //    }

            //}
            //Listele();

            if (txtAd.Text == "" || txtStok.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz!!!");
            }
            else
            {
                baglan.Open();
                SqlCommand sil = new SqlCommand("delete from tbl_urunler where Id=@id", baglan);
                sil.Parameters.AddWithValue("@id", textBox5.Text);
                sil.ExecuteNonQuery();
                baglan.Close();
                Listele();
                MessageBox.Show("Kayıt Silindi!!!");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox5.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtStok.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            //cmbzimmetli.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //if (lstAd.SelectedItem != null)
            //{
            //    Urun urun = lstId.SelectedItem as Urun;
            //    frmUrunEkle frmUrunEkle = new frmUrunEkle(urun);
            //    if (frmUrunEkle.ShowDialog() == DialogResult.OK)
            //    {
            //        if (manager.Guncelle(frmUrunEkle.urun) > 0)
            //        {
            //            uruns[lstAd.SelectedIndex] = frmUrunEkle.urun;
            //        }
            //    }
            //}
            //Listele();

            if (txtAd.Text == "" || txtStok.Text == "" || comboBox1.Text == "" )
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz!!!");
            }
            else
            {
                baglan.Open();
                SqlCommand guncelle = new SqlCommand("update tbl_urunler set ad=@ad,StokAdet=@stok,kategori_ad=@kat where Id=@id", baglan);
                guncelle.Parameters.AddWithValue("@ad", txtAd.Text);
                guncelle.Parameters.AddWithValue("@stok", txtStok.Text);
                guncelle.Parameters.AddWithValue("@kat", comboBox1.Text);
                //guncelle.Parameters.AddWithValue("@zim", cmbzimmetli.Text);
                guncelle.Parameters.AddWithValue("@id", textBox5.Text);
                guncelle.ExecuteNonQuery();
                baglan.Close();
                Listele();
                MessageBox.Show("Kayıt güncellendi!!!");
            }

        }
    }
}
