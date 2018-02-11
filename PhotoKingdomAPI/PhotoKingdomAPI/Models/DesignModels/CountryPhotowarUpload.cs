using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class CountryPhotowarUpload
    {
        public CountryPhotowarUpload()
        {
            ResidentVotes = new List<Resident>();
        }

        public int Id { get; set; }

        public int? IsWinner { get; set; }

        public int? IsLoser { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int CountryPhotowarId { get; set; }

        // navigations
        public Photo Photo { get; set; }
        public CountryPhotowar CountryPhotowar { get; set; }
        // Votes for this CountryPhotowarUpload
        public ICollection<Resident> ResidentVotes { get; set; }

    }
}