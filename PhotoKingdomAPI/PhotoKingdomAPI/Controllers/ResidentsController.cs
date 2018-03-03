using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoKingdomAPI.Controllers
{
    [RoutePrefix("api/Residents")]
    public class ResidentsController : ApiController
    {
        private Manager m = new Manager();

        // GET: api/Residents
        public IHttpActionResult Get()
        {
            return Ok(m.ResidentGetAll());
        }

        // GET: api/Residents/5
        [Route("{id:int}")]
        public IHttpActionResult Get(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.ResidentWithDetailsGetById(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // Get all photos for a resident
        // GET: api/Residents/5/photos
        [Route("{id:int}/photos")]
        public IHttpActionResult GetResidentPhotos(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.PhotoGetAllForResident(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // Get all pings for a resident
        // GET: api/Residents/5/pings
        [Route("{id:int}/pings")]
        public IHttpActionResult GetResidentPings(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.PingGetAllForResident(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }


        // POST: api/Residents
        public IHttpActionResult Post([FromBody]ResidentAdd newItem)
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
                var addedItem = m.ResidentAdd(newItem);

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
                    return Created<ResidentBase>(uri, addedItem);
                }
            }
            else
            {
                // HTTP 400
                return BadRequest(ModelState);
            }
        }
        /*
        // PUT: api/Residents/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Residents/5
        public void Delete(int id)
        {
        }
        */
    }
}