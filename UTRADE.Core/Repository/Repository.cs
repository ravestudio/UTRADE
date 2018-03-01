using UTRADE.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UTRADE.Core.Repository
{
    public class Repository<G, Key>
            where G : Entities.Entity<Key>, new()
    {

        protected WebApiClient _apiClient = null;

        //protected string ServerURL = "http://eidservice.somee.com/";
        protected string ServerURL = "http://localhost:5000/";
        //protected string ServerURL = "http://localhost:61943/";
        //protected string ServerURL = "http://ravestudio-001-site1.htempurl.com/";

        protected string apiPath { get; set; }

        public Repository(WebApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        public virtual Task<G> GetById(Key id)
        {
            TaskCompletionSource<G> TCS = new TaskCompletionSource<G>();

            string url = string.Format("{0}{1}{2}", this.ServerURL, this.apiPath, id);

            this._apiClient.GetData(url).ContinueWith(t =>
            {
                string data = t.Result;

                G entity = JsonConvert.DeserializeObject<G>(data);

                //G entity = this.GetObject(value);
                TCS.SetResult(entity);
            });

            return TCS.Task;
        }

        public virtual Task<G> GetSingle()
        {
            TaskCompletionSource<G> TCS = new TaskCompletionSource<G>();

            string url = string.Format("{0}{1}", this.ServerURL, this.apiPath);

            this._apiClient.GetData(url).ContinueWith(t =>
            {
                string data = t.Result;

                G entity = JsonConvert.DeserializeObject<G>(data);

                TCS.SetResult(entity);
            });

            return TCS.Task;
        }

        public virtual Task<IEnumerable<G>> GetAll()
        {
            TaskCompletionSource<IEnumerable<G>> TCS = new TaskCompletionSource<IEnumerable<G>>();

            IList<G> entityList = new List<G>();

            string url = string.Format("{0}{1}", this.ServerURL, this.apiPath);

            this._apiClient.GetData(url).ContinueWith(t =>
            {
                string data = t.Result;

                /*var emitentArray = Windows.Data.Json.JsonValue.Parse(data).GetArray();

                for (int i = 0; i < emitentArray.Count; i++)
                {
                    var value = emitentArray[i];
                    G entity = this.GetObject(value);
                    entityList.Add(entity);
                }*/


                TCS.SetResult(entityList);
            });

            return TCS.Task;
        }

        public virtual Task<string> Create(G model)
        {
            return null;

        }

        public virtual Task<string> Update(G model)
        {
            return null;
        }

        public G GetObject(JObject jsonObj)
        {
            G obj = null;

            //var jsonObj = jsonValue.GetObject();

            obj = new G();
            obj.ReadData(jsonObj);

            return obj;
        }

        public int GetErrorInfo(JObject jsonValue)
        {
            int error = 0;

            //var jsonObj = jsonValue.GetObject();

            //error = (int)jsonObj["error"].GetNumber();

            return error;
        }
    }
}