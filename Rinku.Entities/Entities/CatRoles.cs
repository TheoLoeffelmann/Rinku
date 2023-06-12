
namespace Rinku.Entities.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class CatRoles
    {
        [Key]
        public int RoleId { get; set; }
        public string Role { get; set; }
        public bool Deactivated { get; set; }
    }
}
