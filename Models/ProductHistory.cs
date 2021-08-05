using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("productHistory")]
    public partial class ProductHistory
    {
        public ProductHistory()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("idProductHistory", TypeName = "int(11)")]
        public int IdProductHistory { get; set; }
        [Column("purchasingProductCounter", TypeName = "int(11)")]
        public int PurchasingProductCounter { get; set; }
        [Column("clientComments", TypeName = "text")]
        public string ClientComments { get; set; }
        [Column("clientRating")]
        public double? ClientRating { get; set; }

        [InverseProperty(nameof(Product.IdProductHistoryNavigation))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
