using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlıkKatmanı;
using VeriTabanıErisimKatmanı;

namespace IsKatmanı
{
    public class KategoriManager
    {
        KategoriAccess access = new KategoriAccess();

        public List<Kategori> Listele()
        {
            return access.Listele();
        }

        public int Ekle(Kategori kategori)
        {
            return access.Ekle(kategori);
        }

        public int Sil(int id)
        {
            return access.Sil(id);
        }

        public int Sil(Kategori kategori)
        {
            return access.Sil(kategori.kategori_id);
        }

        public int Guncelle(Kategori kategori)
        {
            return access.Guncelle(kategori);
        }
    }
}
