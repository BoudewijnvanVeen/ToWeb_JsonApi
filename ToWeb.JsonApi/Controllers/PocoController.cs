
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using ToWeb.JsonApi.Model;

namespace ToWeb.JsonApi.Controllers
{
    [RoutePrefix("api/Poco")]
    public class StaticPocoDictionaryController : ApiController
    {
        public static readonly Dictionary<Guid, Poco> Store = new Dictionary<Guid, Poco>();
        
        [HttpGet]
        [Route("GetBy/{key}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Poco))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public IHttpActionResult Get(Guid key)
        {
            if (key == Guid.Empty)
                return BadRequest("key is empty");

            if (Store.ContainsKey(key))
                return Ok(Store.FirstOrDefault(c => c.Key.Equals(key)).Value);

            return NotFound();
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Poco>))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public List<Poco> Get()
        {
            return Store.Values.ToList();
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(Poco))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public IHttpActionResult Post(Poco poco)
        {
            var modelState = poco.Validate(ECrudAction.Insert);

            if (!modelState.IsValid) return BadRequest(modelState);

            poco.Key = Guid.NewGuid();

            Store.Add(poco.Key, poco);

            return Ok(poco);
        }

        [HttpPut]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Poco))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public IHttpActionResult Put([FromBody] Poco poco)
        {
            var modelState = poco.Validate(ECrudAction.Update);

            if (!modelState.IsValid) return BadRequest(modelState);

            if (!Store.ContainsKey(poco.Key))
                return NotFound();

            Store[poco.Key] = poco;

            return Ok(poco);
        }

        [HttpDelete]
        [Route("")]
        public void Delete(Guid key)
        {
            Store.Remove(key);
        }
    }
}
