using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlıkKatmanı
{
    public class Zimmet
    {
        public int zimmetid { get; set; }
        public string zimmetad { get; set; }
        public DateTime date { get; set; }
        public int kategorid { get; set; }
        public string kategoriad { get; set; }
        public int urunid { get; set; }
        public string urunad { get; set; }
        public int perid { get; set; }
        public string perad { get; set; }
        public string persoyad { get; set; }
    }
}
