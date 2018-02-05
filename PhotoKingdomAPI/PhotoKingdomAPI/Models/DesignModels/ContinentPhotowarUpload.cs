using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class ContinentPhotowarUpload
    {
        public int Id { get; set; }

        public int IsWinner { get; set; }

        public int IsLoser { get; set; }

        [Required]
        //public int PhotoId { get; set; }
        public Photo Photo { get; set; }
        
        [Required]
        //public int ContinentPhotowarId { get; set; }
        public ContinentPhotowar ContinentPhotowar { get; set; }

        // Votes
        public ICollection<Resident> ResidentVote { get; set; }
    }
}