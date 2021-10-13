using System;
using System.Net;

namespace Unikrowd.Bussiness.Excepstons
{
    public class CustomException : Exception
    {
        public HttpStatusCode Status { get; private set; }
        public string Error { get; set; }

        public CustomException(HttpStatusCode status, string msg, string error) : base(msg)
        {
            Status = status;
            Error = error;
        }
    }
}
