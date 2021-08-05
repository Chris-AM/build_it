using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("shippingCountry")]
    public partial class ShippingCountry
    {
        public ShippingCountry()
        {
            Shippings = new HashSet<Shipping>();
        }

        [Key]
        [Column("idShippingCountry", TypeName = "int(11)")]
        public int IdShippingCountry { get; set; }
        [Required]
        [Column("isoCountryImport")]
        [StringLength(3)]
        public string IsoCountryImport { get; set; }
        [Required]
        [Column("isoCountryExport")]
        [StringLength(3)]
        public string IsoCountryExport { get; set; }

        [InverseProperty(nameof(Shipping.IdShippingCountryNavigation))]
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
