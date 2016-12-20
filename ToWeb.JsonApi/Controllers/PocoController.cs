
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using ToWeb.JsonApi.Model;

namespace ToWeb.JsonApi.Controllers
{
    public class StaticPocoDictionaryController : ApiController
    {
        public static readonly Dictionary<Guid, Poco> Store = new Dictionary<Guid, Poco>();

        [HttpGet]
        [Route("api/GetById")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Poco))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(Guid key)
        {
            if (!Store.ContainsKey(key))
                return Ok(Store.FirstOrDefault(c => c.Key.Equals(key)).Value);

            return NotFound();
        }

        [HttpGet]
        [Route("api/GetAll")]
        public Dictionary<Guid, Poco> GetAll()
        {
            return Store;
        }

        [HttpPost]
        [Route("api/Post")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(PocoContainer))]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(PocoContainer))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult Post(Guid key, Poco poco)
        {
            var errors = poco.Validate();

            if (errors.Any()) return Ok(new PocoContainer {Body = poco, Key = key, Errors = errors});

            if (!Store.ContainsKey(key))
                Store.Add(key, poco);

            Store[key] = poco;

            return Ok(new PocoContainer { Body = poco, Key = key, Errors = null });
        }
        
        [HttpDelete]
        [Route("api/Delete")]
        public void Delete(Guid key)
        {
            Store.Remove(key);
        }
    }
}
