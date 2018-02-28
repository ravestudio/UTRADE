using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTRADE.Library
{
    public interface ICandle
    {
        string Code { get; set; }
        DateTime begin { get; set; }
        decimal open { get; set; }
        decimal close { get; set; }
        decimal high { get; set; }
        decimal low { get; set; }
        decimal value { get; set; }
        decimal volume { get; set; }
    }
}