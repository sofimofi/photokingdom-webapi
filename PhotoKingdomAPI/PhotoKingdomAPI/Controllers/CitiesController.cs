using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoKingdomAPI.Controllers
{
    public class CitiesController : ApiController
    {
        private Manager m = new Manager();

        // GET: api/Cities
        public IHttpActionResult Get()
        {
            return Ok(m.CityGetAll());
        }

        // GET: api/Cities/5
        public IHttpActionResult Get(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.CityGetById(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }
    }
}