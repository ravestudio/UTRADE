using System;
using System.Collections.Generic;
using EIDClient.Core.ISS;
using UTRADE.Core.Entities;
using UTRADE.Core.ISS;
using UTRADE.Library;

namespace UTRADE.Core.Robot
{
    public class AnalystStrategy : IStrategy
    {
        public StrategyDecision GetDecision(IDictionary<string, IList<ICandle>> data, string name, string currentPos, DateTime CurrentDt)
        {
            StrategyDecision dec = new StrategyDecision() { Decision = "none" };
            dec.Code = name;

            SimpleMovingAverage short_ma = new SimpleMovingAverage(data["60"], 9);
            SimpleMovingAverage long_ma = new SimpleMovingAverage(data["60"], 20);

            TRENDResult trend = new TREND(long_ma, 3).GetResult();

            if (trend == TRENDResult.Up && new Crossover(short_ma, long_ma).GetResult())
            {
                dec.Decision = "open long";
            }

            if (trend == TRENDResult.Down && new Crossover(long_ma, short_ma).GetResult())
            {
                dec.Decision = "open short";
            }

            return dec;
        }

        public IList<string> Need()
        {
            IList<string> res = new List<string>();

            res.Add("60");

            return res;
        }
    }
}