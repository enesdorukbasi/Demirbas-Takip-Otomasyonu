using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlıkKatmanı;
using VeriTabanıErisimKatmanı;

namespace IsKatmanı
{
    public class YöneticiManager
    {
        YöneticiAccess access = new YöneticiAccess();

        public List<Yönetici> Listele()
        {
            return access.Listele();
        }

        public int Ekle(Yönetici yönetici)
        {
            return access.Ekle(yönetici);
        }

        public int Sil(int id)
        {
            return access.Sil(id);
        }

        public int Sil(Yönetici yönetici)
        {
            return access.Sil(yönetici.Id);
        }

        public int Guncelle(Yönetici yönetici)
        {
            return access.Guncelle(yönetici);
        }
    }
}
