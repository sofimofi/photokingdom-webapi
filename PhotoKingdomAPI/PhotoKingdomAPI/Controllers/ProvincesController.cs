using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoKingdomAPI.Controllers
{
    public class ProvincesController : ApiController
    {
        private Manager m = new Manager();

        // GET: api/Provinces
        public IHttpActionResult Get()
        {
            return Ok(m.ProvinceGetAll());
        }

        // GET: api/Provinces/5
        public IHttpActionResult Get(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.ProvinceGetByIdWithCities(id.Value);

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