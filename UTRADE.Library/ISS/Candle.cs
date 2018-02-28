using UTRADE.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTRADE.Library.ISS
{
    public class Candle : ICandle
    {
        public Candle()
        {

        }

        public string Code { get; set; }
        public DateTime begin { get; set; }
        public decimal open { get; set; }
        public decimal close { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal value { get; set; }
        public decimal volume { get; set; }
    }
}