using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("world")]
    public partial class World
    {
        public World()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("idWorld", TypeName = "int(11)")]
        public int IdWorld { get; set; }
        [Required]
        [Column("worldName")]
        [StringLength(20)]
        public string WorldName { get; set; }
        [Required]
        [Column("worldDescription")]
        public string WorldDescription { get; set; }

        [InverseProperty(nameof(Product.IdWorldNavigation))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
