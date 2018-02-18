using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class City
    {
        public City()
        {
            Owners = new List<ResidentCityOwn>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        // Required a province without a country
        [Required]
        public int ProvinceId { get; set; }

        // navigations
        public Province Province { get; set; }

        // all the residents that owned this City
        public ICollection<ResidentCityOwn> Owners { get; set; }
    }
}