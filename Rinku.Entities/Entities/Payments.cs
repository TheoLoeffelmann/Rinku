namespace Rinku.Entities.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Payments
    {

        [Key]
        public int PaymentId { get; set; }
        public int TotalHours { get; set; }
        public decimal TotalPaymetDelivers { get; set; }
        public decimal TotalPaymentBounus { get; set; }
        public decimal TotaltWithholdings { get; set; }
        public decimal TotalPaymentsGroceryVouchers { get; set; }
        public decimal TotalSalary { get; set; }
        public int DeliveryId { get; set; }
        public int EmployeeId { get; set; }
        public bool Deactivated { get; set; }   
    }
}
