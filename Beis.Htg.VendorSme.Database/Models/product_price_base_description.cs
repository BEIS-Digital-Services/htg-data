using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class product_price_base_description
    {
        public product_price_base_description()
        {
            product_price_base_metric_prices = new HashSet<product_price_base_metric_price>();
        }

        public long product_price_base_description_id { get; set; }
        public string product_price_basedescription { get; set; }

        public virtual ICollection<product_price_base_metric_price> product_price_base_metric_prices { get; set; }
    }
}