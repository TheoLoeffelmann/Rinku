namespace Rinku.Services
{
    using Rinku.DAO;
    using Rinku.Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public  class CatRolesServ
    {
        private readonly CatRolesDb _db;
        public CatRolesServ(CatRolesDb db)
        {
            this._db = db;
        }

        public async Task<CatRoles> CatRolesCUDAsync(int opc, CatRoles rol)
        {
            try
            {
                var response = await _db.RolesCUD(opc, rol);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CatRoles>> GetCatRolesAsync(int opc, CatRoles rol)
        {
            try
            {
                var response = await _db.GetRoles(opc, rol);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CatRoles> CatRolesAsync(int opc, CatRoles rol)
        {
            try
            {
                var response = await _db.GetRole(opc, rol);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
