using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("isClient")]
    [Index(nameof(IdClient), Name = "fk_isClient_client")]
    public partial class IsClient
    {
        public IsClient()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Column("idIsClient", TypeName = "int(11)")]
        public int IdIsClient { get; set; }
        [Column("userIsClient", TypeName = "tinyint(4)")]
        public sbyte UserIsClient { get; set; }
        [Column("modificationDate", TypeName = "date")]
        public DateTime ModificationDate { get; set; }
        [Column("idClient", TypeName = "int(11)")]
        public int IdClient { get; set; }

        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.IsClients))]
        public virtual Client IdClientNavigation { get; set; }
        [InverseProperty(nameof(User.IdIsClientNavigation))]
        public virtual ICollection<User> Users { get; set; }
    }
}
