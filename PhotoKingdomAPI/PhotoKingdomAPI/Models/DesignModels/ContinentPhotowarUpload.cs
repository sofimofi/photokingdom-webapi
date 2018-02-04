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
        public int PhotoId { get; set; }

        [Required]
        public int ContinentPhotowarId { get; set; }
    }
}