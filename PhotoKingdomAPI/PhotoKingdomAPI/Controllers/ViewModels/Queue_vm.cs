using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class QueueAdd
    {
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
}