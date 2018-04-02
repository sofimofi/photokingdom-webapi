using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class AttractionPhotowar
    {
        public AttractionPhotowar()
        {
            AttractionPhotowarUploads = new List<AttractionPhotowarUpload>();
			StartDate = DateTime.Now;
			EndDate = DateTime.Now.AddDays(3);
        }

        public int Id { get; set; }

        [Required]	
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        // Extension Date in case vote is tied by enddate
        public DateTime? ExtendedDate { get; set; }

        [Required]
        public int AttractionId { get; set; }

        // navigations

        public Attraction Attraction { get; set; }
        // the two photos uploaded for this PhotoWar
        public ICollection<AttractionPhotowarUpload> AttractionPhotowarUploads { get; set; }
    }
}