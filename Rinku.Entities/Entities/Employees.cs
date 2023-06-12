

namespace Rinku.Entities.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        public int RoleId { get; set; }
        public bool Deactivated { get; set; }
    }
}
