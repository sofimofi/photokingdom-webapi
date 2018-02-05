using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class CountryProfile
    {
        public int Id { get; set; }

        [Required]
        //public int CountryId { get; set; }
        public Country Country { get; set; }

        [Required]
        //public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}