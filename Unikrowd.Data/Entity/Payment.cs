using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Payment
    {
        public Payment()
        {
            Transactions = new HashSet<Transaction>();
        }

        public double? Amount { get; set; }
        public string Description { get; set; }
        public int? PaymentFromId { get; set; }
        public int? PaymentToId { get; set; }
        public string PaymentType { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string PaymentDocument { get; set; }
        public int Id { get; set; }
        public int? InvestmentId { get; set; }
        public int? CampaignId { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Investor CreatedByNavigation { get; set; }
        public virtual Investment Investment { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
