using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoKingdomAPI.Models
{
    public class CountryPhotowarPhotorequest
    {
        public int Id { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public DateTime AcceptanceDate { get; set; }

        public DateTime DenialDate { get; set; }

        [Required]
        public int CountryPhotowarId { get; set; }

        [Required]
        [ForeignKey("Resident")]
        public int RequestingResidentId { get; set; }

        [Required]
        [ForeignKey("Resident")]
        public int RecipientResidentId { get; set; }
    }
}