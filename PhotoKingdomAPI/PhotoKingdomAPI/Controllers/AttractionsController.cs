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
    }
}
