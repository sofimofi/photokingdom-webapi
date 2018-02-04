using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class AttractionPhotowarUploadAdd
    {
        public int IsWinner { get; set; }

        public int IsLoser { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int AttractionPhotowarId { get; set; }
    }

    public class AttractionPhotowarUploadBase : AttractionPhotowarUploadAdd
    {
        public int Id { get; set; }
    }
}