using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.MapperViewModels
{
    public class CampaignViewModel
    {
        public int Id { get; set; }
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
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Description { get; set; }
        public string RejectReason { get; set; }
    }
}
