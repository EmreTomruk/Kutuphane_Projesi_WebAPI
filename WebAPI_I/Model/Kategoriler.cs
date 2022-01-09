using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_I.Model
{
    public partial class Kategoriler
    {
        public Kategoriler()
        {
            KategoriKitaps = new HashSet<KategoriKitap>();
            KitapKategoris = new HashSet<KitapKategori>();
        }

        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }

        public virtual ICollection<KategoriKitap> KategoriKitaps { get; set; }
        public virtual ICollection<KitapKategori> KitapKategoris { get; set; }
    }
}
