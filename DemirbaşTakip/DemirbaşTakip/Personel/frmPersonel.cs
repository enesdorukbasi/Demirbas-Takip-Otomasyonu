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
    public partial class frmPersonel : Form
    {
        public Personel personel { get; set; }

        public frmPersonel():this(new Personel()) { }

        public frmPersonel(Personel personel)
        {
            InitializeComponent();
            this.personel = personel;

            txtAd.Text = personel.Ad;
            txtSoyad.Text = personel.Soyad;
            txtSicil.Text = personel.Sicil;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            personel.Ad = txtAd.Text;
            personel.Soyad = txtSoyad.Text;
            personel.Sicil = txtSicil.Text;
        }
    }
}
