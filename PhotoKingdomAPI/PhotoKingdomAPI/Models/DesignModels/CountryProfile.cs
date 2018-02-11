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
        public int CountryId { get; set; }

        //[Required] // removed constraint because EF warns of multiple cascade paths on delete
        public int? PhotoId { get; set; }

        // navigations
        public Country Country { get; set; }
        public Photo Photo { get; set; }
    }
}