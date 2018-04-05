using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoKingdomAPI.Controllers
{
    public class CheckOwnsController : ApiController
    {
        private Manager m = new Manager();

        public IHttpActionResult Get()
        {
            var o = m.checkOwns();

            return Ok(o);
        }
    }
}
