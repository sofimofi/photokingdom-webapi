using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class AttractionPhotowarAdd
    {
        public AttractionPhotowarAdd()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(3);
        }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        // Extension Date in case vote is tied by enddate
        public DateTime? ExtendedDate { get; set; }

        [Required]
        public int AttractionId { get; set; }
    }

    public class AttractionPhotowarBase : AttractionPhotowarAdd
    {
        public int Id { get; set; }
    }

	public class AttractionPhotowarWithDetails : AttractionPhotowarBase
	{
		public AttractionPhotowarWithDetails()
		{
			AttractionPhotowarUploads = new List<AttractionPhotowarUploadForPhotowar>();
            residentInPhotowar = -1; // default null
		}

        public AttractionBase Attraction { get; set; }
		// the two photos uploaded for this PhotoWar
		public IEnumerable<AttractionPhotowarUploadForPhotowar> AttractionPhotowarUploads { get; set; }

        // Additional information for Voting

        // whether Resident's own photo is in this photowar
        public int residentInPhotowar { get; set; }
	}

    // Class to be posted from Android app to create photowar between current ownder and competitor
    public class AttractionPhotoWarAddForm
    {
        [Required]
        public int AttractionId { get; set; }

        //[Required]
        //public int OwnerId { get; set; }

        [Required]
        public int CompetitorId { get; set; }

        // new uploaded photo info
        [Required]
        public String PhotoImagePath { get; set; }

        [Required]
        public double PhotoLat { get; set; }

        [Required]
        public double PhotoLng { get; set; }

        [Required]
        public String PlaceId { get; set; }
    }
}