using UTRADE.Library;
using UTRADE.Library.ISS;
using UTRADE.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace EIDService.Controllers
{
    [Route("api/[controller]")]
    public class CandleController : Controller
    {

        // GET api/candle
        [HttpGet]
        public IEnumerable<ICandle> Get(CandleRequestModel request)
        {

            IDictionary<Func<CandleRequestModel, bool>, Action> actions = new Dictionary<Func<CandleRequestModel, bool>, Action>();

            IEnumerable<ICandle> candles = null;


            actions.Add((pr) => { return !string.IsNullOrEmpty(pr.security) && pr.from.HasValue; }, () =>
            {
                MicexISSClient client = new MicexISSClient(new WebApiClient());

                DateTime? till = null;


                IDictionary<string, Func<CandleRequestModel, IList<UTRADE.Library.ICandle>>> interval_actions = new Dictionary<string, Func<CandleRequestModel, IList<UTRADE.Library.ICandle>>>();

                interval_actions.Add("1", (req) =>
                {
                    return client.GetCandles(request.security, request.from.Value, till, request.interval).Result;
                });

                interval_actions.Add("60", (req) =>
                {
                    return client.GetCandles(request.security, request.from.Value, till, request.interval).Result;
                });

                interval_actions.Add("D", (req) =>
                {
                    return client.GetHistory(request.security, request.from.Value, till).Result;
                });


                try
                {
                    candles = interval_actions[request.interval].Invoke(request);

                }
                catch(Exception ex)
                {
                    string msg = ex.Message;
                    //Logger.Log.Error("ошибка", ex);
                }

                
            });

            actions.Single(f => f.Key.Invoke(request)).Value.Invoke();

            return candles;
        }
    }
}