using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlıkKatmanı;
using VeriTabanıErisimKatmanı;

namespace IsKatmanı
{
    public class YönGirisManager
    {
        YoneticiGirisAccess access = new YoneticiGirisAccess();

        public bool GirisYap1(Yönetici yönetici)
        {
            return access.Login1(yönetici);
        }
    }
}
