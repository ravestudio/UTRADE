using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UTRADE.Core.Repository;
using UTRADE.Library;

namespace UTRADE.Service.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData(string security)
        {
            WebApiClient client = new WebApiClient();
            CandleRepository repo = new CandleRepository(client);
            var task = repo.GetHistory(security, new DateTime(2018, 1, 30), "1");

            var candles = task.Result;

            long DatetimeMinTimeTicks = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;

            var arr = new List<object>();

            foreach(ICandle candle in candles)
            {
                var ticks = candle.begin.ToUniversalTime().Ticks - DatetimeMinTimeTicks;

                long dt = ticks / 10000;

                

                arr.Add(new object[] {dt, candle.open, candle.high, candle.low, candle.close});    
            }

            return Json(arr);
        }

    }

}