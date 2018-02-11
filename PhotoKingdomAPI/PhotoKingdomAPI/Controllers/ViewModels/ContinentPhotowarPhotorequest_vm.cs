using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ContinentPhotowarPhotorequestAdd
    {
        public ContinentPhotowarPhotorequestAdd()
        {
            RequestDate = DateTime.Now;
            //the following dates depends on if/when user takes action
			//AcceptanceDate = DateTime.Now.AddDays(5);
            //DenialDate = DateTime.Now;
        }

        [Required]
        public DateTime RequestDate { get; set; }

        public DateTime? AcceptanceDate { get; set; }

        public DateTime? DenialDate { get; set; }

        [Required]
        public int ContinentPhotowarId { get; set; }

        [Required]
        public int RequestingResidentId { get; set; }

        [Required]
        public int RecipientResidentId { get; set; }
    }

    public class ContinentPhotowarPhotorequestBase : ContinentPhotowarPhotorequestAdd
    {
        public int Id { get; set; }
    }

	public class ContinentPhotowarPhotorequestWithDetails : ContinentPhotowarPhotorequestBase
	{
		public ContinentPhotowarBase ContinentPhotoWar { get; set; }
		public ResidentBase RequestingResident { get; set; }
		public ResidentBase RecipientResident { get; set; }
	}
}