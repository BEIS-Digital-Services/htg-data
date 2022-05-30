using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class product_price_base_metric_price
    {
        public long product_price_base_id { get; set; }
        public long? product_price_id { get; set; }
        public long? product_price_base_description_id { get; set; }
        public decimal product_price_amount { get; set; }
        public decimal product_price_percentage { get; set; }
        public int product_price_no_users { get; set; }

        public virtual product_price product_price { get; set; }
        public virtual product_price_base_description product_price_base_description { get; set; }
    }
}
