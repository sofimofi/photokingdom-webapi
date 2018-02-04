using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class CountryPhotowarUploadAdd
    {
        public int IsWinner { get; set; }

        public int IsLoser { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int CountryPhotowarId { get; set; }
    }

    public class CountryPhotowarUploadBase : CountryPhotowarUploadAdd
    {
        public int Id { get; set; }
    }
}