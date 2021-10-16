using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.DTOs.Requests
{
    public class PostCampaignPackageRequest
    {
        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int? MaxQuantity { get; set; }
        public string Name { get; set; }
        public string Reward { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public class PutCampaignPackageRequest
    {
        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int? MaxQuantity { get; set; }
        public string Name { get; set; }
        public string Reward { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }      
    }
}
