using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Conrete
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public DateTime? GuncellemeTarihi { get; set; }
        public bool SilindiMi { get; set; } = false;
        public bool AktifMi { get; set; } = true;
    }
}
