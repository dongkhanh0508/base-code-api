using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.DTOs.Requests
{
    public class PaymentRequest
    {       
        public double? Amount { get; set; }
        public string Description { get; set; }
        public int? PaymentFromId { get; set; }
        public int? PaymentToId { get; set; }
        public string PaymentType { get; set; }      
        public string PaymentDocument { get; set; }
    }
}
