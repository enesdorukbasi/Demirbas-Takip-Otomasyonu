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
    public partial class frmUrunVeyaKategori : Form
    {
        public frmUrunVeyaKategori()
        {
            InitializeComponent();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            frmKategori frmKategori = new frmKategori();
            frmKategori.Show();
        }

        private void btnDemirbas_Click(object sender, EventArgs e)
        {
            frmUrunler frmUrunler = new frmUrunler();
            frmUrunler.Show();
        }
    }
}
