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
        [Route("GetId/{id}")]
        public IActionResult Buscar(int id)
        {

            clientes? listaClientes = (from p in _pruebaContext.clientes
                                     where p.clienteId == id
                                     select p).FirstOrDefault();

            if (listaClientes == null)
            {
                return NotFound();
            }

            return Ok(listaClientes);

        }
    }
}
