using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("product")]
    [Index(nameof(IdCompany), Name = "fk_product_company")]
    [Index(nameof(IdCountry), Name = "fk_product_country")]
    [Index(nameof(IdOffer), Name = "fk_product_offer")]
    [Index(nameof(IdProductHistory), Name = "fk_product_productHistory")]
    [Index(nameof(IdProductSatate), Name = "fk_product_productState")]
    [Index(nameof(IdWorld), Name = "fk_product_world")]
    public partial class Product
    {
        public Product()
        {
            Publications = new HashSet<Publication>();
        }

        [Key]
        [Column("idProduct", TypeName = "int(11)")]
        public int IdProduct { get; set; }
        [Required]
        [Column("productName")]
        [StringLength(250)]
        public string ProductName { get; set; }
        [Column("price", TypeName = "int(11)")]
        public int Price { get; set; }
        [Required]
        [Column("productPhoto")]
        [StringLength(250)]
        public string ProductPhoto { get; set; }
        [Column("productTax")]
        public double ProductTax { get; set; }
        [Required]
        [Column("productDescription")]
        public string ProductDescription { get; set; }
        [Column("productCommision")]
        public double ProductCommision { get; set; }
        [Column("stock", TypeName = "int(11)")]
        public int Stock { get; set; }
        [Column("idWorld", TypeName = "int(11)")]
        public int IdWorld { get; set; }
        [Column("idProductHistory", TypeName = "int(11)")]
        public int IdProductHistory { get; set; }
        [Column("idProductSatate", TypeName = "int(11)")]
        public int IdProductSatate { get; set; }
        [Column("idOffer", TypeName = "int(11)")]
        public int IdOffer { get; set; }
        [Column("idCompany", TypeName = "int(11)")]
        public int IdCompany { get; set; }
        [Column("idCountry", TypeName = "int(11)")]
        public int IdCountry { get; set; }

        [ForeignKey(nameof(IdCompany))]
        [InverseProperty(nameof(Company.Products))]
        public virtual Company IdCompanyNavigation { get; set; }
        [ForeignKey(nameof(IdCountry))]
        [InverseProperty(nameof(Country.Products))]
        public virtual Country IdCountryNavigation { get; set; }
        [ForeignKey(nameof(IdOffer))]
        [InverseProperty(nameof(Offer.Products))]
        public virtual Offer IdOfferNavigation { get; set; }
        [ForeignKey(nameof(IdProductHistory))]
        [InverseProperty(nameof(ProductHistory.Products))]
        public virtual ProductHistory IdProductHistoryNavigation { get; set; }
        [ForeignKey(nameof(IdProductSatate))]
        [InverseProperty(nameof(ProductState.Products))]
        public virtual ProductState IdProductSatateNavigation { get; set; }
        [ForeignKey(nameof(IdWorld))]
        [InverseProperty(nameof(World.Products))]
        public virtual World IdWorldNavigation { get; set; }
        [InverseProperty(nameof(Publication.IdProductNavigation))]
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
