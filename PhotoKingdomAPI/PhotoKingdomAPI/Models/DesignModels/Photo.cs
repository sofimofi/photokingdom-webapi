using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class Photo
    {
        public Photo()
        {
            AttractionPhotowarUploads = new List<AttractionPhotowarUpload>();
            CountryPhotowarUploads = new List<CountryPhotowarUpload>();
            ContinentPhotowarUploads = new List<ContinentPhotowarUpload>();
            CountryPhotowarRequestedphotoUploads = new List<CountryPhotowarRequestedphotoUpload>();
            ContinentPhotowarRequestedphotoUploads = new List<ContinentPhotowarRequestedphotoUpload>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string PhotoFilePath { get; set; }

        [Required]
        public double Lat { get; set; }

        [Required]
        public double Lng { get; set; }

        [Required]
        public int ResidentId { get; set; }

        // navigation

        public Resident Resident { get; set; }
        
        // the Photowars this photo has participated in
        public ICollection<AttractionPhotowarUpload> AttractionPhotowarUploads { get; set; }
        public ICollection<CountryPhotowarUpload> CountryPhotowarUploads { get; set; }
        public ICollection<ContinentPhotowarUpload> ContinentPhotowarUploads { get; set; }

        // the PhotowarPhotorequests by leaders that this photo has uploaded for
        public ICollection<CountryPhotowarRequestedphotoUpload> CountryPhotowarRequestedphotoUploads { get; set; }
        public ICollection<ContinentPhotowarRequestedphotoUpload> ContinentPhotowarRequestedphotoUploads { get; set; }
    }
}