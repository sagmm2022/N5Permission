using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace N5PermissionUser.Domain.Entities
{
    [Table("TypeEntity", Schema = "dbo")]
    public partial class TypeEntity : BaseEntity
    {
        [Required]
        [Column("Description")]
        [StringLength(150)]
        public string Description { get; set; }
    }
}
