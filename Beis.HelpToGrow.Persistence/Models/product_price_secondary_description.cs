using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class product_price_secondary_description
    {
        public product_price_secondary_description()
        {
            product_price_secondary_metrics = new HashSet<product_price_secondary_metric>();
        }

        public long product_price_sec_description_id { get; set; }
        public string product_price_sec_description { get; set; }

        public virtual ICollection<product_price_secondary_metric> product_price_secondary_metrics { get; set; }
    }
}