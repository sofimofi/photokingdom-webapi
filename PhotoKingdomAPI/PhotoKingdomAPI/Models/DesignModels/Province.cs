using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class Province
    {
        public Province()
        {
            Owners = new List<ResidentProvinceOwn>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        // navigation

        public Country Country { get; set; }
        // all the residents that owned this province
        public ICollection<ResidentProvinceOwn> Owners { get; set; }
    }
}