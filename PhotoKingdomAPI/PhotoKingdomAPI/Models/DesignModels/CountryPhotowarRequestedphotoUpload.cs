using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class CountryPhotowarRequestedphotoUpload
    {
        public int Id { get; set; }

        [Required]
        public int IsChosenCompetitor { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int CountryPhotowarPhotorequestId { get; set; }

        // navigations
        public Photo Photo { get; set; }
        public CountryPhotowarPhotorequest CountryPhotowarPhotorequest { get; set; }
    }
}