using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("company")]
    public partial class Company
    {
        public Company()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("idCompany", TypeName = "int(11)")]
        public int IdCompany { get; set; }
        [Required]
        [Column("companyRole")]
        [StringLength(20)]
        public string CompanyRole { get; set; }
        [Required]
        [Column("companyName")]
        [StringLength(255)]
        public string CompanyName { get; set; }

        [InverseProperty(nameof(Product.IdCompanyNavigation))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
