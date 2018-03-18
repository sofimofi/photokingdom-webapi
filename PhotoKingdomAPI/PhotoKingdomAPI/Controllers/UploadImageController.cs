using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhotoKingdomAPI.Controllers
{
    [RoutePrefix("Upload")]
    public class UploadImageController : ApiController
    {
        private UploadManager um = new UploadManager();

        // POST: /Upload/Images
        [Route("Images")]
        public async Task<HttpResponseMessage> Post()
        {
            string path = string.Empty;

            try
            {
                path = await um.UploadAsync(Request);
            }
            catch (HttpResponseException e)
            {
                // Not supported or image type
                return Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(path)
            };
        }
    }
}