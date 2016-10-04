
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Ajax.Utilities;

namespace ToWeb.JsonApi.Controllers
{
    public class StaticStringDictionaryController : ApiController
    {
        public string Get(Guid id)
        {
            return _store.FirstOrDefault(c => c.Key.Equals(id)).Value;
        }

        [HttpGet]
        public Dictionary<Guid, string> GetAll()
        {
            return _store;
        }

        [HttpPost]
        public string Post(Guid key, string record)
        {
            if (!_store.ContainsKey(key))
            {
                _store.Add(key, record);
            }
            else
            {
                _store[key] = record;
            }

            return record;
        }
        
        [HttpDelete]
        public void Delete(Guid key)
        {
            _store.Remove(key);
        }

        private static Dictionary<Guid, string> _store = new Dictionary<Guid, string>();
    }
}
