using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlıkKatmanı;
using VeriTabanıErisimKatmanı;

namespace IsKatmanı
{
    public class ZimmetManager
    {
        ZimmetAccess access = new ZimmetAccess();

        public List<Zimmet> Listele()
        {
            return access.Listele();
        }

        public int Ekle(Zimmet zimmet)
        {
            return access.Ekle(zimmet);
        }

        public int Sil(int id)
        {
            return access.Sil(id);
        }

        public int Sil(Zimmet zimmet)
        {
            return access.Sil(zimmet.zimmetid);
        }

        public int Guncelle(Zimmet zimmet)
        {
            return access.Guncelle(zimmet);
        }
    }
}
