using apiFactura.Models;
using apiPagos.Context;
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
    public class FacturaController : ControllerBase
    {
        private readonly AppDbContext context;

        public FacturaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<PagosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.factura.ToList());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<PagosController>/5
        [HttpGet("{id}", Name="GetFactura")]
        public ActionResult Get(int id)
        {
            try
            {
                var pagos = context.factura.FirstOrDefault(f => f.id == id);
                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // POST api/<PagosController>
        [HttpPost]
        public ActionResult Post([FromBody]Factura factura)
        {
            try
            {
                context.factura.Add(factura);
                context.SaveChanges();
                return CreatedAtRoute("GetFactura", new { id = factura.id }, factura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PagosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Factura factura)
        {
            try
            {
                if (factura.id == id)
                {
                    context.Entry(factura).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetFactura", new { id = factura.id }, factura);
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
                var factura = context.factura.FirstOrDefault(f => f.id == id);
                if (factura != null)
                {
                    context.factura.Remove(factura);
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
