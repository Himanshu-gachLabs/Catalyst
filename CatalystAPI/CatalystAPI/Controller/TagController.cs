﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalystAPI.Controller
{
    public class TagController : ApiController
    {
        // GET: api/Tag
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tag/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tag
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tag/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tag/5
        public void Delete(int id)
        {
        }
    }
}