

namespace Rinku.DAO
{
    using Microsoft.EntityFrameworkCore;
    using Rinku.Entities;
    using Rinku.Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class CatRolesDb
    {
        private readonly RinkuContext _db;

        public CatRolesDb(RinkuContext db)
        {
            _db = db;
        }


        public async  Task<CatRoles> RolesCUD(int opc, CatRoles rol)
        {
            try
            {
                var response = _db.CatRoles.FromSqlInterpolated($"exec sp_CatRoles_CRUD @opc= {opc}, @Id = {rol.RoleId}, @Role={rol.Role}, @Deactivated = {rol.Deactivated}").AsAsyncEnumerable();
                await foreach(var role in response)
                {
                    return role;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo llevar la operacion CUD de roles: " + ex.Message);
            }
        }

        public async Task<IEnumerable<CatRoles>> GetRoles(int opc, CatRoles rol)
        {
            try
            {
                return await _db.CatRoles.FromSqlInterpolated($"exec sp_CatRoles_CRUD @opc= {opc}, @Id = {rol.RoleId}, @Role={rol.Role}, @Deactivated = {rol.Deactivated}").ToListAsync();
                
               
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo procesar la consulta de roles " + ex.Message);
            }
        }

        public async Task<CatRoles> GetRole(int opc, CatRoles rol)
        {
            try
            {
                var response=  _db.CatRoles.FromSqlInterpolated($"exec sp_CatRoles_CRUD @opc= {opc}, @Id = {rol.RoleId}, @Role={rol.Role}, @Deactivated = {rol.Deactivated}").AsAsyncEnumerable();
                await foreach (var item in response)
                {
                    return item;
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo encontrar el rol: "+ ex.Message);
            }
        }


    }
}
