using System;

namespace Unikrowd.Bussiness.DTOs.Requests
{
    public class LocationRequest
    {       
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Address { get; set; }       
        public int? BusinessId { get; set; }
        public int? CampaignId { get; set; }
        public int? InvestorId { get; set; }        
    }
}
