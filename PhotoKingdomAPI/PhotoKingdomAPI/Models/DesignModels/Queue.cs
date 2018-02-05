using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class Queue
    {
        public int Id { get; set; }

        [Required]
        public DateTime QueueDate { get; set; }

        [Required]
        //public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }

        [Required]
        //public int AttractionPhotowarUploadId { get; set; }
        public AttractionPhotowarUpload AttractionPhotowarUpload { get; set; }
    }
}