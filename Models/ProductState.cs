using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("productState")]
    public partial class ProductState
    {
        public ProductState()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("idProductSatate", TypeName = "int(11)")]
        public int IdProductSatate { get; set; }
        [Required]
        [Column("productState")]
        [StringLength(50)]
        public string ProductState1 { get; set; }
        [Column("modificationDate", TypeName = "date")]
        public DateTime ModificationDate { get; set; }

        [InverseProperty(nameof(Product.IdProductSatateNavigation))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
