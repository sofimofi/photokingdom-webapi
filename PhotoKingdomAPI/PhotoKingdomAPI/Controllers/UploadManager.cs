using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace PhotoKingdomAPI.Controllers
{
    public class UploadManager
    {
        public async Task<string> UploadAsync(HttpRequestMessage request)
        {
            // Check if the request contains multipart / form - data.
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            // Path to save uploaded image files
            string root = HttpContext.Current.Server.MapPath("~/img");
            var provider = new FileDataStreamProvider(root);

            try
            {
                // Read the form data and return an async task.
                await request.Content.ReadAsMultipartAsync(provider);

                string result = string.Empty;

                // This illustrates how to get the file names for uploaded files.
                foreach (var file in provider.FileData)
                {
                    FileInfo fileInfo = new FileInfo(file.LocalFileName);
                    UploadedFileInfo uploadedFileInfo = new UploadedFileInfo();
                    uploadedFileInfo.Path = string.Format("img/{0}", fileInfo.Name);

                    // Return data to Json
                    result = JsonConvert.SerializeObject(uploadedFileInfo);
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// This class is to check a uploaded file extension,
    /// and generate unigue file name with a uploaded file extention
    /// </summary>
    public class FileDataStreamProvider : MultipartFormDataStreamProvider
    {
        public FileDataStreamProvider(string path) : base(path)
        {
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string name = headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            string ext = name.Substring(name.LastIndexOf('.')).ToLower();

            // Allow only image files
            var imgTypes = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            if (!imgTypes.Contains(ext))
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            return Guid.NewGuid() + ext.ToLower();
        }
    }

    /// <summary>
    /// This class is for json seialization of return data
    /// NOTE: This will include photo's data
    /// </summary>
    public class UploadedFileInfo
    {
        public string Path { get; set; }
    }
}