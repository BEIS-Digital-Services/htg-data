#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class product_price_secondary_metric
    {
        public long product_price_sec_id { get; set; }
        public long? product_price_id { get; set; }
        public long? product_price_sec_description_id { get; set; }
        public decimal metric_no { get; set; }
        public string metric_unit { get; set; }
        public virtual product_price product_price { get; set; }
        public virtual product_price_secondary_description product_price_secondary_description { get; set; }
    }
}