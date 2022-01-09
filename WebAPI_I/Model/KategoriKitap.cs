using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_I.Model
{
    public partial class KategoriKitap
    {
        public int KategorilerKategoriId { get; set; }
        public int KitaplarKitapId { get; set; }

        public virtual Kategoriler KategorilerKategori { get; set; }
        public virtual Kitaplar KitaplarKitap { get; set; }
    }
}
