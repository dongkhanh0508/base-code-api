using System;

namespace Unikrowd.Bussiness.DTOs.Requests
{
    public class PostInvestorRequest
    {      
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string IdCard { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Bank { get; set; }
        public string BanksAccount { get; set; }        
        public int? UserId { get; set; }                     
    }
    public class PutInvestorRequest
    {       
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string IdCard { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Bank { get; set; }
        public string BanksAccount { get; set; }       
        public int? UserId { get; set; }                   
    }
}
