using System;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public class eligibility_check_result
    {
        public long eligibility_check_result_id { get; set; }
        public long call_id { get; set; }
        public bool passed_check { get; set; }
        public string spot_check_object { get; set; }
        public string result_object { get; set; }
        public DateTime result_datetime { get; set; }
        public virtual indesser_api_call_status indesser_api_call_status { get; set; }
    }
}
