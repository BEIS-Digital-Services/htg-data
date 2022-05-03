using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class additional_cost
    {
        public long additional_cost_id { get; set; }
        public long product_price_id { get; set; }
        public long additional_cost_desc_id { get; set; }
        public decimal additionalCost { get; set; }
        public decimal additional_cost_no { get; set; }
        public string additional_cost_freq { get; set; }
        public bool additional_cost_mandatory_flag { get; set; }

        public virtual additional_cost_desc additional_cost_desc { get; set; }
        public virtual product_price product_price { get; set; }
    }
}
