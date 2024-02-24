using Microsoft.AspNetCore.Mvc;
using L01_2021_MS_651_2021_HL_650.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace L01_2021_MS_651_2021_HL_650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class pedidosController : ControllerBase
    {

        private readonly pruebaContext _pruebaContext;

        public pedidosController(pruebaContext pruebaContext)
        {

            _pruebaContext = pruebaContext;

        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {

            List<Pedidos> listaPedidos = (from s in _pruebaContext.pedidos
                                          select s).ToList();

            if (listaPedidos.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listaPedidos);

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

        [HttpGet]
        [Route("GetMotorista/{id}")]
        public IActionResult BuscarMotorista(int id)
        {

            Pedidos? listaPedidos = (from p in _pruebaContext.pedidos
                                     where p.motoristaId == id
                                     select p).FirstOrDefault();

            if (listaPedidos == null)
            {
                return NotFound();
            }

            return Ok(listaPedidos);

        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Guardar([FromBody] Pedidos listaPedidos)
        {

            try
            {

                _pruebaContext.pedidos.Add(listaPedidos);
                _pruebaContext.SaveChanges();
                return Ok(listaPedidos);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Update(int id, [FromBody] Pedidos listaPedidosNueva)
        {

            Pedidos? listaPedidosActu = (from p in _pruebaContext.pedidos 
                                         where p.pedidoId == id
                                     select p).FirstOrDefault();
            if (listaPedidosActu == null)
            {

                return NotFound();

            }

            listaPedidosActu.motoristaId = listaPedidosNueva.motoristaId;
            listaPedidosActu.clienteId = listaPedidosNueva.clienteId;
            listaPedidosActu.platoId = listaPedidosNueva.platoId;
            listaPedidosActu.cantidad = listaPedidosNueva.cantidad;
            listaPedidosActu.precio = listaPedidosNueva.precio;

            _pruebaContext.Entry(listaPedidosActu).State = EntityState.Modified;
            _pruebaContext.SaveChanges();

            return Ok(listaPedidosNueva);


        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {

            Pedidos? listaPedidos = (from p in _pruebaContext.pedidos
                                     where p.pedidoId == id
                                     select p).FirstOrDefault();
            if (listaPedidos == null)
            {

                return NotFound();

            }

            _pruebaContext.pedidos.Attach(listaPedidos);
            _pruebaContext.pedidos.Remove(listaPedidos);
            _pruebaContext.SaveChanges();

            return Ok(listaPedidos);


        }


    }


    

    
}
