using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("purchaseHistory")]
    public partial class PurchaseHistory
    {
        public PurchaseHistory()
        {
            Purchases = new HashSet<Purchase>();
        }

        [Key]
        [Column("idPurchasingHistory", TypeName = "int(11)")]
        public int IdPurchasingHistory { get; set; }
        [Column("purchasingHistory", TypeName = "int(11)")]
        public int PurchasingHistory { get; set; }

        [InverseProperty(nameof(Purchase.IdPurchasingHistoryNavigation))]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
