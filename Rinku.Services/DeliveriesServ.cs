namespace Rinku.Services
{
    using Rinku.DAO;
    using Rinku.Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DeliveriesServ
    {
        private readonly DeliveriesDb _db;

        public DeliveriesServ(DeliveriesDb db)
        {
            _db = db;
        }

        public async Task<Deliveries> DeliveriesCUDAsyng(int opc, Deliveries del)
        {
            try
            {
                var response = await _db.DeliveryCUD(opc, del);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Deliveries>> GetDeliveriesAsync(int opc, Deliveries del)
        {
            try
            {
                var response = await _db.GetDeliveries(opc, del);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Deliveries> DeliveriesAsync(int opc, Deliveries del)
        {
            try
            {
                var response = await _db.GetDelivery(opc, del);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
