using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class Resident
    {
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
        //public int CityId { get; set; }
        public City City { get; set; }

        // Votes
        public ICollection<AttractionPhotowarUpload> AttractionPhotowarVote { get; set; }
        public ICollection<CountryPhotowarUpload> CountryPhotowarVote { get; set; }
        public ICollection<ContinentPhotowarUpload> ContinentPhotowarVote { get; set; }
    }
}