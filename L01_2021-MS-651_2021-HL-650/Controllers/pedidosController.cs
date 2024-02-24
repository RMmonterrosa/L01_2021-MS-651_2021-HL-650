using Microsoft.AspNetCore.Mvc;
using L01_2021_MS_651_2021_HL_650.Models;
using Microsoft.EntityFrameworkCore;

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
            
            List<Pedidos> listadeprueba = (from d in _pruebaContext.Datos
                                          select d).ToList();

            if(listadeprueba.Count() == 0) 
            {
                return NotFound();
            }

            return Ok(listadeprueba);
        
        }

        [HttpGet]
        [Route("GetId/{id}")]
        public IActionResult Buscar(string id)
        {

            Datos? listadeprueba = (from d in _pruebaContext.Datos
                                         where d.id_hola == id
                                         select d).FirstOrDefault();

            if (listadeprueba == null)
            {
                return NotFound();
            }

            return Ok(listadeprueba);

        }

    }


    

    
}
