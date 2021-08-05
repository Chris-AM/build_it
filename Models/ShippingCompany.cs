using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("shippingCompany")]
    public partial class ShippingCompany
    {
        public ShippingCompany()
        {
            Shippings = new HashSet<Shipping>();
        }

        [Key]
        [Column("idShippingCompany", TypeName = "int(11)")]
        public int IdShippingCompany { get; set; }
        [Required]
        [Column("shippingCompanyName")]
        [StringLength(50)]
        public string ShippingCompanyName { get; set; }

        [InverseProperty(nameof(Shipping.IdShippingCompanyNavigation))]
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
