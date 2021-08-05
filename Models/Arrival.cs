using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("arrival")]
    [Index(nameof(IdShipping), Name = "fk_arrival_shipping")]
    public partial class Arrival
    {
        [Key]
        [Column("idArrival", TypeName = "int(11)")]
        public int IdArrival { get; set; }
        [Column("estimateArrivalDate", TypeName = "date")]
        public DateTime EstimateArrivalDate { get; set; }
        [Column("realArrivalDate", TypeName = "date")]
        public DateTime RealArrivalDate { get; set; }
        [Column("idShipping", TypeName = "int(11)")]
        public int IdShipping { get; set; }

        [ForeignKey(nameof(IdShipping))]
        [InverseProperty(nameof(Shipping.Arrivals))]
        public virtual Shipping IdShippingNavigation { get; set; }
    }
}
