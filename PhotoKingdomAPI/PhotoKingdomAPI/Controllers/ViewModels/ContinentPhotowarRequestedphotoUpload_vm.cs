using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ContinentPhotowarRequestedphotoUploadAdd
    {
        [Required]
        public int IsChosenCompetitor { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int ContinentPhotowarPhotorequestId { get; set; }
    }

    public class ContinentPhotowarRequestedphotoUploadBase : ContinentPhotowarRequestedphotoUploadAdd
    {
        public int Id { get; set; }
    }

	public class ContinentPhotowarRequestedphotoUploadWithDetails : ContinentPhotowarRequestedphotoUploadBase
	{
		public PhotoBase Photo { get; set; }
		public CountryPhotowarPhotorequestBase CountryPhotowarPhotorequest { get; set; }
	}
}