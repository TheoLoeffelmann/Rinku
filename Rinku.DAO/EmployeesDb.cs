using Microsoft.EntityFrameworkCore;
using Rinku.Entities;
using Rinku.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rinku.DAO
{
    public  class EmployeesDb
    {
        private readonly RinkuContext _db;

        public EmployeesDb(RinkuContext db )
        {
            this._db = db;
        }

        public async Task<Employees> EmployeesCUD(int opc, Employees emp)
        {
            try
            {
                var response = _db.Employees.FromSqlInterpolated($"exec sp_Employees_CRUD @opc= {opc}, @Id = {emp.EmployeeId}, @Employee={emp.Employee}, @Deactivated = {emp.Deactivated},  @RoleId={emp.RoleId}").AsAsyncEnumerable();
                await foreach (var employee in response)
                {
                    return employee;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo llevar la operacion CUD de Empleados: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Employees>> GetEmployees(int opc, Employees emp)
        {
            try
            {
                return await _db.Employees.FromSqlInterpolated($"exec sp_Employees_CRUD @opc= {opc}, @Id = {emp.EmployeeId}, @Employee={emp.Employee}, @Deactivated = {emp.Deactivated},  @RoleId={emp.RoleId}").ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo procesar la consulta de Empleados " + ex.Message);
            }
        }

        public async Task<Employees> GetEmployee(int opc, Employees emp)
        {
            try
            {
                var response = _db.Employees.FromSqlInterpolated($"exec sp_Employees_CRUD @opc= {opc}, @Id = {emp.EmployeeId}, @Employee={emp.Employee}, @Deactivated = {emp.Deactivated},  @RoleId={emp.RoleId}").AsAsyncEnumerable();
                await foreach (var item in response)
                {
                    return item;
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo encontrar el rol: " + ex.Message);
            }
        }
    }
}
