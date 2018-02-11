using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class AttractionAdd
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public float Lat { get; set; }

        [Required]
        public float Lng { get; set; }

        [Required]
        public int IsActive { get; set; }

        [Required]
        public int CityId { get; set; }
    }

    public class AttractionBase : AttractionAdd
    {
        public int Id { get; set; }
    }

	public class AttractionWithDetails : AttractionBase
	{
		public AttractionWithDetails()
		{
			QueuedUploads = new List<QueueBase>();
			AttractionPhotowars = new List<AttractionPhotowarBase>();
			Owners = new List<ResidentAttractionOwnBase>();
		}

		public String CityName { get; set; }
		public String CityCountryName { get; set; }

		// the queued photo uploads for this Attraction
		public IEnumerable<QueueBase> QueuedUploads { get; set; }
		// all the AttractionPhotowars for this Attraction
		public IEnumerable<AttractionPhotowarBase> AttractionPhotowars { get; set; }
		// all the residents that owned this Attraction
		public IEnumerable<ResidentAttractionOwnBase> Owners { get; set; }
	}
}