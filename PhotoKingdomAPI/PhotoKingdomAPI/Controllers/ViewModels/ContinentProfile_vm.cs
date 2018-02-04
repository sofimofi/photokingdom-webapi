using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ContinentProfileAdd
    {
        [Required]
        public int ContinentId { get; set; }

        [Required]
        public int PhotoId { get; set; }
    }

    public class ContinentProfileBase : ContinentProfileAdd
    {
        public int Id { get; set; }
    }
}