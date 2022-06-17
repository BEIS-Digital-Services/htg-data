#nullable disable

using System.Collections.Generic;

namespace Beis.HelpToGrow.Persistence.Models
{
	public partial class additional_cost_type
    {
        public int additional_cost_type_id { get; set; }
        public string description { get; set; }

        public virtual ICollection<additional_cost> additional_costs { get; set; }
    }
}
