using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Conrete
{
    public class Urun : BaseEntity
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public int StokMiktari { get; set; }
        public string Aciklama { get; set; }
        public string? Resim { get; set; }
        public string? KisaAciklama { get; set; }
        public virtual ICollection<SiparisDetay> SiparisDetaylari { get; set; }

        public Urun()
        {
            SiparisDetaylari = new HashSet<SiparisDetay>();
        }
    }
}
