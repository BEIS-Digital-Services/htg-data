using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class vendor_company_user
    {
        public long userid { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string position { get; set; }
        public string contact { get; set; }
        public long companyid { get; set; }
        public bool? status { get; set; }
        public bool primary_contact { get; set; }
        public int? permission_level { get; set; }
        public string access_link { get; set; }
        public string adb2c { get; set; }
        public int? user_id { get; set; }

        public virtual vendor_company company { get; set; }
    }
}
