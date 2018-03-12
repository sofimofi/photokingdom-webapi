using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class Attraction
    {
        public Attraction()
        {
            QueuedUploads = new List<Queue>();
            AttractionPhotowars = new List<AttractionPhotowar>();
            Owners = new List<ResidentAttractionOwn>();
        }

        public int Id { get; set; }

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

        // navigations

        public City City { get; set; }
        // the queued photo uploads for this Attraction
        public ICollection<Queue> QueuedUploads { get; set; }
        // all the AttractionPhotowars for this Attraction
        public ICollection<AttractionPhotowar> AttractionPhotowars { get; set; }
        // all the residents that owned this Attraction
        public ICollection<ResidentAttractionOwn> Owners { get; set; }
    }
}