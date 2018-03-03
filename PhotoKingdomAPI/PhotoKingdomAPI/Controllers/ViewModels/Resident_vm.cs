using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ResidentAdd
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        public int IsActive { get; set; }

        [StringLength(100)]
        public string AvatarImagePath { get; set; }

        [Required]
        public int CityId { get; set; }
    }

    public class ResidentBase : ResidentAdd
    {
        public int Id { get; set; }
    }

	public class ResidentWithDetails : ResidentBase
	{
		public ResidentWithDetails()
		{
			Photos = new List<PhotoBase>();
			Pings = new List<PingBase>();
			AttractionPhotowarVotes = new List<AttractionPhotowarUploadBase>();
			CountryPhotowarVotes = new List<CountryPhotowarUploadBase>();
			ContinentPhotowarVotes = new List<ContinentPhotowarUploadBase>();
			ResidentAttractionOwns = new List<ResidentAttractionOwnBase>();
			ResidentCityOwns = new List<ResidentCityOwnBase>();
			ResidentProvinceOwns = new List<ResidentProvinceOwnBase>();
			ResidentCountryOwns = new List<ResidentCountryOwnBase>();
			ResidentContinentOwns = new List<ResidentContinentOwnBase>();
			RequestedCountryPhotowarPhotorequests = new List<CountryPhotowarPhotorequestBase>();
			ReceivedCountryPhotowarPhotorequests = new List<CountryPhotowarPhotorequestBase>();
			RequestedContinentPhotowarPhotorequests = new List<ContinentPhotowarPhotorequestBase>();
			ReceivedContinentPhotowarPhotorequests = new List<ContinentPhotowarPhotorequestBase>();
        }
		// the city the Resident belongs to
		public String CityName { get; set; }
		public String CityProvinceName { get; set; }
		public String CityCountryName { get; set; }

		// Resident's photos
		public IEnumerable<PhotoBase> Photos { get; set; }

		// Resident's pings
		public IEnumerable<PingBase> Pings { get; set; }

		// the votes that the Resident has made
		public IEnumerable<AttractionPhotowarUploadBase> AttractionPhotowarVotes { get; set; }
		public IEnumerable<CountryPhotowarUploadBase> CountryPhotowarVotes { get; set; }
		public IEnumerable<ContinentPhotowarUploadBase> ContinentPhotowarVotes { get; set; }

		// all the "owns" this resident has had
		public IEnumerable<ResidentAttractionOwnBase> ResidentAttractionOwns { get; set; }
		public IEnumerable<ResidentCityOwnBase> ResidentCityOwns { get; set; }
		public IEnumerable<ResidentProvinceOwnBase> ResidentProvinceOwns { get; set; }
		public IEnumerable<ResidentCountryOwnBase> ResidentCountryOwns { get; set; }
		public IEnumerable<ResidentContinentOwnBase> ResidentContinentOwns { get; set; }

		// the CountryPhotowarPhotorequests this resident has made to subordinates
		public IEnumerable<CountryPhotowarPhotorequestBase> RequestedCountryPhotowarPhotorequests { get; set; }

		// the CountryPhotowarPhotorequests this resident has received from the King/Queen
		public IEnumerable<CountryPhotowarPhotorequestBase> ReceivedCountryPhotowarPhotorequests { get; set; }

		// the ContinentPhotowarPhotorequests this resident has made to subordinates
		public IEnumerable<ContinentPhotowarPhotorequestBase> RequestedContinentPhotowarPhotorequests { get; set; }

		// the ContinentPhotowarPhotorequests this resident has received from the Emperor/Empress
		public IEnumerable<ContinentPhotowarPhotorequestBase> ReceivedContinentPhotowarPhotorequests { get; set; }

        public String Title { get; set; }
    }
}