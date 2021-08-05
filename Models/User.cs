using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("user")]
    [Index(nameof(IdCountry), Name = "fk_user_country")]
    [Index(nameof(IdIsClient), Name = "fk_user_isClient")]
    [Index(nameof(IdUserState), Name = "fk_user_userState")]
    public partial class User
    {
        public User()
        {
            Publications = new HashSet<Publication>();
        }

        [Key]
        [Column("userID", TypeName = "int(11)")]
        public int UserId { get; set; }
        [Required]
        [Column("userName")]
        [StringLength(56)]
        public string UserName { get; set; }
        [Required]
        [Column("userLastName")]
        [StringLength(56)]
        public string UserLastName { get; set; }
        [Column("creationDate", TypeName = "date")]
        public DateTime CreationDate { get; set; }
        [Column("idUserState", TypeName = "int(11)")]
        public int IdUserState { get; set; }
        [Column("idIsClient", TypeName = "int(11)")]
        public int IdIsClient { get; set; }
        [Column("idCountry", TypeName = "int(11)")]
        public int IdCountry { get; set; }

        [ForeignKey(nameof(IdCountry))]
        [InverseProperty(nameof(Country.Users))]
        public virtual Country IdCountryNavigation { get; set; }
        [ForeignKey(nameof(IdIsClient))]
        [InverseProperty(nameof(IsClient.Users))]
        public virtual IsClient IdIsClientNavigation { get; set; }
        [ForeignKey(nameof(IdUserState))]
        [InverseProperty(nameof(UserState.Users))]
        public virtual UserState IdUserStateNavigation { get; set; }
        [InverseProperty(nameof(Publication.User))]
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
