using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class CountryPhotowarPhotorequestAdd
    {
        public CountryPhotowarPhotorequestAdd()
        {
            RequestDate = DateTime.Now;
            AcceptanceDate = DateTime.Now.AddDays(5);
            DenialDate = DateTime.Now;
        }

        [Required]
        public DateTime RequestDate { get; set; }

        public DateTime AcceptanceDate { get; set; }

        public DateTime DenialDate { get; set; }

        [Required]
        public int CountryPhotowarId { get; set; }

        [Required]
        public int RequestingResidentId { get; set; }

        [Required]
        public int RecipientResidentId { get; set; }
    }

    public class CountryPhotowarPhotorequestBase : CountryPhotowarPhotorequestAdd
    {
        public int Id { get; set; }
    }
}