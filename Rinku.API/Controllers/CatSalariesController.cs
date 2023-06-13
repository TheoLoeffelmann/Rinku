using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rinku.Entities.Entities;
using Rinku.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rinku.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatSalariesController : ControllerBase
    {
        private readonly CatSalariesServ _serv;
        public CatSalariesController(CatSalariesServ serv)
        {
            _serv = serv;
        }

        [HttpGet("Salaries")]
        public async Task<ActionResult<List<CatSalaries>>> GetAll()
        {
            try
            {
                CatSalaries req = new CatSalaries();
                var response = await this._serv.GetCatSalariesAsync(4, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<CatSalaries>> Get([FromBody] CatSalaries req)
        {
            try
            {
                var response = await this._serv.CatSalaryAsync(4, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CatSalaries>> AddSalary([FromBody] CatSalaries req)
        {
            try
            {
                var response = await this._serv.CatSalaryAsync(1, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CatSalaries>> UpdSalary([FromBody] CatSalaries req)
        {
            try
            {
                var response = await this._serv.CatSalaryAsync(2, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<CatSalaries>> DelSalary([FromBody] CatSalaries req)
        {
            try
            {
                var response = await this._serv.CatSalaryAsync(3, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
