namespace Beis.Htg.VendorSme.Database.Models
{
    public class companies_house_registered_office_address
    {
            public long companies_house_registered_office_address_id { get; set; }
            public string address_line_1 { get; set; }
      
            public string address_line_2 { get; set; }
   
            public string care_of { get; set; }
       
            public string country { get; set; }
         
            public string locality { get; set; }

            public string po_box { get; set; }

            public string postal_code { get; set; }

            public string premises { get; set; }

            public string region { get; set; }

            public companies_house_api_result companies_house_api_result { get; set; }


    }
}
