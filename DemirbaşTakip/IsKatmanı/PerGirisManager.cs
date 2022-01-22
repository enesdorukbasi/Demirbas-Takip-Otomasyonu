using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlıkKatmanı;
using VeriTabanıErisimKatmanı;

namespace IsKatmanı
{
    public class PerGirisManager
    {
        KullaniciGirisAccess access = new KullaniciGirisAccess();

        public bool GirisYap(Personel personel)
        {
            return access.Login(personel);
        }
    }
}
