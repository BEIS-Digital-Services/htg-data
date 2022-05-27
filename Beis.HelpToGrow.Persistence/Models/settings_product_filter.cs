using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class settings_product_filter
    {
        public long filter_id { get; set; }
        public long filter_type { get; set; }
        public string filter_name { get; set; }
        public int sort_order { get; set; }
    }
}
