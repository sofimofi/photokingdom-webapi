using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class ContinentProfile
    {
        public int Id { get; set; }

        [Required]
        //public int ContinentId { get; set; }
        public Continent Continent { get; set; }
        
        [Required]
        //public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}