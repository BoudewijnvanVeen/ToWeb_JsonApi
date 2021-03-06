﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ToWeb.JsonApi.Model;

namespace ToWeb.JsonApi.Controllers
{
    public class StaticStringDictionaryController : ApiController
    {
        private static Dictionary<Guid, string> _store = new Dictionary<Guid, string>();

        public string Get(Guid id)
        {
            return _store.FirstOrDefault(c => c.Key.Equals(id)).Value;
        }

        [HttpGet]
        public string GetAll()
        {
            return $"[{string.Join(",", _store.Values)}]";
        }

        [HttpPost]
        public string Post(Json container)
        {
            if (!_store.ContainsKey(container.Key))
            {
                _store.Add(container.Key, container.JsonString);
            }
            else
            {
                _store[container.Key] = container.JsonString;
            }

            return container.JsonString;
        }

        [HttpDelete]
        public string Delete(Guid key)
        {
            _store.Remove(key);

            return key.ToString();
        }
    }
}
