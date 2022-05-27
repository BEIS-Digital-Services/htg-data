using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class user_discount
    {
        public long user_discount_id { get; set; }
        public long? product_price_id { get; set; }
        public int min_licenses { get; set; }
        public int max_licenses { get; set; }
        public decimal discount_price { get; set; }
        public decimal discount_percentage { get; set; }
        public string discount_sku { get; set; }

        public virtual product_price product_price { get; set; }
    }
}
