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
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesServ _serv;
        public EmployeesController(EmployeesServ serv)
        {
            this._serv = serv;
        }

        [HttpGet("Employees")]
        public async Task<ActionResult<IEnumerable<Employees>>> GetAll()
        {
            try
            {
                Employees req = new Employees()
                {
                    EmployeeId = 0,
                    Employee = ""
                };
                var response = await this._serv.GetEmployeesAsync(4, req);
                return Ok(response);
            }
            catch (Exception ex )
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> Get([FromBody] Employees req)
        {
            try
            {
                var response = await this._serv.EmployeeAsync(4, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employees>> AddEmployee([FromBody] Employees req)
        {
            try
            {
                var response = await this._serv.EmployeeCUDAsync(1, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Employees>> UpdEmployee([FromBody] Employees req)
        {
            try
            {
                var response = await this._serv.EmployeeCUDAsync(2, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Employees>> DelEmployee([FromBody] Employees req)
        {
            try
            {
                var response = await this._serv.EmployeeCUDAsync(3, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
