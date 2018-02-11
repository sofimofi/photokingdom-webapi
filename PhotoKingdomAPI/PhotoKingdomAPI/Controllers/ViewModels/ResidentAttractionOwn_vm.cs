using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ResidentAttractionOwnAdd
    {
        public ResidentAttractionOwnAdd()
        {
            StartOfOwn = DateTime.Now;
        }

        [Required]
        public DateTime StartOfOwn { get; set; }

        public DateTime? EndOfOwn { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public int ResidentId { get; set; }

        [Required]
        public int AttractionId { get; set; }
    }

    public class ResidentAttractionOwnBase : ResidentAttractionOwnAdd
    {
        public int Id { get; set; }
    }

	public class ResidentAttractionOwnWithDetails : ResidentAttractionOwnBase
	{
		public ResidentBase Resident { get; set; }
		public AttractionBase Attraction { get; set; }
	}
}