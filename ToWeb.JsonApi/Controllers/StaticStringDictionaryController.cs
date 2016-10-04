
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
        public string Post(Container container)
        {
            if (!_store.ContainsKey(container.Key))
            {
                _store.Add(container.Key, container.Record);
            }
            else
            {
                _store[container.Key] = container.Record;
            }

            return container.Record;
        }
        
        [HttpDelete]
        public void Delete(Guid key)
        {
            _store.Remove(key);
        }

        private static Dictionary<Guid, string> _store = new Dictionary<Guid, string>();
    }

    public class Container
    {
        public Guid Key { get; set; }
        public string Record { get; set; }
    }
}
