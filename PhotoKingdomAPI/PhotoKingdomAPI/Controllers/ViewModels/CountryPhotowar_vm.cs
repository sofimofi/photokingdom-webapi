using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class CountryPhotowarAdd
    {
        public CountryPhotowarAdd()
        {
            DeclarationDate = DateTime.Now;
            AcceptanceDate = DateTime.Now.AddDays(1);
            SurrenderDate = DateTime.Now;
            StartDate = DateTime.Now.AddDays(2);
            EndDate = DateTime.Now.AddDays(9);
        }

        [Required]
        public DateTime DeclarationDate { get; set; }

        public DateTime AcceptanceDate { get; set; }

        public DateTime SurrenderDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public int IsCancelled { get; set; }

        [Required]
        public int DeclaringCountryId { get; set; }

        [Required]
        public int RecipentCountryId { get; set; }
    }

    public class CountryPhotowarBase : CountryPhotowarAdd
    {
        public int Id { get; set; }
    }
}