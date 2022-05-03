using System;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public class indesser_api_call_status
    {
        public long call_id { get; set; }
        public DateTime call_datetime { get; set; }
        public long enterprise_id { get; set; }
        public string result { get; set; }
        public virtual enterprise enterprise { get; set; }
        public virtual eligibility_check_result eligibility_check_result { get; set; }
    }
}
