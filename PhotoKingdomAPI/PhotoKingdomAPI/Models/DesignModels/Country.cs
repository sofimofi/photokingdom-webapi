using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class Country
    {
        public Country()
        {
            Owners = new List<ResidentCountryOwn>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public int ContinentId { get; set; }

        // navigation

        public Continent Continent { get; set; }
        // all the residents that owned this country
        public ICollection<ResidentCountryOwn> Owners { get; set; }
    }
}