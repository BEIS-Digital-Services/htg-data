using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class product
    {
        public product()
        {
            product_prices = new HashSet<product_price>();
        }

        public long product_id { get; set; }
        public long vendor_id { get; set; }
        public string product_SKU { get; set; }
        public long product_type { get; set; }
        public string product_name { get; set; }
        public string product_version { get; set; }
        public string website_url { get; set; }
        public string product_description { get; set; }
        public string cyber_complance { get; set; }
        public string minimum_software_requirements { get; set; }
        public string price { get; set; }
        public string sales_discount { get; set; }
        public string other_capabilities { get; set; }
        public string sme_support { get; set; }
        public string target_customer { get; set; }
        public string ratings { get; set; }
        public string retention_rate { get; set; }
        public string customer_base { get; set; }
        public int status { get; set; }
        public string product_logo { get; set; }
        public string redemption_url { get; set; }
        public string edit_log { get; set; }
        public string column23 { get; set; }
        public string other_compatability { get; set; }
        public string review_url { get; set; }
        public string draft_product_description { get; set; }
        public string draft_other_capabilities { get; set; }
        public string draft_other_compatability { get; set; }
        public string draft_review_url { get; set; }

        public virtual ICollection<product_price> product_prices { get; set; }
    }
}
