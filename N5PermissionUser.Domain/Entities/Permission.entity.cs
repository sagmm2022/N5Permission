using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N5PermissionUser.Domain.Entities
{
    [Table("Permissions", Schema = "dbo")]
    public partial class PermissionsEntity : BaseEntity
    {
        [Required]
        [Column("FirstName")]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        [StringLength(150)]
        public string LastName { get; set; }

        [Required]
        [Column("DateOfPermission", TypeName = "datetime")]
        public DateTime DateOfPermission { get; set; }

        [Required]
        [Column("TypeId")]
        public long TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual TypeEntity Type { get; set; }
    }
}
