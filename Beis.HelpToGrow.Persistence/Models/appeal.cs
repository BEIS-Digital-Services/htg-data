using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class appeal
    {
        public appeal()
        {
            appeal_statuses = new HashSet<appeal_status>();
            enterprises = new HashSet<enterprise>();
        }

        public long appeal_id { get; set; }

        public virtual ICollection<appeal_status> appeal_statuses { get; set; }
        public virtual ICollection<enterprise> enterprises { get; set; }
    }
}
