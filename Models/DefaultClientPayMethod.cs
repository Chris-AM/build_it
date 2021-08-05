using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("defaultClientPayMethod")]
    public partial class DefaultClientPayMethod
    {
        public DefaultClientPayMethod()
        {
            Clients = new HashSet<Client>();
        }

        [Key]
        [Column("idDefaultClientPayMethod", TypeName = "int(11)")]
        public int IdDefaultClientPayMethod { get; set; }

        [InverseProperty(nameof(Client.IdDefaultClientPayMethodNavigation))]
        public virtual ICollection<Client> Clients { get; set; }
    }
}
