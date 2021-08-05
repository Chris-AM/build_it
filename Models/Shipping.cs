using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("shipping")]
    [Index(nameof(Idpurchase), Name = "fk_shipping_purchase")]
    [Index(nameof(IdShippingCompany), Name = "fk_shipping_shippingCompany")]
    [Index(nameof(IdShippingCountry), Name = "fk_shipping_shippingCountry")]
    [Index(nameof(IdShippingState), Name = "fk_shipping_shippingState")]
    public partial class Shipping
    {
        public Shipping()
        {
            Arrivals = new HashSet<Arrival>();
        }

        [Key]
        [Column("idShipping", TypeName = "int(11)")]
        public int IdShipping { get; set; }
        [Column("shippingDate", TypeName = "date")]
        public DateTime ShippingDate { get; set; }
        [Column("idpurchase", TypeName = "int(11)")]
        public int Idpurchase { get; set; }
        [Column("idShippingCountry", TypeName = "int(11)")]
        public int IdShippingCountry { get; set; }
        [Column("idShippingState", TypeName = "int(11)")]
        public int IdShippingState { get; set; }
        [Column("idShippingCompany", TypeName = "int(11)")]
        public int IdShippingCompany { get; set; }

        [ForeignKey(nameof(IdShippingCompany))]
        [InverseProperty(nameof(ShippingCompany.Shippings))]
        public virtual ShippingCompany IdShippingCompanyNavigation { get; set; }
        [ForeignKey(nameof(IdShippingCountry))]
        [InverseProperty(nameof(ShippingCountry.Shippings))]
        public virtual ShippingCountry IdShippingCountryNavigation { get; set; }
        [ForeignKey(nameof(IdShippingState))]
        [InverseProperty(nameof(ShippingState.Shippings))]
        public virtual ShippingState IdShippingStateNavigation { get; set; }
        [ForeignKey(nameof(Idpurchase))]
        [InverseProperty(nameof(Purchase.Shippings))]
        public virtual Purchase IdpurchaseNavigation { get; set; }
        [InverseProperty(nameof(Arrival.IdShippingNavigation))]
        public virtual ICollection<Arrival> Arrivals { get; set; }
    }
}
