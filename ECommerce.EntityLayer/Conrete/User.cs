using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Conrete
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;

        public virtual ICollection<Order> Siparisler { get; set; }

        public User()
        {
            Siparisler = new HashSet<Order>();
        }
    }
}