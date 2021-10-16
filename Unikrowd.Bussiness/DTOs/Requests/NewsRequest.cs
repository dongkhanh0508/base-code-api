using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.DTOs.Requests
{
    public class NewsRequest
    {
        public string Title { get; set; }
        public int? CampaignId { get; set; }
        public string Content { get; set; }
    }
}
