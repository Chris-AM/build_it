using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("payMethod")]
    public partial class PayMethod
    {
        public PayMethod()
        {
            Purchases = new HashSet<Purchase>();
        }

        [Key]
        [Column("idPayMethod", TypeName = "int(11)")]
        public int IdPayMethod { get; set; }
        [Column("payMethod", TypeName = "enum('debito','credito','webPay','payPal','khipu','onePay')")]
        public string PayMethod1 { get; set; }

        [InverseProperty(nameof(Purchase.IdPayMethodNavigation))]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
