using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoKingdomAPI.Models
{
    public class ContinentPhotowarPhotorequest
    {
        public int Id { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public DateTime AcceptanceDate { get; set; }

        public DateTime DenialDate { get; set; }

        [Required]
        //public int ContinentPhotowarId { get; set; }
        public ContinentPhotowar ContinentPhotoWar { get; set; }

        [Required]
        /*[ForeignKey("Resident")]
        public int RequestingResidentId { get; set; }*/
        public Resident RequestingResident { get; set; }
        
        [Required]
        /*[ForeignKey("Resident")]
        public int RecipientResidentId { get; set; }*/
        public Resident RecipientResident { get; set; }
    }
}