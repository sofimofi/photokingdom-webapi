using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoKingdomAPI.Controllers
{
    [RoutePrefix("api/Owns")]
    public class OwnsController : ApiController
    {
        private Manager m = new Manager();

        //************** Active Owns **************

        // Get all active resident owns for a city
        // GET: api/Owns/Active/City/5
        [Route("Active/City/{id:int}")]
        public IHttpActionResult GetCityActiveOwns(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.ResidentOwnGetAllActiveForCity(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // Get all active resident owns for a province
        // GET: api/Owns/Active/Province/5
        [Route("Active/Province/{id:int}")]
        public IHttpActionResult GetProvinceActiveOwns(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.ResidentOwnGetAllActiveForProvince(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // Get all active resident owns for a country
        // GET: api/Owns/Active/Country/5
        [Route("Active/Country/{id:int}")]
        public IHttpActionResult GetCountryActiveOwns(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.ResidentOwnGetAllActiveForCountry(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // Get all active resident owns for a continent
        // GET: api/Owns/Active/Continent/5
        [Route("Active/Continent/{id:int}")]
        public IHttpActionResult GetContinentActiveOwns(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.ResidentOwnGetAllActiveForContinent(id.Value);

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
