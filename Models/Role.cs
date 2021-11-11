using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alere.Models
{
    [Table("Tbl_Role")]
    public class Role
    {
        [Column("Id")]
        public long RoleId { get; set; }

        public RoleDescription Description { get; set; }
    }

    public enum RoleDescription
    {
        [Display(Name = "Doador")] DONOR,
        [Display(Name = "Receptor")] RECEIVER
    }
}