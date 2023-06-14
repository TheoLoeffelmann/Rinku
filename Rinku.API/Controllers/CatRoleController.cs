using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rinku.Entities.Entities;
using Rinku.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rinku.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatRoleController : ControllerBase
    {
        private readonly CatRolesServ _serv;
        public CatRoleController(CatRolesServ serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<ActionResult<CatRoles>> Get(int id)
        {
            try
            {
                CatRoles req=new CatRoles() { RoleId= id };
                var response = await this._serv.CatRolesAsync(4, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Roles")]
        public async Task<ActionResult<List<CatRoles>>> GetAll()
        {
            try
            {
                CatRoles role = new CatRoles()
                {
                    RoleId = 0,
                    Deactivated = false,
                    Role = ""
                };
                var response = await this._serv.GetCatRolesAsync(4, role);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CatRoles>> AddRole([FromBody] CatRoles req)
        {
            try
            {
                var response = await this._serv.CatRolesCUDAsync(1, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CatRoles>> UpdRole([FromBody] CatRoles req)
        {
            try
            {
                var response = await this._serv.CatRolesCUDAsync(2, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<CatRoles>> DelRole([FromBody] CatRoles req)
        {
            try
            {
                var response = await this._serv.CatRolesCUDAsync(3, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }





}
