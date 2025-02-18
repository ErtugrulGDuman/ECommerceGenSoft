﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Conrete
{
    public class SiparisDetay : BaseEntity
    {
        public int SiparisId { get; set; }
        public int UrunId { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal ToplamFiyat { get; set; }
        public string? Not { get; set; }
        public virtual Siparis Siparis { get; set; }
        public virtual Urun Urun { get; set; }
    }

    public enum SiparisDurumu
    {
        Hazirlaniyor = 0,
        Onaylandi = 1,
        KargoyaVerildi = 2,
        TeslimEdildi = 3,
        IptalEdildi = 4
    }
}
