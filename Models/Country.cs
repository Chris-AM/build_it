using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("country")]
    public partial class Country
    {
        public Country()
        {
            Products = new HashSet<Product>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("idCountry", TypeName = "int(11)")]
        public int IdCountry { get; set; }
        [Required]
        [Column("isoCountry")]
        [StringLength(3)]
        public string IsoCountry { get; set; }
        [Required]
        [Column("countryName")]
        [StringLength(20)]
        public string CountryName { get; set; }

        [InverseProperty(nameof(Product.IdCountryNavigation))]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty(nameof(User.IdCountryNavigation))]
        public virtual ICollection<User> Users { get; set; }
    }
}
