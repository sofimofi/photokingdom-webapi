using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class AttractionPhotowarUpload
    {
        public AttractionPhotowarUpload()
        {
            ResidentVotes = new List<Resident>();
        }

        public int Id { get; set; }

        public int? IsWinner { get; set; }

        public int? IsLoser { get; set; }

        [Required]
        public int PhotoId { get; set; }
        
        [Required]
        public int AttractionPhotowarId { get; set; }

        // navigations

        public Photo Photo { get; set; }
        public AttractionPhotowar AttractionPhotoWar { get; set; }
        // all the votes for this Photo
        public ICollection<Resident> ResidentVotes { get; set; }
    }
}