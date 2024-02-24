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
        [Route("GetId/{id}")]
        public IActionResult Buscar(int id)
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



    }


    

    
}
