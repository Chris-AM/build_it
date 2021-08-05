using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("publicationHistory")]
    public partial class PublicationHistory
    {
        public PublicationHistory()
        {
            Publications = new HashSet<Publication>();
        }

        [Key]
        [Column("idPublicationHistory", TypeName = "int(11)")]
        public int IdPublicationHistory { get; set; }
        [Column("publicationPerUser", TypeName = "int(11)")]
        public int PublicationPerUser { get; set; }

        [InverseProperty(nameof(Publication.IdPublicationHistoryNavigation))]
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
