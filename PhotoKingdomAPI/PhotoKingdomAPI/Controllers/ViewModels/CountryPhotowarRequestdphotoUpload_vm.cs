using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class CountryPhotowarRequestdphotoUploadAdd
    {
        [Required]
        public int IsChosenCompetitor { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int CountryPhotowarPhotorequestId { get; set; }
    }

    public class CountryPhotowarRequestdphotoUploadBase : CountryPhotowarRequestdphotoUploadAdd
    {
        public int Id { get; set; }
    }
}