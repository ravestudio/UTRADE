using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UTRADE.Core.Repository;
using UTRADE.Core.Robot;
using UTRADE.Library;

namespace UTRADE.Service.Controllers
{
    public class AnalystController: Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public JsonResult GetDecisions()
        {
            IList<StrategyDecision> decisions = new List<StrategyDecision>();

            IList<string> securityList = new List<string>();
            securityList.Add("GMKN");
            securityList.Add("LKOH");
            securityList.Add("MOEX");

            IDictionary<string, IDictionary<string, IList<ICandle>>> dic = new Dictionary<string, IDictionary<string, IList<ICandle>>>();

            WebApiClient client = new WebApiClient();
            CandleRepository repo = new CandleRepository(client);

            AnalystStrategy strategy = new AnalystStrategy();

            foreach(string sec in securityList)
            {
                var task = repo.GetHistory(sec, DateTime.Now.AddDays(-14), "60");

                var candles = task.Result;

                dic.Add(sec, new Dictionary<string, IList<ICandle>>());
                dic[sec].Add("60", candles.ToList());
            }

            foreach(string sec in securityList)
            {
                decisions.Add(strategy.GetDecision(dic[sec], sec, "free", DateTime.Now));
            }

            JsonResult res = Json(decisions);
        
            return res;
        }
        
    }
}