using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class CampaignPackage
    {
        public CampaignPackage()
        {
            Investments = new HashSet<Investment>();
        }

        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int? MaxQuantity { get; set; }
        public string Name { get; set; }
        public string Reward { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdateBy { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
