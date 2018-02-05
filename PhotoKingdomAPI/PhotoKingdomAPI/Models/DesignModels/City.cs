using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        //public int CountryId { get; set; }
        public Country Country { get; set; }

        //public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}