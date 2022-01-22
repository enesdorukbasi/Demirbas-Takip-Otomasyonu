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
    public partial class frmKategori : Form
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");

        KategoriManager manager = new KategoriManager();
        BindingList<Kategori> kategoris;

        public frmKategori()
        {
            InitializeComponent();
            kategoris = new BindingList<Kategori>(manager.Listele());

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from tbl_kategoriler", baglan);
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void frmKategori_Load(object sender, EventArgs e)
        {
            
        }

        void Listele()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from tbl_kategoriler", baglan);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmKategoriEkle ekle = new frmKategoriEkle();
            if (ekle.ShowDialog() == DialogResult.OK)
            {
                ekle.kategori.kategori_id = manager.Ekle(ekle.kategori);
                kategoris.Add(ekle.kategori);
            }
            Listele();
        }
        public string adı;
        private void btnSil_Click(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            if (MessageBox.Show( "Kategoriyi silmek istiyor musunuz?", "Kategori Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                baglan.Open();
                SqlCommand sil = new SqlCommand("delete from tbl_kategoriler where kategori_id=@id",baglan);
                sil.Parameters.AddWithValue("@id", lblad.Text);
                sil.ExecuteNonQuery();
                baglan.Close();
                Listele();
                MessageBox.Show("Kayıt Silindi!!!");
            }
            else
            {
                MessageBox.Show("Kategori Silinemedi!!!", "Kategori Sil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            lblad.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            lbladı.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtguncelle.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtguncelle.Text=="")
            {
                MessageBox.Show("Boş Bir satır güncelleme yapamazsınız geçerli bir değer girin.");
            }
            else
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("update tbl_Kategoriler set kategori_ad=@ad where kategori_id=@id", baglan);
                komut.Parameters.AddWithValue("@ad", txtguncelle.Text);
                komut.Parameters.AddWithValue("@id", lblad.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                Listele();
                txtguncelle.Text = "";
            }
            
        }
    }
}
