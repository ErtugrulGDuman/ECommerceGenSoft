using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Conrete
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public DateTime SiparisTarihi { get; set; } = DateTime.Now;
        public decimal ToplamTutar { get; set; }
        public string SiparisNumarasi { get; set; }
        public SiparisDurumu SiparisDurumu { get; set; }
        public string TeslimatAdresi { get; set; }
        public string? TeslimatNotu { get; set; }
        public virtual User Kullanici { get; set; }
        public virtual ICollection<OrderDetail> SiparisDetaylari { get; set; }

        public Order()
        {
            SiparisDetaylari = new HashSet<OrderDetail>();
            SiparisNumarasi = $"SP{DateTime.Now:yyyyMMddHHmmss}";
        }
    }
}