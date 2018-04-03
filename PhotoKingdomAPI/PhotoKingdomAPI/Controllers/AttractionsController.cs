using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoKingdomAPI.Controllers
{
    [RoutePrefix("api/Attractions")]
    public class AttractionsController : ApiController
    {
        private Manager m = new Manager();

        // GET: api/Attractions
        public IHttpActionResult Get()
        {
            return Ok(m.AttractionGetAll());
        }

        // GET: api/Attractions/mapview
        [HttpGet]
        [Route("mapview")]
        public IHttpActionResult GetAllForMapViewRegion([FromUri]LatLngBoundaries latLngBoundaries)
        {
            var o = m.AttractionGetAllForMapViewRegion(latLngBoundaries);
            return Ok(o);
        }

        // GET: api/Attractions/5
        [Route("{id:int}")]
        public IHttpActionResult GetAttraction(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.AttractionGetById(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // GET: api/Attractions/googlePlaceId/5
        [Route("googlePlaceId/{id}")]
        public IHttpActionResult GetAttractionByGooglePlaceId(string id)
        {

            // Fetch the object, so that we can inspect its value
            var o = m.AttractionGetByGooglePlaceId(id);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // GET: api/Attractions/5/details
        [Route("{id:int}/details")]
        public IHttpActionResult GetAttractionWithDetails(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.AttractionGetByIdWithDetails(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // GET: api/Attractions/googlePlaceId/5/details
        [Route("googlePlaceId/{id}/details")]
        public IHttpActionResult GetAttractionWithDetailsByGooglePlaceId(string id)
        {
            // Fetch the object, so that we can inspect its value
            var o = m.AttractionGetByGooglePlaceIdWithDetails(id);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // Get all queues for the attraction
        // GET: api/Attractions/5/queues
        [Route("{id:int}/queues")]
        public IHttpActionResult GetAttractionQueues(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.QueueGetAllForAttraction(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // Get all queues with details for the attraction
        // GET: api/Attractions/5/queues/details
        [Route("{id:int}/queues/details")]
        public IHttpActionResult GetAttractionQueuesWithDetails(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.QueueGetAllWithDetailsForAttraction(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // Get all attractionphotowars for the attraction
        // GET: api/Attractions/5/Photowars
        [Route("{id:int}/Photowars")]
        public IHttpActionResult GetAttractionPhotowars(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.AttractionPhotowarGetAllForAttraction(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // POST: api/Attractions
        public IHttpActionResult Post([FromBody]AttractionAddForm newItem)
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
                var addedItem = m.AttractionAdd(newItem);

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
                    return Created<AttractionBase>(uri, addedItem);
                }
            }
            else
            {
                // HTTP 400
                return BadRequest(ModelState);
            }
        }
    }
}
