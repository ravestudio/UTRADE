using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace UTRADE.Core.Entities
{
    public interface IEntity
    {
        void ReadData(JObject jsonObj);
    }

    public abstract class Entity<TId> : IEntity
    {
        public virtual TId Id
        {
            get
            {
                return _id;
            }
            set { _id = value; }
        }
        private TId _id;

        public virtual void ReadData(JObject jsonObj)
        {
        }

        /*public int ReadValue(JObject jsonObj, string field)
        {
            int value = 0;

            var fieldType = jsonObj[field].Type.ValueType;

            if (fieldType == Windows.Data.Json.JsonValueType.Number)
            {
                value = (int)jsonObj[field].GetNumber();
            }

            if (fieldType == Windows.Data.Json.JsonValueType.String)
            {
                value = int.Parse(jsonObj[field].GetString(), System.Globalization.CultureInfo.InvariantCulture);
            }

            return value;
        }*/

    }
}