using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class product_eligibility_declare
    {
        public long id { get; set; }
        public long product_id { get; set; }
        public bool? category_match { get; set; }
        public bool? suitability_match { get; set; }
        public bool? vendor_guidance { get; set; }
        public bool? mtd { get; set; }
        public bool? ecom_self_use { get; set; }
        public bool? cyber_security_certificate { get; set; }
        public bool? sme_customer_base { get; set; }
        public bool? cloud_based { get; set; }
        public bool? list_price_purchase { get; set; }

        public virtual product1 product { get; set; }
    }
}
