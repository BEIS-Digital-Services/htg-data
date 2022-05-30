using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class token
    {
        public long token_id { get; set; }
        public string token_code { get; set; }
        public decimal token_balance { get; set; }
        public long enterprise_id { get; set; }
        public DateTime token_valid_from { get; set; }
        public DateTime token_expiry { get; set; }
        public long redemption_status_id { get; set; }
        public DateTime? redemption_date { get; set; }
        public long product { get; set; }
        public long reconciliation_status_id { get; set; }
        public string authorisation_code { get; set; }
        public bool reminder_1 { get; set; }
        public bool reminder_2 { get; set; }
        public bool reminder_3 { get; set; }
        public string obfuscated_token { get; set; }
        public int? cancellation_status_id { get; set; }

        public token_cancellation_status token_Cancellation_Status { get; set; }
    }
}
