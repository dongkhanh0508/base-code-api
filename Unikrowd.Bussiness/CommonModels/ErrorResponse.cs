using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.CommonModels
{
    public class ErrorResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrade { get; set; }

        public ErrorResponse(Exception ex, string error)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            StackTrade = error;
        }
    }
}
