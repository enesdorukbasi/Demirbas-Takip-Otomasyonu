using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlıkKatmanı;
using VeriTabanıErisimKatmanı;

namespace IsKatmanı
{
    public class PersonelManager
    {
        PersonelAccess access = new PersonelAccess();

        public List<Personel> Listele()
        {
            return access.Listele();
        }

        public int Ekle(Personel personel)
        {
            return access.Ekle(personel);
        }

        public int Sil(int id)
        {
            return access.Sil(id);
        }

        public int Sil(Personel personel)
        {
            return access.Sil(personel.Id);
        }

        public int Guncelle(Personel personel)
        {
            return access.Guncelle(personel);
        }
    }
}
