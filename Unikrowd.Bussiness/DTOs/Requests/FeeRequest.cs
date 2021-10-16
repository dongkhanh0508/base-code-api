using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.DTOs.Requests
{
    public class FeeRequest
    {     
        public double? Amount { get; set; }        
        public int? Type { get; set; }
    }
}
