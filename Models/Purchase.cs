using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("purchase")]
    [Index(nameof(IdPayMethod), Name = "fk_purchase_metodoPago")]
    [Index(nameof(IdPublication), Name = "fk_purchase_publication")]
    [Index(nameof(IdPurchasingHistory), Name = "fk_purchase_purchaseHistory")]
    [Index(nameof(IdPurchaseState), Name = "fk_purchase_purchaseState")]
    public partial class Purchase
    {
        public Purchase()
        {
            Shippings = new HashSet<Shipping>();
        }

        [Key]
        [Column("idPurchase", TypeName = "int(11)")]
        public int IdPurchase { get; set; }
        [Column("purchaseTotal", TypeName = "int(11)")]
        public int PurchaseTotal { get; set; }
        [Column("purchaseCommisionTotal")]
        public double PurchaseCommisionTotal { get; set; }
        [Column("purchaseTax")]
        public double PurchaseTax { get; set; }
        [Column("purchaseDate", TypeName = "date")]
        public DateTime PurchaseDate { get; set; }
        [Column("idPurchaseState", TypeName = "int(11)")]
        public int IdPurchaseState { get; set; }
        [Column("idPurchasingHistory", TypeName = "int(11)")]
        public int IdPurchasingHistory { get; set; }
        [Column("idPayMethod", TypeName = "int(11)")]
        public int IdPayMethod { get; set; }
        [Column("idPublication", TypeName = "int(11)")]
        public int IdPublication { get; set; }

        [ForeignKey(nameof(IdPayMethod))]
        [InverseProperty(nameof(PayMethod.Purchases))]
        public virtual PayMethod IdPayMethodNavigation { get; set; }
        [ForeignKey(nameof(IdPublication))]
        [InverseProperty(nameof(Publication.Purchases))]
        public virtual Publication IdPublicationNavigation { get; set; }
        [ForeignKey(nameof(IdPurchaseState))]
        [InverseProperty(nameof(PurchaseState.Purchases))]
        public virtual PurchaseState IdPurchaseStateNavigation { get; set; }
        [ForeignKey(nameof(IdPurchasingHistory))]
        [InverseProperty(nameof(PurchaseHistory.Purchases))]
        public virtual PurchaseHistory IdPurchasingHistoryNavigation { get; set; }
        [InverseProperty(nameof(Shipping.IdpurchaseNavigation))]
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
