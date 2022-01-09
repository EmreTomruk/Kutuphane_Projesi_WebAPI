using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_I.Model
{
    public partial class KitapKategori
    {
        public int KitapKategoriId { get; set; }
        public int KitapId { get; set; }
        public int KategoriId { get; set; }

        public virtual Kategoriler Kategori { get; set; }
        public virtual Kitaplar Kitap { get; set; }
    }
}
