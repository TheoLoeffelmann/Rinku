

namespace Rinku.Services
{
    using Rinku.DAO;
    using Rinku.Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class EmployeesServ
    {
        private readonly EmployeesDb _db;

        public EmployeesServ(EmployeesDb db)
        {
            _db = db;
        }

        public async Task<Employees> EmployeeCUDAsync(int opc, Employees emp)
        {
            try
            {
                var response = await _db.EmployeesCUD(opc, emp);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Employees>> GetEmployeesAsync(int opc, Employees emp)
        {
            try
            {
                var response = await _db.GetEmployees(opc, emp);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Employees> EmployeeAsync(int opc, Employees emp)
        {
            try
            {
                var response = await _db.GetEmployee(opc, emp);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
