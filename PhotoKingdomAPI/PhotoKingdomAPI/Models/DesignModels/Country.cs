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
            Provinces = new List<Province>();
            Owners = new List<ResidentCountryOwn>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public int ContinentId { get; set; }

        // navigation

        public Continent Continent { get; set; }

        // All provinces in this country
        public ICollection<Province> Provinces { get; set; }

        // all the residents that owned this country
        public ICollection<ResidentCountryOwn> Owners { get; set; }
    }
}