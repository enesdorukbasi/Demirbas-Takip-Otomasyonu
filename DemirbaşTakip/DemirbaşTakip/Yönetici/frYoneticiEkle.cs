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
    public partial class frYoneticiEkle : Form
    {
        public Yönetici yönetici { get; set; }

        public frYoneticiEkle():this(new Yönetici()) { }

        public frYoneticiEkle(Yönetici yönetici)
        {
            InitializeComponent();
            this.yönetici = yönetici;

            txtAd.Text = yönetici.AdSoyad;
            txtSifre.Text =Convert.ToInt32(yönetici.Sifre).ToString();
            txtUnvan.Text = yönetici.Unvan;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            yönetici.AdSoyad = txtAd.Text;
            yönetici.Sifre =Convert.ToInt32( txtSifre.Text.ToString()) ;
            yönetici.Unvan = txtUnvan.Text;
        }
    }
}
