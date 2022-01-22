using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemirbaşTakip
{
    public partial class frmYönetici : Form
    {
        public frmYönetici()
        {
            InitializeComponent();
        }

        private void pcbZimmet_Click(object sender, EventArgs e)
        {
            frmZimmetler frmZimmetler = new frmZimmetler();
            frmZimmetler.Show();
        }

        private void pcbDemirbas_Click(object sender, EventArgs e)
        {
            frmUrunVeyaKategori frmUrunVeyaKategori = new frmUrunVeyaKategori();
            frmUrunVeyaKategori.Show();
        }
        private void pcbPersonel_Click(object sender, EventArgs e)
        {
            frmPersonelVeyaMudur frmPersonelVeyaMudur = new frmPersonelVeyaMudur();
            frmPersonelVeyaMudur.Show();
        }
        private void pcbZimmet_MouseEnter(object sender, EventArgs e)
        {
            pcbZimmet.Size = new Size(230, 177);
        }

        private void pcbZimmet_MouseLeave(object sender, EventArgs e)
        {
            pcbZimmet.Size = new Size(200, 154);
        }
        private void pcbDemirbas_MouseEnter(object sender, EventArgs e)
        {
            pcbDemirbas.Size = new Size(230, 177);
        }

        private void pcbDemirbas_MouseLeave(object sender, EventArgs e)
        {
            pcbDemirbas.Size = new Size(200, 154);
        }
        private void pcbPersonel_MouseEnter(object sender, EventArgs e)
        {
            pcbPersonel.Size = new Size(230, 177);
        }

        private void pcbPersonel_MouseLeave(object sender, EventArgs e)
        {
            pcbPersonel.Size = new Size(200, 154);
        }
        private void pcbCikis_MouseEnter(object sender, EventArgs e)
        {
            pcbCikis.Size = new Size(226, 173);
        }

        private void pcbCikis_MouseLeave(object sender, EventArgs e)
        {
            pcbCikis.Size = new Size(203, 143);
        }
        private void pcbZimmet_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Zimmet Listele/Ekle/Sil/Güncelle", pcbZimmet);
        }
        private void pcbDemirbas_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Demirbas Veya Kategori Listele/Ekle/Sil/Güncelle", pcbDemirbas);
        }
        private void pcbPersonel_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Personel Veya Müdür Listele/Ekle/Sil/Güncelle", pcbPersonel);
        }
        private void pcbCikis_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Çıkış", pcbCikis);
        }

        private void pcbCikis_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }

    }
}
