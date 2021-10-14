using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.DTOs.Requests
{
    public class PostAccountRequest
    {      
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }                              
    }
    public class PutAccountRequest
    {      
        public string Username { get; set; }
        public string Password { get; set; }                   
    }
}
