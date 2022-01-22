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
using VeriTabanıErisimKatmanı;

namespace DemirbaşTakip
{
    

    public partial class Form1 : Form
    {
        
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DemirbasDB.mdf;Integrated Security=True");

        PersonelManager manager = new PersonelManager();
        BindingList<Personel> personels;
        
        public Form1()
        {
            InitializeComponent();
            personels = new BindingList<Personel>(manager.Listele());
            lstId.DataSource = lstAd.DataSource = lstSoyad.DataSource = lstSicil.DataSource = personels;
           
            lstId.DisplayMember = "Id";
            lstAd.DisplayMember = "ad";
            lstSoyad.DisplayMember = "soyad";
            lstSicil.DisplayMember = "sicil";
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from tbl_personel", baglan);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmPersonel perfrm = new frmPersonel();
            if (perfrm.ShowDialog()==DialogResult.OK)
            {
                perfrm.personel.Id = manager.Ekle(perfrm.personel);
                personels.Add(perfrm.personel);
            }
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstId.SelectedItem!=null)
            {
                Personel personel = lstId.SelectedItem as Personel;
                if (MessageBox.Show(personel.Ad + " " + personel.Soyad + " adlı kişiyi silmek istiyor musunuz?", "Kişi Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (manager.Sil(personel)>0)
                    {
                        personels.Remove(personel);
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
            if (lstAd.SelectedItem!=null)
            {
                Personel personel = lstId.SelectedItem as Personel;
                frmPersonel frmPersonel = new frmPersonel(personel);
                if (frmPersonel.ShowDialog()==DialogResult.OK)
                {
                    if (manager.Guncelle(frmPersonel.personel)>0)
                    {
                        personels[lstAd.SelectedIndex] = frmPersonel.personel;
                    }
                }
            }
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            lstId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            lstAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            lstSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            lstSicil.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            frmKategori kategori = new frmKategori();
            kategori.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUrunler urun = new frmUrunler();
            urun.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu sayfayı görüntülemek için yetkiniz bulunmamaktadır....Yanlızca yönetici girişi yapılabilir!!!");
            //frmZimmetler zimmet = new frmZimmetler();
            //zimmet.Show();
        }
    }
}
