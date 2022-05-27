using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class vendor_api_call_status
    {
        public long call_id { get; set; }
        public long[] vendor_id { get; set; }
        public DateTime call_datetime { get; set; }
        public string api_called { get; set; }
        public string result { get; set; }
        public string request { get; set; }
        public string error_code { get; set; }
    }
}
