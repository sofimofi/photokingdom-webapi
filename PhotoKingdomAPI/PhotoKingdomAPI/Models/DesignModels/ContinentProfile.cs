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
        public int ContinentId { get; set; }
        
        //[Required] // removed constraint because EF warning multiple cascade paths on delete
        public int? PhotoId { get; set; }

        // navigations
        public Continent Continent { get; set; }
        public Photo Photo { get; set; }
    }
}