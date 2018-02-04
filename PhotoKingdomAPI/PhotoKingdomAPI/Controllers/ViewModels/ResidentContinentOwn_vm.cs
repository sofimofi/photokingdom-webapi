using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ResidentContinentOwnAdd
    {
        public ResidentContinentOwnAdd()
        {
            StartOfOwn = DateTime.Now;
            EndOfOwn = DateTime.Now;
        }

        [Required]
        public DateTime StartOfOwn { get; set; }

        public DateTime EndOfOwn { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public int ResidentId { get; set; }

        [Required]
        public int ContinentId { get; set; }
    }

    public class ResidentContinentOwnBase : ResidentContinentOwnAdd
    {
        public int Id { get; set; }
    }
}