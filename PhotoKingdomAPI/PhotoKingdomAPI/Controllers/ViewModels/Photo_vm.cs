using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class PhotoAdd
    {
        [Required]
        [StringLength(100)]
        public string PhotoFilePath { get; set; }

        [Required]
        public float Lat { get; set; }

        [Required]
        public float Lng { get; set; }

        public int ResidentId { get; set; }
    }

    public class PhotoBase : PhotoAdd
    {
        public int Id { get; set; }
    }
}