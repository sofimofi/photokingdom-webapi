using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class CountryPhotowarPhotorequestAdd
    {
        public CountryPhotowarPhotorequestAdd()
        {
            RequestDate = DateTime.Now;
            // the following dates are only used if/when the user takes action
			//AcceptanceDate = DateTime.Now.AddDays(5);
            //DenialDate = DateTime.Now;
        }

        [Required]
        public DateTime RequestDate { get; set; }

        public DateTime? AcceptanceDate { get; set; }

        public DateTime? DenialDate { get; set; }

        [Required]
        public int CountryPhotowarId { get; set; }

        [Required]
        public int RequestingResidentId { get; set; }

        [Required]
        public int RecipientResidentId { get; set; }
    }

    public class CountryPhotowarPhotorequestBase : CountryPhotowarPhotorequestAdd
    {
        public int Id { get; set; }
    }

	public class CountryPhotowarPhotorequestWithDetails : CountryPhotowarPhotorequestBase
	{
		public CountryPhotowarBase CountryPhotowar { get; set; }
		public ResidentBase RequestingResident { get; set; }
		public ResidentBase RecipientResident { get; set; }
	}
}