using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlıkKatmanı
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int StokAdet { get; set; }
        public int kategori_id { get; set; }
        public string kategori_ad { get; set; }
        public string zimmet { get; set; }
    }
}
