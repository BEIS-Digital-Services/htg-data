using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class vendor_reconciliation_sale
    {
        public long reconciliation_sales_id { get; set; }
        public string token_code { get; set; }
        public string vendor_id { get; set; }
        public string product_sku { get; set; }
        public string product_name { get; set; }
        public string licensed_to { get; set; }
        public string sme_email { get; set; }
        public string purchaser_name { get; set; }
        public decimal one_off_cost { get; set; }
        public long no_of_licenses { get; set; }
        public decimal cost_per_license { get; set; }
        public decimal total_amount { get; set; }
        public decimal discount_applied { get; set; }
        public string currency { get; set; }
        public decimal contract_term_months { get; set; }
        public decimal trial_period_months { get; set; }

        public virtual vendor_reconciliation vendor_reconciliation { get; set; }
    }
}
