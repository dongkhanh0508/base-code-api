using System;

namespace Unikrowd.Bussiness.DTOs.Requests
{
    public class PostCampaignRequest
    {
        public string Name { get; set; }
        public int? MaxTarget { get; set; }
        public int? MinTarget { get; set; }
        public DateTime? KickoffDate { get; set; }
        public int? Maturity { get; set; }
        public DateTime? EndDate { get; set; }
        public double? InvestmentMultiple { get; set; }
        public int? BusinessId { get; set; }
        public int? RiskId { get; set; }
        public string Description { get; set; }
    }
    public class PutCampaignRequest
    {
        public string Name { get; set; }
        public int? MaxTarget { get; set; }
        public int? MinTarget { get; set; }
        public DateTime? KickoffDate { get; set; }
        public int? Maturity { get; set; }
        public DateTime? EndDate { get; set; }
        public double? InvestmentMultiple { get; set; }
        public int? Status { get; set; }
        public int? BusinessId { get; set; }
        public int? RiskId { get; set; }
        public string Description { get; set; }
    }
}
