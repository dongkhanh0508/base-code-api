using System;

namespace Unikrowd.Bussiness.DTOs.Requests
{
    public class PostBusinessRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BusinessLicense { get; set; }
        public string Bank { get; set; }
        public string BanksAccount { get; set; }
        public string BankAccountHolder { get; set; }     
        public int? UserId { get; set; }       
        public DateTime? CreatedAt { get; set; }        
        public string Image { get; set; }
    }
    public class PutBusinessRequest
    {       
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BusinessLicense { get; set; }
        public string Bank { get; set; }
        public string BanksAccount { get; set; }
        public string BankAccountHolder { get; set; }      
        public int? UserId { get; set; }             
        public DateTime? UpdatedAt { get; set; }
        public string Image { get; set; }
    }
}
