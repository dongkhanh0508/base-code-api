using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int? FromWalletId { get; set; }
        public int? ToWalletId { get; set; }
        public double? Amount { get; set; }
        public string TransactionType { get; set; }
        public int? PaymentId { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
