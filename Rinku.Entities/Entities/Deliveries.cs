
namespace Rinku.Entities.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Deliveries
    {

        [Key]
        public int DeliveryId { get; set; }
        public int Delivery { get; set; }
        public DateTime SatartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }
        public int EmployeeId { get; set; }
        public bool Deactivated { get; set; }
    }
}
