﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoKingdomAPI.Models
{
    public class CountryPhotowar
    {
        public int Id { get; set; }

        [Required]
        public DateTime DeclarationDate { get; set; }

        public DateTime AcceptanceDate { get; set; }

        public DateTime SurrenderDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public int IsCancelled { get; set; }

        [Required]
        /*[ForeignKey("CountryProfile")]
        public int DeclaringCountryId { get; set; }*/
        public CountryProfile DeclaringCountry { get; set; }

        [Required]
        /*[ForeignKey("CountryProfile")]
        public int RecipentCountryId { get; set; }*/
        public CountryProfile RecipientCountry { get; set; }
    }
}