using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class product_category
    {
        public long product_id { get; set; }
        public long category_id { get; set; }

        public virtual settings_category_type category { get; set; }
    }
}
