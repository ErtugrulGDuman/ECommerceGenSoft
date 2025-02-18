using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Conrete
{
    public class Siparis : BaseEntity
    {
        public int KullaniciId { get; set; }
        public DateTime SiparisTarihi { get; set; } = DateTime.Now;
        public decimal ToplamTutar { get; set; }
        public string SiparisNumarasi { get; set; }
        public SiparisDurumu SiparisDurumu { get; set; }

        public string TeslimatAdresi { get; set; }
        public string? TeslimatNotu { get; set; }

        public virtual Kullanici Kullanici { get; set; }
        public virtual ICollection<SiparisDetay> SiparisDetaylari { get; set; }

        public Siparis()
        {
            SiparisDetaylari = new HashSet<SiparisDetay>();
            SiparisNumarasi = $"SP{DateTime.Now:yyyyMMddHHmmss}";
        }
    }
}