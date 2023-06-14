
namespace Rinku.DAO
{
    using Microsoft.EntityFrameworkCore;
    using Rinku.Entities;
    using Rinku.Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Rinku.Entities;
    using Rinku.Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class CatSalariesDb
    {
        private readonly RinkuContext _db;
        public CatSalariesDb(RinkuContext db)
        {
            _db = db;
        }

        public async Task<CatSalaries> SalaryCUD(int opc, CatSalaries sal)
        {
            try
            {
                var response = _db.CatSalaries.FromSqlInterpolated($"exec sp_CatSalaries_CRUD @opc= {opc}, @Id = {sal.IdSalary},  @Bonus = {sal.Bonus}, @Deactivated = {sal.Deactivated},  @RoleId={sal.IdRole}").AsAsyncEnumerable();
                await foreach (var salary in response)
                {
                    return salary;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo llevar la operacion CUD de Salarios: " + ex.Message);
            }
        }

        public async Task<IEnumerable<CatSalaries>> GetSalaries(int opc, CatSalaries sal)
        {
            try
            {
                return await _db.CatSalaries.FromSqlInterpolated($"exec sp_CatSalaries_CRUD @opc= {opc}, @Id = {sal.IdSalary},  @Bonus = {sal.Bonus}, @Deactivated = {sal.Deactivated},  @RoleId={sal.IdRole}").ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo procesar la consulta de Salarios " + ex.Message);
            }
        }

        public async Task<CatSalaries> GetSalary(int opc, CatSalaries sal)
        {
            try
            {
                var response = _db.CatSalaries.FromSqlInterpolated($"sp_CatSalaries_CRUD @opc = {opc}, @Id = {sal.IdSalary},  @Bonus = {sal.Bonus}, @Deactivated = {sal.Deactivated},  @RoleId ={sal.IdRole}").AsAsyncEnumerable();
                await foreach (var item in response)
                {
                    return item;
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo encontrar el salario: " + ex.Message);
            }
        }


    }
}
