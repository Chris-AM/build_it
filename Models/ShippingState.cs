using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("shippingState")]
    public partial class ShippingState
    {
        public ShippingState()
        {
            Shippings = new HashSet<Shipping>();
        }

        [Key]
        [Column("idShippingState", TypeName = "int(11)")]
        public int IdShippingState { get; set; }
        [Column("isShipping", TypeName = "tinyint(4)")]
        public sbyte IsShipping { get; set; }
        [Column("modificationDate", TypeName = "date")]
        public DateTime ModificationDate { get; set; }

        [InverseProperty(nameof(Shipping.IdShippingStateNavigation))]
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
