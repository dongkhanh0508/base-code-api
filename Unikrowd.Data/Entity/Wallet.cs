using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Wallet
    {
        public int Id { get; set; }
        public int? InvestorId { get; set; }
        public int? BusinessId { get; set; }
        public int? CampaignId { get; set; }
        public double? Balance { get; set; }
        public string Type { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Status { get; set; }

        public virtual Business Business { get; set; }
        public virtual Investor Investor { get; set; }
    }
}
