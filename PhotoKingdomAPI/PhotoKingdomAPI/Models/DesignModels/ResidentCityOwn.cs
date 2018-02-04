using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class ResidentCityOwn
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartOfOwn { get; set; }

        public DateTime EndOfOwn { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public int ResidentId { get; set; }

        [Required]
        public int CityId { get; set; }
    }
}