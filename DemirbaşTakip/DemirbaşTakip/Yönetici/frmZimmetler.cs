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
    public partial class frmZimmetler : Form
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");

        ZimmetManager manager = new ZimmetManager();
        BindingList<Zimmet> zimmets;

        public frmZimmetler()
        {
            InitializeComponent();
            zimmets = new BindingList<Zimmet>(manager.Listele());

            //lstId.DataSource = lstAd.DataSource = lstTarih.DataSource = lstKategori.DataSource =lstUrun.DataSource=lstPerAd.DataSource=lstPerSoyad.DataSource= zimmets;
            //lstId.DisplayMember = "zimet_id";
            //lstAd.DisplayMember = "zimmet_ad";
            //lstTarih.DisplayMember = "zimmet_tarih";
            //lstKategori.DisplayMember = "kategori_ad";
            //lstUrun.DisplayMember = "urunad";
            //lstPerAd.DisplayMember = "perad";
            //lstPerSoyad.DisplayMember = "persoyad";
        }

        private void frmZimmetler_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("select * from tbl_kategoriler", baglan);
            SqlDataReader rd1 = komut1.ExecuteReader();
            while (rd1.Read())
            {
                cmbKategori.Items.Add(rd1["kategori_ad"]);
            }
            baglan.Close();
            Listele();

            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_personel", baglan);
            SqlDataReader rd = komut.ExecuteReader();
            while (rd.Read())
            {
                cmbZimmetli.Items.Add(rd["ad"] + " " + rd["soyad"]);
            }
            baglan.Close();
            Listele();

            baglan.Open();
            SqlCommand komut2 = new SqlCommand("select * from tbl_urunler", baglan);
            SqlDataReader rd2 = komut2.ExecuteReader();
            while (rd2.Read())
            {
                cmbUrunler.Items.Add(rd2["ad"]);
            }
            baglan.Close();
            Listele();
        }

        void Listele()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select zimmet_id,zimmet_ad,zimmet_tarih,kategori_ad,urunad,perad from tbl_zimmet", baglan);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text==""||mskTarih.Text==""||cmbKategori.Text==""||cmbUrunler.Text==""||cmbZimmetli.Text=="")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!!!");
            }
            else
            {
                //frmzimmet frmzimmet = new frmzimmet();
                //if (frmzimmet.ShowDialog() == DialogResult.OK)
                //{
                baglan.Open();
                //frmzimmet.zimmet.zimmetid = manager.Ekle(frmzimmet.zimmet);
                //zimmets.Add(frmzimmet.zimmet);
                //frmzimmet frmzim = new frmzimmet();
                SqlCommand komut = new SqlCommand("insert into tbl_Zimmet (zimmet_ad,zimmet_tarih,kategori_ad,urunad,perad)values(@zad,@tarih,@kad,@uad,@pad)", baglan);
                //komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@zad", txtAd.Text);
                komut.Parameters.AddWithValue("@tarih", mskTarih.Text);
                komut.Parameters.AddWithValue("@kad", cmbKategori.Text);
                komut.Parameters.AddWithValue("@uad", cmbUrunler.Text);
                komut.Parameters.AddWithValue("@pad", cmbZimmetli.Text);
                //komut.Parameters.AddWithValue("@psoyad", txtPerSoyad.Text);

                komut.ExecuteNonQuery();
                baglan.Close();
                //}
                Listele();
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || mskTarih.Text == "" || cmbKategori.Text == "" || cmbUrunler.Text == "" || cmbZimmetli.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!!!");
            }
            else
            {
                baglan.Open();
                SqlCommand sil = new SqlCommand("delete from tbl_zimmet where zimmet_id=@id", baglan);
                sil.Parameters.AddWithValue("@id", txtId.Text);
                sil.ExecuteNonQuery();
                baglan.Close();
                Listele();
                temizle();
                MessageBox.Show("Kayıt Silindi!!!");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            mskTarih.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbKategori.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            cmbUrunler.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            cmbZimmetli.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        void temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            mskTarih.Text = "";
            cmbUrunler.Text = "";
            cmbZimmetli.Text = "";
            cmbKategori.Text = "";
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || mskTarih.Text == "" || cmbKategori.Text == "" || cmbUrunler.Text == "" || cmbZimmetli.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!!!");
            }
            else
            {
                baglan.Open();
                SqlCommand guncelle = new SqlCommand("update tbl_zimmet set zimmet_ad=@zad,kategori_ad=@kat,urunad=@uad,perad=@pad where zimmet_id=@id", baglan);
                guncelle.Parameters.AddWithValue("@zad", txtAd.Text);
                //guncelle.Parameters.AddWithValue("@tarih", mskTarih.Text);
                guncelle.Parameters.AddWithValue("@kat", cmbKategori.Text);
                guncelle.Parameters.AddWithValue("@uad", cmbUrunler.Text);
                guncelle.Parameters.AddWithValue("@pad", cmbZimmetli.Text);
                guncelle.Parameters.AddWithValue("@id", txtId.Text);
                guncelle.ExecuteNonQuery();
                baglan.Close();
                Listele();
                temizle();
                MessageBox.Show("Kayıt güncellendi!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
