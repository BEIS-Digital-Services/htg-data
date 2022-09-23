using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beis.HelpToGrow.Persistence.Models
{ 


    /// <summary>
    /// Lookup table to identify the type of token an SME is applying for
    /// </summary>
    public class token_type
    {
        /// <summary>
        /// Primary key field
        /// </summary>
        public int token_type_id { get; set; }
        /// <summary>
        /// Description of journey type
        /// </summary>
        public string token_type_desc { get; set; }
    }
}
