using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class product_compare_entry
    {
        public long id { get; set; }
        public long product_id { get; set; }
        public long compare_id { get; set; }
        public string item_value { get; set; }

        public virtual product_compare compare { get; set; }
        public virtual product1 product { get; set; }
    }
}
