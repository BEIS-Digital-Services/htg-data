using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class vos_approval_tasks_product
    {
        public string id { get; set; }
        public long product_id { get; set; }
        public bool? application_form_content { get; set; }
        public string spotlight_other_data { get; set; }
        public string case_worker_check_outcome { get; set; }
        public string case_worker_check_outcome_rationale { get; set; }
        public string qc_check_outcome { get; set; }
        public string qc_check_outcome_rationale { get; set; }
        public string rework_check_outcome { get; set; }
        public string rework_check_outcome_rationale { get; set; }
        public string rework_qc_check { get; set; }
        public string rework_qc_check_rationaile { get; set; }

        public virtual product1 product { get; set; }
    }
}
