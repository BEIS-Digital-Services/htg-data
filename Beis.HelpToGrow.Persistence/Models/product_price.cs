using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class product_price
    {
        public product_price()
        {
            additional_costs = new HashSet<additional_cost>();
            product_price_base_metric_prices = new HashSet<product_price_base_metric_price>();
            product_price_secondary_metrics = new HashSet<product_price_secondary_metric>();
            user_discounts = new HashSet<user_discount>();
        }

        public long productid { get; set; }
        public bool payment_terms_discount_flag { get; set; }
        public bool user_discount_flag { get; set; }
        public int free_trial_term_no { get; set; }
        public int discount_term_no { get; set; }
        public int min_no_users { get; set; }
        public int commitment_no { get; set; }
        public long product_price_id { get; set; }
        public bool additional_costs_flag { get; set; }
        public bool additional_discount_flag { get; set; }
        public bool commitment_flag { get; set; }
        public string commitment_unit { get; set; }
        public long contract_duration_discount { get; set; }
        public string contract_duration_discount_description { get; set; }
        public bool contract_duration_discount_flag { get; set; }
        public decimal contract_duration_discount_percentage { get; set; }
        public string contract_duration_discount_unit { get; set; }
        public string discount_application_description { get; set; }
        public bool discount_flag { get; set; }
        public decimal discount_percentage { get; set; }
        public decimal discount_price { get; set; }
        public string discount_term_unit { get; set; }
        public long? free_trial_end_action_id { get; set; }
        public bool free_trial_flag { get; set; }
        public bool free_trial_payment_upfront { get; set; }
        public string free_trial_term_unit { get; set; }
        public string min_users_flag { get; set; }
        public decimal payment_terms_discount { get; set; }
        public string payment_terms_discount_description { get; set; }
        public decimal payment_terms_discount_percentage { get; set; }
        public string payment_terms_discount_unit { get; set; }
        public string product_price_sku { get; set; }
        public string product_price_title { get; set; }

        public virtual free_trial_end_action free_trial_end_action { get; set; }
        public virtual product product { get; set; }
        public virtual ICollection<additional_cost> additional_costs { get; set; }
        public virtual ICollection<product_price_base_metric_price> product_price_base_metric_prices { get; set; }
        public virtual ICollection<product_price_secondary_metric> product_price_secondary_metrics { get; set; }
        public virtual ICollection<user_discount> user_discounts { get; set; }
    }
}
