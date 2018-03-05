
using System;

namespace UTRADE.Core.Entities
{
    public class Security : Entity<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Int64 IssueSize { get; set; }

        public decimal MinStep { get; set; }
        public int LotSize { get; set; }
        public bool AlgoTrade { get; set; }

        public int DealSize { get; set; }
    }
}