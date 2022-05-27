using System;
#nullable disable


namespace Beis.HelpToGrow.Persistence.Models
{
    public class enterprise
    {
        public long enterprise_id { get; set; }
        public string enterprise_name { get; set; }
        public long eligibility_status_id { get; set; }
        public bool new_tech_ind { get; set; }
        public string companies_house_no { get; set; }
        public string copmanies_house_returns { get; set; }
        public string fca_no { get; set; }
        public string company_postcode { get; set; }
        public string company_age { get; set; }
        public string company_trading_status { get; set; }
        public string company_gazette_data { get; set; }
        public string company_financial_providers_no { get; set; }
        public string company_disqualified_directors { get; set; }
        public string company_account_filing_ind { get; set; }
        public string company_abnormal_filing_ind { get; set; }
        public string company_holding_ind { get; set; }
        public string company_address_changes_ind { get; set; }
        public string company_multi_match_ind { get; set; }
        public string appeal_status_desc { get; set; }
        public long enterprise_size_id { get; set; }
        public string applicant_email_address { get; set; }
        public bool applicant_email_verified { get; set; }
        public string applicant_name { get; set; }
        public string applicant_role { get; set; }
        public bool agreed_tandc { get; set; }
        public string risk_profile_score { get; set; }
        public string scorecheck_score { get; set; }
        public long? indesser_api_call_status_id { get; set; }
        public DateTime? enterprise_created_date { get; set; }
        public bool? marketing_consent { get; set; }

        public virtual indesser_api_call_status indesser_api_call_status { get; set; }
        public virtual appeal appeal { get; set; }
    }
}
