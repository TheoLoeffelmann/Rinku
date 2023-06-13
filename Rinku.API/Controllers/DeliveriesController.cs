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
    public class DeliveriesController : ControllerBase
    {
        private readonly DeliveriesServ _serv;
        public DeliveriesController(DeliveriesServ serv)
        {
            _serv = serv;   
        }

        [HttpGet]
        public async Task<ActionResult<Deliveries>> Get([FromBody] Deliveries req)
        {
            try
            {
                var response = await this._serv.DeliveriesAsync(4, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Deliveries")]
        public async Task<ActionResult<List<Deliveries>>> GetAll([FromBody] Deliveries req)
        {
            try
            {
                var response =await this._serv.GetDeliveriesAsync(4, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Deliveries>> AddDelivery([FromBody] Deliveries req)
        {
            try
            {
                var response = await this._serv.DeliveriesCUDAsync(1, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Deliveries>> UpdDelivery([FromBody] Deliveries req)
        {
            try
            {
                var response = await this._serv.DeliveriesCUDAsync(2, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Deliveries>> DelDelivery([FromBody] Deliveries req)
        {
            try
            {
                var response = await this._serv.DeliveriesCUDAsync(3, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
