using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class settings_category_type
    {
        public long category_type_id { get; set; }
        public long product_type { get; set; }
        public string category_name { get; set; }
        public int sort_order { get; set; }
    }
}
