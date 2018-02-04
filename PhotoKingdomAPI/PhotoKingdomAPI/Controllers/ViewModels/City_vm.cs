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

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int ProvinceId { get; set; }
    }

    public class CityBase : CityAdd
    {
        public int Id { get; set; }
    }
}