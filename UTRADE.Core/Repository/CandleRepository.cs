using UTRADE.Library;
using UTRADE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UTRADE.Core.Repository
{
    public class CandleRepository : Repository<Candle, int>
    {
        public CandleRepository(WebApiClient apiClient)
            : base(apiClient)
        {
            this.apiPath = "api/candle/";
        }

        public Task<IEnumerable<ICandle>> GetHistory(string sec, DateTime from, string interval)
        {
            TaskCompletionSource<IEnumerable<ICandle>> TCS = new TaskCompletionSource<IEnumerable<ICandle>>();

            string url = string.Format("{0}{1}?security={2}&from={3}&interval={4}", this.ServerURL, "api/candle/", sec, from.ToString(System.Globalization.CultureInfo.InvariantCulture), interval);

            this._apiClient.GetData(url).ContinueWith(t =>
            {
                //IList<ICandle> List = new List<ICandle>();

                string data = t.Result;

                List<Candle> List = JsonConvert.DeserializeObject<List<Candle>>(data);

                TCS.SetResult(List);
            });

            return TCS.Task;
        }
    }
}