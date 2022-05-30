using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class product_filter
    {
        public long Id { get; set; }
        public long product_id { get; set; }
        public long filter_id { get; set; }
        public bool draft_filter { get; set; }
    }
}
