using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public class companies_house_api_result
    {

        // https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/resources/companyprofile?v=latest

        [Column("companies_house_api_result_id")]
        public long companies_house_api_result_id { get; set; }
        [Column("company_number")]
        public string company_number { get; set; }
        [Column("date_of_creation")]
        public DateTime date_of_creation { get; set; }
        [Column("type")]
        public string type { get; set; }
        [Column("UndeliverableRegisteredOfficeAddress")]
        public bool undeliverable_registered_office_address { get; set; }
        [Column("company_name")]
        public string company_name { get; set; }
        [Column("sic_codes")]
        public string sic_codes { get; set; }
        [Column("registered_office_is_in_dispute")]
        public bool registered_office_is_in_dispute { get; set; }
        [Column("company_status")]
        public string company_status { get; set; }
        [Column("has_insolvency_history")]
        public bool has_insolvency_history { get; set; }
        [Column("registered_office_address")]
        public companies_house_registered_office_address registered_office_address { get; set; }
        [Column("jurisdiction")]
        public string jurisdiction { get; set; }
        [Column("locality")]
        public string locality { get; set; }
        [Column("activity")]
        public string activity { get; set; } // business activity
    }
}
