using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class free_trial_end_action
    {
        public free_trial_end_action()
        {
            product_prices = new HashSet<product_price>();
        }

        public long free_trial_end_action_id { get; set; }
        public string free_trial_end_action_desc { get; set; }

        public virtual ICollection<product_price> product_prices { get; set; }
    }
}
