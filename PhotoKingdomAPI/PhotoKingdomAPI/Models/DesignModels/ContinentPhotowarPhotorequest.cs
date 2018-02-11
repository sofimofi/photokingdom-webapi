using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoKingdomAPI.Models
{
	public class ContinentPhotowarPhotorequest
	{
		public ContinentPhotowarPhotorequest() {
			RequestDate = DateTime.Now;
		}

        public int Id { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public DateTime? AcceptanceDate { get; set; }

        public DateTime? DenialDate { get; set; }

        [Required]
        public int ContinentPhotowarId { get; set; }

		//[Required] // removed constraint because EF won't allow because delete can cause multiple cascade paths
		[ForeignKey("RequestingResident")]
        public int? RequestingResidentId { get; set; }
        
        //[Required] // removed constraint because EF won't allow because delete can cause multiple cascade paths
        [ForeignKey("RecipientResident")]
        public int? RecipientResidentId { get; set; }

        // navigations
        public ContinentPhotowar ContinentPhotoWar { get; set; }
        public Resident RequestingResident { get; set; }
        public Resident RecipientResident { get; set; }
    }
}