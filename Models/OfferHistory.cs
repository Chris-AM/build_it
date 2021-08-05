using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("offerHistory")]
    public partial class OfferHistory
    {
        public OfferHistory()
        {
            Offers = new HashSet<Offer>();
        }

        [Key]
        [Column("idOfferHistory", TypeName = "int(11)")]
        public int IdOfferHistory { get; set; }
        [Column("offerCounting", TypeName = "int(11)")]
        public int OfferCounting { get; set; }

        [InverseProperty(nameof(Offer.IdOfferHistoryNavigation))]
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
