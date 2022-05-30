using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class appeal_status
    {
        public int appeal_status_id { get; set; }
        public string appeal_status_desc { get; set; }
        public long? appeal_status1 { get; set; }

        public virtual appeal appeal_status1Navigation { get; set; }
    }
}
