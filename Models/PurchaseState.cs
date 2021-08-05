using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("purchaseState")]
    public partial class PurchaseState
    {
        public PurchaseState()
        {
            Purchases = new HashSet<Purchase>();
        }

        [Key]
        [Column("idPurchaseState", TypeName = "int(11)")]
        public int IdPurchaseState { get; set; }
        [Required]
        [Column("purchaseState")]
        [StringLength(50)]
        public string PurchaseState1 { get; set; }

        [InverseProperty(nameof(Purchase.IdPurchaseStateNavigation))]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
