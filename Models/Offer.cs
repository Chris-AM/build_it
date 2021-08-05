using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("offer")]
    [Index(nameof(IdOfferHistory), Name = "fk_offer_offerHistory")]
    [Index(nameof(IdOfferState), Name = "fk_offer_offerState")]
    public partial class Offer
    {
        public Offer()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("idOffer", TypeName = "int(11)")]
        public int IdOffer { get; set; }
        [Column("startDate", TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column("finishDate", TypeName = "date")]
        public DateTime FinishDate { get; set; }
        [Column("idOfferState", TypeName = "int(11)")]
        public int IdOfferState { get; set; }
        [Column("idOfferHistory", TypeName = "int(11)")]
        public int IdOfferHistory { get; set; }

        [ForeignKey(nameof(IdOfferHistory))]
        [InverseProperty(nameof(OfferHistory.Offers))]
        public virtual OfferHistory IdOfferHistoryNavigation { get; set; }
        [ForeignKey(nameof(IdOfferState))]
        [InverseProperty(nameof(OfferState.Offers))]
        public virtual OfferState IdOfferStateNavigation { get; set; }
        [InverseProperty(nameof(Product.IdOfferNavigation))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
