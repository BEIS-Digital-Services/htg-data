using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class settings_product_capability
    {
        public long capability_id { get; set; }
        public long product_type { get; set; }
        public string capability_name { get; set; }
        public int sort_order { get; set; }
    }
}
