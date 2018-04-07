using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoKingdomAPI.Controllers
{
    [RoutePrefix("api/AttractionPhotowars")]
    public class AttractionPhotowarsController : ApiController
    {
        private Manager m = new Manager();

        // GET: api/AttractionPhotowars
        public IHttpActionResult Get()
        {
            return Ok(m.AttractionPhotowarGetAllWithDetails());
        }

        // GET: api/AttractionPhotowars/5
        [Route("{id:int}")]
        public IHttpActionResult GetAttractionPhotowar(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.AttractionPhotowarGetById(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // GET: api/AttractionPhotowars/{id}/details
        [Route("{id:int}/details")]
        public IHttpActionResult GetAttractionPhotowarDetails(int? id, int? residentId = null)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.AttractionPhotowarGetByIdWithDetails(id.Value, residentId);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // GET: api/AttractionPhotowars/{id}/AddVote
        [HttpGet]
        [Route("{id:int}/AddVote")]
        public IHttpActionResult AttractionPhotowarPhotoVoteAdd(int? id, int? photoUploadId, int? residentId)
        {
            if (!id.HasValue || !photoUploadId.HasValue || !residentId.HasValue)
            {
                return NotFound();
            }

            var o = m.AttractionPhotowarAddPhotoVote(id.Value, photoUploadId.Value, residentId.Value);

            if (o != null)
            {
                return Ok(o);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/AttractionPhotowars/{id}/RemoveVote
        [HttpGet]
        [Route("{id:int}/RemoveVote")]
        public IHttpActionResult AttractionPhotowarPhotoVoteRemove(int? id, int? photoUploadId, int? residentId)
        {
            if(!id.HasValue || !photoUploadId.HasValue || !residentId.HasValue)
            {
                return NotFound();
            }

            var o = m.AttractionPhotowarRemovePhotoVote(id.Value, photoUploadId.Value, residentId.Value);

            if (o != null)
            {
                return Ok(o);
            } else
            {
                return NotFound();
            }
        }

        // POST: api/AttractionPhotowars
        public IHttpActionResult Post([FromBody]AttractionPhotowarAdd newItem)
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
                var addedItem = m.AttractionPhotowarAdd(newItem);

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
                    return Created<AttractionPhotowarBase>(uri, addedItem);
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
