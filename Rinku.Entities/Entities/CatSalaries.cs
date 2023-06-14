
namespace Rinku.Entities.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public  class CatSalaries
    {
        [Key]
        public int IdSalary { get; set; }
        public decimal Salary { get; set; }
        public decimal Bonus { get; set; }
        public int IdRole { get; set; }
        public bool Deactivated { get; set; }


    }
}
