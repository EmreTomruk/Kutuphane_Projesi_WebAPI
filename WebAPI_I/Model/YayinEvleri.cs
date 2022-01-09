using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_I.Model
{
    public partial class YayinEvleri
    {
        public YayinEvleri()
        {
            Kitaplars = new HashSet<Kitaplar>();
        }

        public int YayinEviId { get; set; }
        public string YayinEviAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }

        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
    }
}
