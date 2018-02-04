using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class PingAdd
    {
        public PingAdd()
        {
            PingDate = DateTime.Now;
            ExpiryDate = DateTime.Now.AddDays(7);
        }

        [Required]
        public DateTime PingDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public int ResidentId { get; set; }

        [Required]
        public int AttractionId { get; set; }
    }

    public class PingBase : PingAdd
    {
        public int Id { get; set; }
    }
}