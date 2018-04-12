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
        public string googlePlaceId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public double Lat { get; set; }

        [Required]
        public double Lng { get; set; }

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

        public int CurrentAttractionPhotowarUploadsCount { get; set; }
        public String CityName { get; set; }
        public String CityProvinceCountryName { get; set; }

        // Winning photo
        public String PhotoImagePath { get; set; }

        // Attraction owner
        public String OwnerName { get; set; }

        // the queued photo uploads for this Attraction
        public IEnumerable<QueueBase> QueuedUploads { get; set; }
        // all the AttractionPhotowars for this Attraction
        public IEnumerable<AttractionPhotowarBase> AttractionPhotowars { get; set; }
        // all the residents that owned this Attraction
        public IEnumerable<ResidentAttractionOwnBase> Owners { get; set; }
    }

    public class AttractionForMapView : AttractionBase
    {
        public AttractionForMapView()
        {
            Owners = new List<ResidentAttractionOwnForMapView>();
            AttractionPhotowars = new List<AttractionPhotowarBase>();
        }
        // current owner
        public IEnumerable<ResidentAttractionOwnForMapView> Owners { get; set; }

        // current attractionphotowar, if any
        public IEnumerable<AttractionPhotowarBase> AttractionPhotowars { get; set; }
    }

    // Class to be posted from Android app when City Id is not known - need to provide City Name and Country
    public class AttractionAddForm
    {
        [Required]
        public string googlePlaceId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public double Lat { get; set; }

        [Required]
        public double Lng { get; set; }

        [Required]
        public String CityName { get; set; }

        [Required]
        public String CountryName { get; set; }
    }

    // for update newly added attraction
    public class AttractionWithWin
    {
        [Required]
        public int AttractionId { get; set; }

        // Winning photo
        [Required]
        public String PhotoImagePath { get; set; }

        [Required]
        public double PhotoLat { get; set; }

        [Required]
        public double PhotoLng { get; set; }

        // Attraction owner
        [Required]
        public int OwnerId { get; set; }

        // Google place Id
        [Required]
        public String PlaceId { get; set; }
    }
}