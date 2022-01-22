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
    public partial class frmPersonelVeyaMudur : Form
    {
        public frmPersonelVeyaMudur()
        {
            InitializeComponent();
        }

        private void btnMudur_Click(object sender, EventArgs e)
        {
            frmYöneticiLogin frmYöneticiLogin = new frmYöneticiLogin();
            frmYöneticiLogin.Show();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            PersonelEkle personelEkle = new PersonelEkle();
            personelEkle.Show();
        }
    }
}
