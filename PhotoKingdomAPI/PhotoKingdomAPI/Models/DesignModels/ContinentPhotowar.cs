using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoKingdomAPI.Models
{
    public class ContinentPhotowar
    {
        public ContinentPhotowar()
        {
            ContinentPhotowarUploads = new List<ContinentPhotowarUpload>();
			DeclarationDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public DateTime DeclarationDate { get; set; }

        public DateTime? AcceptanceDate { get; set; }

        public DateTime? SurrenderDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public int IsCancelled { get; set; }

        [Required]
        [ForeignKey("DeclaringContinent")]
        public int DeclaringContinentId { get; set; }

        [Required]
        [ForeignKey("RecipientContinent")]
        public int RecipentContinentId { get; set; }

        // navigations

        public ContinentProfile DeclaringContinent { get; set; }
        public ContinentProfile RecipientContinent { get; set; }
        // the two photos uploaded for this photowar
        public ICollection<ContinentPhotowarUpload> ContinentPhotowarUploads { get; set; }
    }
}