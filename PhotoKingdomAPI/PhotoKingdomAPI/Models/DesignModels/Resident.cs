	using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoKingdomAPI.Models
{
    public class Resident
    {
        public Resident()
        {
            Photos = new List<Photo>();
            Pings = new List<Ping>();
            AttractionPhotowarVotes = new List<AttractionPhotowarUpload>();
            CountryPhotowarVotes = new List<CountryPhotowarUpload>();
            ContinentPhotowarVotes = new List<ContinentPhotowarUpload>();
            ResidentAttractionOwns = new List<ResidentAttractionOwn>();
            ResidentCityOwns = new List<ResidentCityOwn>();
            ResidentProvinceOwns = new List<ResidentProvinceOwn>();
            ResidentCountryOwns = new List<ResidentCountryOwn>();
            ResidentContinentOwns = new List<ResidentContinentOwn>();
            RequestedCountryPhotowarPhotorequests = new List<CountryPhotowarPhotorequest>();
            ReceivedCountryPhotowarPhotorequests = new List<CountryPhotowarPhotorequest>();
            RequestedContinentPhotowarPhotorequests = new List<ContinentPhotowarPhotorequest>();
            ReceivedContinentPhotowarPhotorequests = new List<ContinentPhotowarPhotorequest>();
        }

        public int Id { get; set; }

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

        // navigations

        // the city the Resident belongs to
        public City City { get; set; }

        // Resident's photos
        public ICollection<Photo> Photos { get; set; }

        // Resident's pings
        public ICollection<Ping> Pings { get; set; }

        // the votes that the Resident has made
        public ICollection<AttractionPhotowarUpload> AttractionPhotowarVotes { get; set; }
        public ICollection<CountryPhotowarUpload> CountryPhotowarVotes { get; set; }
        public ICollection<ContinentPhotowarUpload> ContinentPhotowarVotes { get; set; }

        // all the "owns" this resident has had
        public ICollection<ResidentAttractionOwn> ResidentAttractionOwns { get; set; }
        public ICollection<ResidentCityOwn> ResidentCityOwns { get; set; }
        public ICollection<ResidentProvinceOwn> ResidentProvinceOwns { get; set; }
        public ICollection<ResidentCountryOwn> ResidentCountryOwns { get; set; }
        public ICollection<ResidentContinentOwn> ResidentContinentOwns { get; set; }
        
        // the CountryPhotowarPhotorequests this resident has made to subordinates
        [InverseProperty("RequestingResident")]
        public ICollection<CountryPhotowarPhotorequest> RequestedCountryPhotowarPhotorequests { get; set; }
        
        // the CountryPhotowarPhotorequests this resident has received from the King/Queen
        [InverseProperty("RecipientResident")]
        public ICollection<CountryPhotowarPhotorequest> ReceivedCountryPhotowarPhotorequests { get; set; }
        
        // the ContinentPhotowarPhotorequests this resident has made to subordinates
        [InverseProperty("RequestingResident")]
        public ICollection<ContinentPhotowarPhotorequest> RequestedContinentPhotowarPhotorequests { get; set; }
        
        // the ContinentPhotowarPhotorequests this resident has received from the Emperor/Empress
        [InverseProperty("RecipientResident")]
        public ICollection<ContinentPhotowarPhotorequest> ReceivedContinentPhotowarPhotorequests { get; set; }
    }
}