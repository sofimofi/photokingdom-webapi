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
            var o = m.ProvinceGetById(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // POST: api/Provinces
        public IHttpActionResult Post([FromBody]ProvinceAdd newItem)
        {
            // Ensure that the URI is clean (and does not have an id parameter)
            if (Request.GetRouteData().Values["id"] != null)
            {
                return BadRequest("Invalid request URI");
            }

            // Ensure that a "newItem" is in the entity body
            if (newItem == null)
            {
                return BadRequest("Must send an entity body with the request");
            }

            // Ensure that we can use the incoming data
            if (ModelState.IsValid)
            {
                // Attempt to add the new object
                var addedItem = m.ProvinceAdd(newItem);

                // Notice the ApiController convenience methods
                if (addedItem == null)
                {
                    // HTTP 400
                    return BadRequest("Cannot add the object");
                }
                else
                {
                    // HTTP 201 with the new object in the entity body
                    // Notice how to create the URI for the Location header

                    var uri = Url.Link("DefaultApi", new { id = addedItem.Id });
                    return Created<ProvinceBase>(uri, addedItem);
                }
            }
            else
            {
                // HTTP 400
                return BadRequest(ModelState);
            }
        }
        /*
        // PUT: api/Provinces/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Provinces/5
        public void Delete(int id)
        {
        }
        */
    }
}