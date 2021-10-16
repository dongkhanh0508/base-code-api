using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.MapperViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public double? Amount { get; set; }
        public string Description { get; set; }
        public int? PaymentFromId { get; set; }
        public int? PaymentToId { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string PaymentDocument { get; set; }
    }
}
