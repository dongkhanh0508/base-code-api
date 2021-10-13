using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int? BusinessId { get; set; }
        public int? CampaignId { get; set; }
        public int? InvestorId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Investor Investor { get; set; }
    }
}
