using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class fcasociety
    {
        public int societyId { get; set; }
        public int society_number { get; set; }
        public string society_suffix { get; set; }
        public string full_registration_number { get; set; }
        public string society_name { get; set; }
        public string registered_as { get; set; }
        public string society_address { get; set; }
        public string registration_date { get; set; }
        public string deregistration_date { get; set; }
        public string registration_act { get; set; }
        public string society_status { get; set; }
    }
}
