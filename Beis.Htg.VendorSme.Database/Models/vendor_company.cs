using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class vendor_company
    {
        public vendor_company()
        {
            product1s = new HashSet<product1>();
            vendor_company_users = new HashSet<vendor_company_user>();
        }

        public long vendorid { get; set; }
        public string registration_id { get; set; }
        public string vendor_company_name { get; set; }
        public string vendor_company_house_reg_no { get; set; }
        public string vendor_company_address_1 { get; set; }
        public string vendor_company_address_2 { get; set; }
        public string vendor_company_city { get; set; }
        public string vendor_company_postcode { get; set; }
        public string vendor_notification_phone { get; set; }
        public string vendor_notification_email { get; set; }
        public string vendor_website_url { get; set; }
        public string vendor_company_profile { get; set; }
        public int application_status { get; set; }
        public long locked_by { get; set; }
        public string encryption_code { get; set; }
        public string access_secret { get; set; }
        public string access_secret_code { get; set; }
        public string ip_access_start { get; set; }
        public string ip_access_end { get; set; }
        public string edit_log { get; set; }
        public string ipaddresses { get; set; }
        public virtual vos_approval_tasks_vendor vos_approval_tasks_vendor { get; set; }
        public virtual ICollection<product1> product1s { get; set; }
        public virtual ICollection<vendor_company_user> vendor_company_users { get; set; }
    }
}
