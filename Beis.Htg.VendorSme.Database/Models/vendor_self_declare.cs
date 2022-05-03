using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class vendor_self_declare
    {
        public long vendorid { get; set; }
        public long application_made_userid { get; set; }
        public long primary_contact { get; set; }
        public bool? authority_yes_no { get; set; }
        public bool? software_vendor_yes_no { get; set; }
        public bool? online_purchase { get; set; }
        public long secondary_contact { get; set; }

        public virtual vendor_company vendor { get; set; }
    }
}
