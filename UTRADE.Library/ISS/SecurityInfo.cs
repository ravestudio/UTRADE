using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTRADE.Library.ISS
{
    public class SecurityInfo
    {
        public string BoardId { get; set; }
        public string Code { get; set; } 

        public decimal PREVLEGALCLOSEPRICE { get; set; }
    }
}