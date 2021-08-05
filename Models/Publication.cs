using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("publication")]
    [Index(nameof(IdProduct), Name = "fk_publication_product")]
    [Index(nameof(IdPublicationHistory), Name = "fk_publication_publicationHistory")]
    [Index(nameof(IdPublicationState), Name = "fk_publication_publicationState")]
    [Index(nameof(UserId), Name = "fk_publication_user")]
    public partial class Publication
    {
        public Publication()
        {
            Purchases = new HashSet<Purchase>();
        }

        [Key]
        [Column("idPublication", TypeName = "int(11)")]
        public int IdPublication { get; set; }
        [Required]
        [Column("publicationDescription")]
        public string PublicationDescription { get; set; }
        [Column("startDate", TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column("finishDate", TypeName = "date")]
        public DateTime FinishDate { get; set; }
        [Column("views", TypeName = "int(11)")]
        public int Views { get; set; }
        [Column("idProduct", TypeName = "int(11)")]
        public int IdProduct { get; set; }
        [Column("idPublicationState", TypeName = "int(11)")]
        public int IdPublicationState { get; set; }
        [Column("idPublicationHistory", TypeName = "int(11)")]
        public int IdPublicationHistory { get; set; }
        [Column("userID", TypeName = "int(11)")]
        public int UserId { get; set; }

        [ForeignKey(nameof(IdProduct))]
        [InverseProperty(nameof(Product.Publications))]
        public virtual Product IdProductNavigation { get; set; }
        [ForeignKey(nameof(IdPublicationHistory))]
        [InverseProperty(nameof(PublicationHistory.Publications))]
        public virtual PublicationHistory IdPublicationHistoryNavigation { get; set; }
        [ForeignKey(nameof(IdPublicationState))]
        [InverseProperty(nameof(PublicationState.Publications))]
        public virtual PublicationState IdPublicationStateNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Publications")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Purchase.IdPublicationNavigation))]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
