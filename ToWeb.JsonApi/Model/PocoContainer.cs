using System;
using System.Collections.Generic;

namespace ToWeb.JsonApi.Model
{
    public class PocoContainer
    {
        public Guid Key { get; set; }
        public Poco Body { get; set; }
        public List<Error> Errors { get; set; }
    }
}