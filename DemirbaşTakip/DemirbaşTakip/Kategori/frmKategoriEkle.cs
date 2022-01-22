using IsKatmanı;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VarlıkKatmanı;

namespace DemirbaşTakip
{
    public partial class frmKategoriEkle : Form
    {
        public string ad,aktar;

        KategoriManager manager;
        BindingList<Kategori> kategoris;

        public Kategori kategori { get; set; }
        public frmKategoriEkle():this(new Kategori()) {}

        public frmKategoriEkle(Kategori kategori)
        {
            InitializeComponent();

            manager = new KategoriManager();
            kategoris = new BindingList<Kategori>(manager.Listele());

            this.kategori = kategori;
            txtAd.Text = kategori.kategori_ad;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            kategori.kategori_ad = txtAd.Text;
            lblaktar.Text = txtAd.Text;
            aktar = lblaktar.Text;
        }

        private void frmKategoriEkle_Load(object sender, EventArgs e)
        {
            txtAd.Text = ad;
            
        }
    }
}
