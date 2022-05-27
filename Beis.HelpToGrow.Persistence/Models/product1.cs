using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class product1
    {
        public product1()
        {
            product_compare_entries = new HashSet<product_compare_entry>();
            product_eligibility_declares = new HashSet<product_eligibility_declare>();
            vos_approval_tasks_products = new HashSet<vos_approval_tasks_product>();
        }

        public long product_id { get; set; }
        public long vendor_id { get; set; }
        public string product_sku { get; set; }
        public long? product_type { get; set; }
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
        public long status { get; set; }
        public string product_logo { get; set; }
        public string redemption_url { get; set; }

        public virtual productstatus statusNavigation { get; set; }
        public virtual vendor_company vendor { get; set; }
        public virtual ICollection<product_compare_entry> product_compare_entries { get; set; }
        public virtual ICollection<product_eligibility_declare> product_eligibility_declares { get; set; }
        public virtual ICollection<vos_approval_tasks_product> vos_approval_tasks_products { get; set; }
    }
}
