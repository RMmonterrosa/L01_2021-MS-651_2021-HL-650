using L01_2021_MS_651_2021_HL_650.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L01_2021_MS_651_2021_HL_650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientesController : ControllerBase
    {
        private readonly pruebaContext _pruebaContext;

        public clientesController(pruebaContext pruebaContext)
        {

            _pruebaContext = pruebaContext;

        }


        [HttpGet]
        [Route("GetCliente/{id}")]
        public IActionResult BuscarCliente(int id)
        {

            Pedidos? listaPedidos = (from p in _pruebaContext.pedidos
                                     where p.clienteId == id
                                     select p).FirstOrDefault();

            if (listaPedidos == null)
            {
                return NotFound();
            }

            return Ok(listaPedidos);

        }


        [HttpPost]
        [Route("Post")]
        public IActionResult Guardar([FromBody] clientes listaClientes)
        {

            try
            {

                _pruebaContext.clientes.Add(listaClientes);
                _pruebaContext.SaveChanges();
                return Ok(listaClientes);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Update(int id, [FromBody] clientes listaClientesNueva)
        {

            clientes? listaClientesActu = (from c in _pruebaContext.clientes
                                         where c.clienteId == id
                                         select c).FirstOrDefault();
            if (listaClientesActu == null)
            {

                return NotFound();

            }

            listaClientesActu.clienteId = listaClientesNueva.clienteId;
            listaClientesActu.nombreCliente = listaClientesNueva.nombreCliente;


            _pruebaContext.Entry(listaClientesActu).State = EntityState.Modified;
            _pruebaContext.SaveChanges();

            return Ok(listaClientesNueva);


        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {

            clientes? listaClientes = (from c in _pruebaContext.clientes
                                     where c.clienteId == id
                                     select c).FirstOrDefault();
            if (listaClientes == null)
            {

                return NotFound();

            }

            _pruebaContext.clientes.Attach(listaClientes);
            _pruebaContext.clientes.Remove(listaClientes);
            _pruebaContext.SaveChanges();

            return Ok(listaClientes);

        }
    }
}
