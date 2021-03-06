﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoKingdomAPI.Controllers
{
    [RoutePrefix("api/AttractionPhotowarUploads")]
    public class AttractionPhotowarUploadsController : ApiController
    {
        private Manager m = new Manager();

        // GET: api/AttractionPhotowarUploads
        public IHttpActionResult Get()
        {
            return Ok(m.AttractionPhotowarUploadGetAll());
        }

        // GET: api/AttractionPhotowarUploads/5
        [Route("{id:int}")]
        public IHttpActionResult GetAttractionPhotowarUpload(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.AttractionPhotowarUploadGetById(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // GET: api/AttractionPhotowarUploads/5/details
        [Route("{id:int}/details")]
        public IHttpActionResult GetAttractionPhotowarUploadWithDetails(int? id)
        {
            // Determine whether we can continue
            if (!id.HasValue) { return NotFound(); }

            // Fetch the object, so that we can inspect its value
            var o = m.AttractionPhotowarUploadGetByIdWithDetails(id.Value);

            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }

        // POST: api/AttractionPhotowarUploads
        public IHttpActionResult Post([FromBody]AttractionPhotowarUploadAdd newItem)
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
                var addedItem = m.AttractionPhotowarUploadAdd(newItem);

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
                    return Created<AttractionPhotowarUploadBase>(uri, addedItem);
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
