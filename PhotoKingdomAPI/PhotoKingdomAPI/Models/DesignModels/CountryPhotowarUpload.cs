using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class CountryPhotowarUpload
    {
        public int Id { get; set; }

        public int IsWinner { get; set; }

        public int IsLoser { get; set; }

        [Required]
        //public int PhotoId { get; set; }
        public Photo Photo { get; set; }

        [Required]
        //public int CountryPhotowarId { get; set; }
        public CountryPhotowar CountryPhotowar { get; set; }

        // Votes
        public ICollection<Resident> ResidentVote { get; set; }

    }
}