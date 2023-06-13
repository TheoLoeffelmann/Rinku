namespace Rinku.Services
{
    using Rinku.DAO;
    using Rinku.Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public  class CatSalariesServ
    {
        private readonly CatSalariesDb _db;
        public CatSalariesServ(CatSalariesDb db)
        {
            this._db = db;
        }
        public async Task<CatSalaries> CatSalariesCUDAsync(int opc, CatSalaries sal)
        {
            try
            {
                var response = await _db.SalaryCUD(opc, sal);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CatSalaries>> GetCatSalariesAsync(int opc, CatSalaries sal)
        {
            try
            {
                var response = await _db.GetSalaries(opc, sal);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CatSalaries> CatSalaryAsync(int opc, CatSalaries sal)
        {
            try
            {
                var response = await _db.GetSalary(opc, sal);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
