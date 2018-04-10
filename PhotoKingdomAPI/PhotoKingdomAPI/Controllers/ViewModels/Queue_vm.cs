using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class QueueAdd
    {
		public QueueAdd()
		{
			QueueDate = DateTime.Now;
		}
        [Required]
        public DateTime QueueDate { get; set; }

        [Required]
        public int AttractionId { get; set; }

        [Required]
        public int AttractionPhotowarUploadId { get; set; }
    }

    public class QueueBase : QueueAdd
    {
        public int Id { get; set; }
    }

	public class QueueWithDetails : QueueBase
	{
		public AttractionBase Attraction { get; set; }
		// the photo uploaded
		public AttractionPhotowarUploadBase AttractionPhotowarUpload { get; set; }

        public int AttractionPhotowarUploadPhotoId { get; set; }

        public string AttractionPhotowarUploadPhotoPhotoFilePath { get; set; }

        public string AttractionPhotowarUploadPhotoResidentId { get; set; }

        public string AttractionPhotowarUploadPhotoResidentUserName { get; set; }
    }
}
