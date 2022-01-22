using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemirbaşTakip
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //frmLogin login = new frmLogin();
            //frmYöneticiLogin login1 = new frmYöneticiLogin();

            
            //if (login.ShowDialog()==DialogResult.OK)
            //{
                Application.Run(new frmLogin());
            //}
           
            //else if (login1.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new frmYöneticiLogin());
            //}





        }
    }
}
