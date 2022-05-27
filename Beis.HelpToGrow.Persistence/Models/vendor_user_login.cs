using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class vendor_user_login
    {
        public long userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public virtual vendor_company_user user { get; set; }
    }
}
