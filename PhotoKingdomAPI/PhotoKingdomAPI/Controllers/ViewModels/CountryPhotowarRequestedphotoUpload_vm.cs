using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class CountryPhotowarRequestedphotoUploadAdd
    {
        [Required]
        public int IsChosenCompetitor { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int CountryPhotowarPhotorequestId { get; set; }
    }

    public class CountryPhotowarRequestedphotoUploadBase : CountryPhotowarRequestedphotoUploadAdd
    {
        public int Id { get; set; }
    }

	public class CountryPhotowarRequestedphotoUploadWithDetails : CountryPhotowarRequestedphotoUploadBase
	{
		public PhotoBase Photo { get; set; }
		public CountryPhotowarPhotorequestBase CountryPhotowarPhotorequest { get; set; }
	}
}
