namespace Rinku.Services
{
    using Rinku.DAO;
    using Rinku.Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public  class PaymentsServ
    {
        private readonly PaymentsDb _db;

        public PaymentsServ(PaymentsDb db)
        {
            this._db = db;
        }

        public async Task<Payments> PaymentCUDAsync(int opc, Payments pay)
        {
            try
            {
                var response = await _db.PaymentsCUD(opc, pay);
                return response;
            }
            catch (Exception ex)
            {

                throw;
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
