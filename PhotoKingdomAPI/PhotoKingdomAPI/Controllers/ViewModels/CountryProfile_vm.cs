using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class CountryProfileAdd
    {
        [Required]
        public int CountryId { get; set; }

        [Required]
        public int PhotoId { get; set; }
    }

    public class CountryProfileBase : CountryProfileAdd
    {
        public int Id { get; set; }
    }
}