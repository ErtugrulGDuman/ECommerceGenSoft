using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Conrete
{
    public class Product : BaseEntity
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public int StokMiktari { get; set; }
        public string Aciklama { get; set; }
        public string? Resim { get; set; }
        public string? KisaAciklama { get; set; }
        public virtual ICollection<OrderDetail> SiparisDetaylari { get; set; }

        public Product()
        {
            SiparisDetaylari = new HashSet<OrderDetail>();
        }
    }
}
