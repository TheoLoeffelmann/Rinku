namespace Rinku.DAO
{
    using Microsoft.EntityFrameworkCore;
    using Rinku.Entities;
    using Rinku.Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public class PaymentsDb
    {
        private readonly RinkuContext _db;

        public PaymentsDb(RinkuContext db)
        {
            this._db= db;
        }

        public async Task<Payments> PaymentsCUD(int opc, Payments payment)
        {
            try
            {
                var response = _db.Payments.FromSqlInterpolated($"exec sp_Payments_CRUD @opc={opc}, @Id={payment.PaymentId}, @TotalHours={payment.TotalHours}, @TotalPaymentDelivers= {payment.TotalPaymetDelivers}, @TotalPaymentBounus = {payment.TotalPaymentBounus}, @TotalWithholdings= {payment.TotaltWithholdings}, @TotalPaymentGroceryVouchers={payment.TotalPaymentsGroceryVouchers}, @TotalSalary={payment.TotalSalary}, @Deactivated= {payment.Deactivated}, @DeliveryId = {payment.DeliveryId}, @EmployeeId = {payment.EmployeeId} ").AsAsyncEnumerable();
                await foreach( var item in response)
                {
                    return item;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo generar el proceso CUD para Pagos, error: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Payments>> GetPayments(int opc, Payments payment)
        {
            try
            {
                var response = _db.Payments.FromSqlInterpolated($"exec sp_Payments_CRUD @opc={opc}, @Id={payment.PaymentId}, @TotalHours={payment.TotalHours}, @TotalPaymentDelivers= {payment.TotalPaymetDelivers}, @TotalPaymentBounus = {payment.TotalPaymentBounus}, @TotalWithholdings= {payment.TotaltWithholdings}, @TotalPaymentGroceryVouchers={payment.TotalPaymentsGroceryVouchers}, @TotalSalary={payment.TotalSalary}, @Deactivated= {payment.Deactivated}, @DeliveryId = {payment.DeliveryId}, @EmployeeId = {payment.EmployeeId} ").AsAsyncEnumerable();
                List<Payments> list= new List<Payments>();
                await foreach (var item in response)
                {
                    Payments pay = new Payments();
                     pay= item;
                    list.Add(pay);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error al intentar buscar los pagos " + ex.Message);
            }
        }

        public async Task<Payments> GetPayment(int opc, Payments payment)
        {
            try
            {
                var response = _db.Payments.FromSqlInterpolated($"exec sp_Payments_CRUD @opc={opc}, @Id={payment.PaymentId}, @TotalHours={payment.TotalHours}, @TotalPaymentDelivers= {payment.TotalPaymetDelivers}, @TotalPaymentBounus = {payment.TotalPaymentBounus}, @TotalWithholdings= {payment.TotaltWithholdings}, @TotalPaymentGroceryVouchers={payment.TotalPaymentsGroceryVouchers}, @TotalSalary={payment.TotalSalary}, @Deactivated= {payment.Deactivated}, @DeliveryId = {payment.DeliveryId}, @EmployeeId = {payment.EmployeeId} ").AsAsyncEnumerable();
                
                await foreach (var item in response)
                {
                    return item;
                    
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error al intentar buscar los pagos " + ex.Message);
            }
        }


    }
}
