using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("clientState")]
    public partial class ClientState
    {
        public ClientState()
        {
            Clients = new HashSet<Client>();
        }

        [Key]
        [Column("idClientState", TypeName = "int(11)")]
        public int IdClientState { get; set; }
        [Required]
        [Column("clientState")]
        [StringLength(50)]
        public string ClientState1 { get; set; }
        [Column("modificationDate", TypeName = "date")]
        public DateTime ModificationDate { get; set; }

        [InverseProperty(nameof(Client.IdClientStateNavigation))]
        public virtual ICollection<Client> Clients { get; set; }
    }
}
