using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class QnA
    {
        public string Question { get; set; }
        public int CampaignId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Answer { get; set; }
        public int? AnsweredBy { get; set; }
        public DateTime? AnsweredAt { get; set; }
        public int? Status { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Investor CreatedByNavigation { get; set; }
    }
}
