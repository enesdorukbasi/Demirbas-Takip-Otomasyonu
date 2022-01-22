using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlıkKatmanı;
using VeriTabanıErisimKatmanı;

namespace IsKatmanı
{
    public class UrunManager
    {
        UrunAccess access = new UrunAccess();

        public List<Urun> Listele()
        {
            return access.Listele();
        }

        public int Ekle(Urun urun)
        {
            return access.Ekle(urun);
        }

        public int Sil(int id)
        {
            return access.Sil(id);
        }

        public int Sil(Urun urun)
        {
            return access.Sil(urun.Id);
        }

        public int Guncelle(Urun urun)
        {
            return access.Guncelle(urun);
        }

    }
}
