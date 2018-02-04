using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ContinentAdd
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }

    public class ContinentBase : ContinentAdd
    {
        public int Id { get; set; }
    }
}