using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class CityAdd
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        // Required a province without a country
        [Required]
        public int ProvinceId { get; set; }
    }

    public class CityBase : CityAdd
    {
        public int Id { get; set; }
    }

    public class CityWithDetails : CityBase
    {
        public CityWithDetails()
        {
            Owners = new List<ResidentCityOwnBase>();
        }
        public String CountryName { get; set; }
        public String ProvinceName { get; set; }

        // all the residents that owned this City
        public IEnumerable<ResidentCityOwnBase> Owners { get; set; }
    }
}