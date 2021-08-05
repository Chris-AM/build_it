using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("offerState")]
    public partial class OfferState
    {
        public OfferState()
        {
            Offers = new HashSet<Offer>();
        }

        [Key]
        [Column("idOfferState", TypeName = "int(11)")]
        public int IdOfferState { get; set; }
        [Required]
        [Column("offerState")]
        [StringLength(50)]
        public string OfferState1 { get; set; }
        [Column("modificationDate", TypeName = "date")]
        public DateTime ModificationDate { get; set; }

        [InverseProperty(nameof(Offer.IdOfferStateNavigation))]
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
