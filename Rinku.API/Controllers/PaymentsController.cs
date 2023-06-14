using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
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
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentsServ _serv;

        public PaymentsController(PaymentsServ serv)
        {
            this._serv = serv;
        }

        [HttpGet]
        public async Task<ActionResult<Payments>> Get(int id)
        {
            try
            {
                Payments req = new Payments()
                {
                    DeliveryId = id
                };
                var response = await this._serv.PaymentAsync(4, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("payments")]
        public async Task<ActionResult<List<Payments>>> GetAll()
        {
            try
            {
                Payments req = new Payments();
                var response = await this._serv.GetPaymentsAsync(4, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Payments>> AddPayment([FromBody] Payments req)
        {
            try
            {
                var response = await this._serv.PaymentCUDAsync(1, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Payments>> UpdPayment([FromBody] Payments req)
        {
            try
            {
                var response = await this._serv.PaymentCUDAsync(2, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Payments>> DelPayment([FromBody] Payments req)
        {
            try
            {
                var response = await this._serv.PaymentCUDAsync(3, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }





    }
}
