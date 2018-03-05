using System;
using System.Collections.Generic;
using UTRADE.Core.Entities;
using UTRADE.Library;

namespace UTRADE.Core.Robot
{
    public interface IStrategy
    {
        IList<string> Need();

        StrategyDecision GetDecision(IDictionary<string, IList<ICandle>> data, string name, string currentPos, Security security, DateTime CurrentDt);
    }
}