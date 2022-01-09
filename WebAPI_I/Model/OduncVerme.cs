using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_I.Model
{
    public partial class OduncVerme
    {
        public int OduncVermeId { get; set; }
        public int UyeId { get; set; }
        public int KitapId { get; set; }
        public DateTime OduncVerildigiTarih { get; set; }
        public DateTime BeklenenIadeTarihi { get; set; }
        public DateTime GerceklesenIadeTarihi { get; set; }
        public bool IadeEdildi { get; set; }

        public virtual Kitaplar Kitap { get; set; }
        public virtual AspNetUser Uye { get; set; }
    }
}
