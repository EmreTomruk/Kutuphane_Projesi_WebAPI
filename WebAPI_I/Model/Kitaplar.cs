using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace WebAPI_I.Model
{
    public partial class Kitaplar
    {
        public Kitaplar()
        {
            KategoriKitaps = new HashSet<KategoriKitap>();
            KitapKategoris = new HashSet<KitapKategori>();
            OduncVermes = new HashSet<OduncVerme>();
        }

        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public int YazarId { get; set; }
        public int YayinEviId { get; set; }
        public short SayfaSayisi { get; set; }
        public bool OduncDurumu { get; set; }
        public string Ozet { get; set; }
        public string KapakResmi { get; set; }
        public short BaskiNo { get; set; }
        public DateTime BasimTarihi { get; set; }
        public DateTime KayitTarihi { get; set; }
        
        [JsonIgnore]
        public virtual YayinEvleri YayinEvi { get; set; }
        [JsonIgnore]
        public virtual Yazarlar Yazar { get; set; }
        [JsonIgnore]
        public virtual ICollection<KategoriKitap> KategoriKitaps { get; set; }
        [JsonIgnore]
        public virtual ICollection<KitapKategori> KitapKategoris { get; set; }
        [JsonIgnore]
        public virtual ICollection<OduncVerme> OduncVermes { get; set; }
    }
}
