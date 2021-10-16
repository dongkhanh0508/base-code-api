using System;

namespace Unikrowd.Bussiness.DTOs.Requests
{
    public class PostDocumentRequest
    {
        public string Title { get; set; }
        public int? CampaignId { get; set; }
        public string Url { get; set; }           
    }
    public class PutDocumentRequest
    {      
        public string Title { get; set; }
        public int? CampaignId { get; set; }
        public string Url { get; set; }     
       
    }
}
