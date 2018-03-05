namespace UTRADE.Core.Robot
{
    public class StrategyDecision
    {
        public string Code { get; set; }
        public string Decision { get; set; }

        public decimal LongPrice { get; set; }
        public decimal ShortPrice { get; set; }

        public decimal LastPrice { get; set; }

        public int Count { get; set; }

        public decimal Profit { get; set; }
        public decimal StopLoss { get; set; }
    }
}