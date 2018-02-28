using System;

namespace UTRADE.Service.Models
{
    public class CandleRequestModel
    {
        public string security { get; set; }
        public DateTime? from { get; set; }
        public DateTime? till { get; set; }
        public string interval { get; set; }
    }
}