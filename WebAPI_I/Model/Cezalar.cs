using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_I.Model
{
    public partial class Cezalar
    {
        public int CezaId { get; set; }
        public int UyeId { get; set; }
        public string Aciklama { get; set; }
        public DateTime CezaTarih { get; set; }

        public virtual AspNetUser Uye { get; set; }
    }
}
