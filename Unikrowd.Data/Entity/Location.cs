using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Location
    {
        public Location()
        {
            CampaignLocations = new HashSet<CampaignLocation>();
            InvestorLocations = new HashSet<InvestorLocation>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Address { get; set; }
        public int? Status { get; set; }
        public int? BusinessId { get; set; }
        public int? CampaignId { get; set; }
        public int? InvestorId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Investor Investor { get; set; }
        public virtual ICollection<CampaignLocation> CampaignLocations { get; set; }
        public virtual ICollection<InvestorLocation> InvestorLocations { get; set; }
    }
}
