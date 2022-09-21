using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beis.HelpToGrow.Persistence.Models
{ 
    /*
     * -- public.user_journey_type definition

-- Drop table

-- DROP TABLE public.enterprise_user_journey_type;

CREATE TABLE public.user_journey_type (
	user_journey_type_id int4 NOT NULL,
	user_journey_type_desc varchar(150) NOT NULL,
	CONSTRAINT user_journey_type_pkey PRIMARY KEY (user_journey_type_id)
);
     */

    /// <summary>
    /// Lookup table to identify the type of token an SME is applying for
    /// </summary>
    public class user_journey_type
    {
        /// <summary>
        /// Primary key field
        /// </summary>
        public int user_journey_type_id { get; set; }
        /// <summary>
        /// Description of journey type
        /// </summary>
        public string user_journey_type_desc { get; set; }
    }
}
