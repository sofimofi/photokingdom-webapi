using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class Continent
    {
        public Continent()
        {
            Owners = new List<ResidentContinentOwn>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        // navigation
        // all the residents that owned this Continent
        public ICollection<ResidentContinentOwn> Owners { get; set; }
    }
}