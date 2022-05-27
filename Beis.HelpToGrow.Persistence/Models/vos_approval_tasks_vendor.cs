using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class vos_approval_tasks_vendor
    {
        public long vendor_id { get; set; }
        public long admin_id { get; set; }
        public bool? check_secondary_contact { get; set; }
        public string check_secondary_outcome_notes { get; set; }
        public bool approve_recject { get; set; }
        public string approve_reject_notes { get; set; }
        public string application_form { get; set; }

        public virtual vendor_company vendor { get; set; }
    }
}
