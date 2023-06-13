namespace Rinku.DAO
{
    using Microsoft.EntityFrameworkCore;
    using Rinku.Entities;
    using Rinku.Entities.Entities;
    using System.Collections.Generic;

    using System.Threading.Tasks;

    using System;

    public class DeliveriesDb
    {
        private readonly RinkuContext _db;

        public DeliveriesDb(RinkuContext db)
        {
            _db = db;
        }

        public async Task<Deliveries> DeliveryCUD(int opc, Deliveries del)
        {
            try
            {
                var response = _db.Deliveries.FromSqlInterpolated($"exec sp_Deliveries_CRUD @opc= {opc}, @Id = {del.DeliveryId},  @Delivery = {del.Delivery}, @StartPeriod={del.SatartPeriod}, @EndPeriod = {del.EndPeriod} @Deactivated = {del.Deactivated},  @EmployeeId={del.EmployeeId}").AsAsyncEnumerable();
                await foreach (var salary in response)
                {
                    return salary;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo llevar la operacion CUD de Entrega: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Deliveries>> GetDeliveries(int opc, Deliveries del)
        {
            try
            {
                return await _db.Deliveries.FromSqlInterpolated($"exec sp_Deliveries_CRUD @opc= {opc}, @Id = {del.DeliveryId},  @Delivery = {del.Delivery}, @StartPeriod={del.SatartPeriod}, @EndPeriod = {del.EndPeriod} @Deactivated = {del.Deactivated},  @EmployeeId={del.EmployeeId}").ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo procesar la consulta de Entregas " + ex.Message);
            }
        }

        public async Task<Deliveries> GetDelivery(int opc, Deliveries del)
        {
            try
            {
                var response = _db.Deliveries.FromSqlInterpolated($"exec sp_Deliveries_CRUD @opc= {opc}, @Id = {del.DeliveryId},  @Delivery = {del.Delivery}, @StartPeriod={del.SatartPeriod}, @EndPeriod = {del.EndPeriod} @Deactivated = {del.Deactivated},  @EmployeeId={del.EmployeeId}").AsAsyncEnumerable();
                await foreach (var item in response)
                {
                    return item;
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo encontrar la entrega: " + ex.Message);
            }
        }





    }
}
