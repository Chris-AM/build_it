using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("publicationState")]
    public partial class PublicationState
    {
        public PublicationState()
        {
            Publications = new HashSet<Publication>();
        }

        [Key]
        [Column("idPublicationState", TypeName = "int(11)")]
        public int IdPublicationState { get; set; }
        [Required]
        [Column("publicationState")]
        [StringLength(50)]
        public string PublicationState1 { get; set; }
        [Column("modificationDate", TypeName = "date")]
        public DateTime ModificationDate { get; set; }

        [InverseProperty(nameof(Publication.IdPublicationStateNavigation))]
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
