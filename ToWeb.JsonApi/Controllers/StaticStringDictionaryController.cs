
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ToWeb.JsonApi.Controllers
{
    public class StaticStringDictionaryController : ApiController
    {
        public string Get(Guid id)
        {
            return _store.FirstOrDefault(c => c.Key.Equals(id)).Value;
        }

        public Dictionary<Guid, string> GetAll()
        {
            return _store;
        }

        public void Post(Guid id, string json)
        {
            _store.Add(id, json);
        }

        public void Put(Guid id, string json)
        {
            _store.Add(id, json);
        }
        
        public void Delete(Guid id)
        {
            _store.Remove(id);
        }

        private static Dictionary<Guid, string> _store = new Dictionary<Guid, string>();
    }
}
