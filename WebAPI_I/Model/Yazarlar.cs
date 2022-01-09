using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_I.Model
{
    public partial class Yazarlar
    {
        public Yazarlar()
        {
            Kitaplars = new HashSet<Kitaplar>();
        }

        public int YazarId { get; set; }
        public string YazarAdi { get; set; }
        public string OzetBiyografi { get; set; }

        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
    }
}
