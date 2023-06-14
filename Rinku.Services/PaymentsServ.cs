namespace Rinku.Services
{
    using Microsoft.Extensions.Configuration;
    using Rinku.DAO;
    using Rinku.Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class PaymentsServ
    {
        private readonly PaymentsDb _db;
        private readonly DeliveriesServ _deliveryServ;
        private readonly EmployeesServ _employeeServ;
        private IConfiguration _configuration;
        public PaymentsServ(PaymentsDb db, IConfiguration configuration, DeliveriesServ deliveriesServ, EmployeesServ employeesServ)
        {
            this._db = db;
            this._configuration = configuration;
            this._deliveryServ = deliveriesServ;
            this._employeeServ = employeesServ;
        }

        public async Task<Payments> PaymentCUDAsync(int opc, Payments pay)
        {
            try
            {
                //obtenemos la configurfación de variables 
                decimal baseSalary = Decimal.Parse(_configuration.GetSection("GlobalVariables:baseSalary").Value);
                decimal payDelivery = Decimal.Parse(_configuration.GetSection("GlobalVariables:payDelivery").Value);
                decimal bonusDriver = Decimal.Parse(_configuration.GetSection("GlobalVariables:bonusDriver").Value);
                decimal bonusLoader = Decimal.Parse(_configuration.GetSection("GlobalVariables:bonusLoader").Value);
                decimal bonusAuxiliary = Decimal.Parse(_configuration.GetSection("GlobalVariables:bonusAuxiliary").Value);
                decimal baseWithholdings = Decimal.Parse(_configuration.GetSection("GlobalVariables:baseWithholdings").Value);
                decimal aditionalWithholdings = Decimal.Parse(_configuration.GetSection("GlobalVariables:aditionalWithholdings").Value);
                decimal baseMaxMonthlySalary = Decimal.Parse(_configuration.GetSection("GlobalVariables:baseMaxMonthlySalary").Value);
                decimal groceryVouchers = Decimal.Parse(_configuration.GetSection("GlobalVariables:groceryVouchers").Value);


                Deliveries reqDel = new Deliveries()
                {
                    DeliveryId = pay.DeliveryId,
                    SatartPeriod=DateTime.Now,
                    EndPeriod=DateTime.Now
                };

                Employees reqEmp = new Employees()
                {
                    EmployeeId = pay.EmployeeId,
                    Employee = ""
                };
                //obtenemos las entregas
                Deliveries deliver = this._deliveryServ.DeliveriesAsync(4, reqDel).Result;
                //obtenemos el empleado para definir el role
                Employees employee = this._employeeServ.EmployeeAsync(4, reqEmp).Result;

                //generamos los cálculos 
                pay.TotalHours = 8 * 6 * 4;
                decimal basePay = decimal.Round((baseSalary * pay.TotalHours), 2);
                pay.TotalPaymetDelivers = decimal.Round((payDelivery * deliver.Delivery), 2);
                pay.TotalPaymentBounus = employee.RoleId == 1 ? bonusDriver * (decimal)pay.TotalHours
                    : employee.RoleId == 2 ? (bonusLoader * (decimal)pay.TotalHours)
                    : bonusAuxiliary * (decimal)pay.TotalHours;
                pay.TotalPaymentBounus = decimal.Round(pay.TotalPaymentBounus, 2);
                pay.TotalPaymentsGroceryVouchers = decimal.Round((basePay * groceryVouchers), 2);
                pay.TotalSalary = decimal.Round((baseSalary + pay.TotalPaymentsGroceryVouchers + pay.TotalPaymetDelivers + pay.TotalPaymentBounus), 2);
                pay.QuantityWithHoldings = pay.TotalSalary > baseMaxMonthlySalary ? baseWithholdings + aditionalWithholdings : baseWithholdings;
                pay.QuantityWithHoldings = decimal.Round(pay.QuantityWithHoldings, 2);
                pay.TotaltWithholdings = decimal.Round((pay.TotalSalary * (pay.QuantityWithHoldings / 100)), 2);
                pay.TotalPayment = decimal.Round((pay.TotalSalary - pay.TotaltWithholdings), 2);
                pay.Deactivated = false;
                var response = await _db.PaymentsCUD(opc, pay);                
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar llamar el servicio de pago: "+ ex.Message);
            }
        }

        public async Task<IEnumerable<Payments>> GetPaymentsAsync(int opc, Payments pay)
        {
            try
            {
                var response = await _db.GetPayments(opc, pay);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Payments> PaymentAsync(int opc, Payments pay)
        {
            try
            {
                var response = await _db.GetPayment(opc, pay);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
