using apiPagos.Context;
using apiPagos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiPagos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly AppDbContext context;

        public PagosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<PagosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.pago.ToList());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<PagosController>/5
        [HttpGet("{id}", Name="GetPagos")]
        public ActionResult Get(int id)
        {
            try
            {
                var pagos = context.pago.FirstOrDefault(f => f.id == id);
                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // POST api/<PagosController>
        [HttpPost]
        public ActionResult Post([FromBody]Pagos pagos)
        {
            try
            {
                context.pago.Add(pagos);
                context.SaveChanges();
                return CreatedAtRoute("GetPagos", new { id = pagos.id }, pagos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PagosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pagos pagos)
        {
            try
            {
                if (pagos.id == id)
                {
                    context.Entry(pagos).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPagos", new { id = pagos.id }, pagos);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PagosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var pagos = context.pago.FirstOrDefault(f => f.id == id);
                if (pagos != null)
                {
                    context.pago.Remove(pagos);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
