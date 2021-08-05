using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace build_it.Models
{
    [Table("userState")]
    public partial class UserState
    {
        public UserState()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Column("idUserState", TypeName = "int(11)")]
        public int IdUserState { get; set; }
        [Required]
        [Column("userState")]
        [StringLength(50)]
        public string UserState1 { get; set; }
        [Column("modificationDate", TypeName = "date")]
        public DateTime ModificationDate { get; set; }

        [InverseProperty(nameof(User.IdUserStateNavigation))]
        public virtual ICollection<User> Users { get; set; }
    }
}
