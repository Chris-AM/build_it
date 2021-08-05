using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("client")]
    [Index(nameof(IdClientState), Name = "fk_client_clientState")]
    [Index(nameof(IdDefaultClientPayMethod), Name = "fk_client_metodoPagoclient")]
    public partial class Client
    {
        public Client()
        {
            IsClients = new HashSet<IsClient>();
        }

        [Key]
        [Column("idClient", TypeName = "int(11)")]
        public int IdClient { get; set; }
        [Required]
        [Column("firstName")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("secondName")]
        [StringLength(50)]
        public string SecondName { get; set; }
        [Required]
        [Column("lastName")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("secondLastName")]
        [StringLength(50)]
        public string SecondLastName { get; set; }
        [Required]
        [Column("personalAddres")]
        [StringLength(100)]
        public string PersonalAddres { get; set; }
        [Required]
        [Column("sendAddress1")]
        [StringLength(100)]
        public string SendAddress1 { get; set; }
        [Column("sendAddress2")]
        [StringLength(100)]
        public string SendAddress2 { get; set; }
        [Column("birthDate", TypeName = "date")]
        public DateTime BirthDate { get; set; }
        [Column("creationDate", TypeName = "date")]
        public DateTime CreationDate { get; set; }
        [Required]
        [Column("clientType")]
        [StringLength(50)]
        public string ClientType { get; set; }
        [Column("idDefaultClientPayMethod", TypeName = "int(11)")]
        public int IdDefaultClientPayMethod { get; set; }
        [Column("idClientState", TypeName = "int(11)")]
        public int IdClientState { get; set; }

        [ForeignKey(nameof(IdClientState))]
        [InverseProperty(nameof(ClientState.Clients))]
        public virtual ClientState IdClientStateNavigation { get; set; }
        [ForeignKey(nameof(IdDefaultClientPayMethod))]
        [InverseProperty(nameof(DefaultClientPayMethod.Clients))]
        public virtual DefaultClientPayMethod IdDefaultClientPayMethodNavigation { get; set; }
        [InverseProperty(nameof(IsClient.IdClientNavigation))]
        public virtual ICollection<IsClient> IsClients { get; set; }
    }
}
