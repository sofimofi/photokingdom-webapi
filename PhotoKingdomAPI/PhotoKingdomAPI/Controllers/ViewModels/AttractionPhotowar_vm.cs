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
        public int residentInPhotowar;
	}

}