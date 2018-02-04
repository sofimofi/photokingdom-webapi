using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class ContinentPhotowarRequestedphotoUpload
    {
        public int Id { get; set; }

        [Required]
        public int IsChosenCompetitor { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int ContinentPhotowarPhotorequestId { get; set; }
    }
}