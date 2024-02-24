using Microsoft.AspNetCore.Mvc;
using L01_2021_MS_651_2021_HL_650.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace L01_2021_MS_651_2021_HL_650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class platosController : ControllerBase
    {

        private readonly pruebaContext _pruebaContext;

        public platosController(pruebaContext pruebaContext)
        {

            _pruebaContext = pruebaContext;

        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {

            List<platos> listaPlatos = (from pl in _pruebaContext.platos
                                          select pl).ToList();

            if (listaPlatos.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listaPlatos);

        }

        [HttpGet]
        [Route("GetPlato/{nombre}")]
        public IActionResult BuscarPlato(string nombre)
        {

            platos? listaPlatos = (from pl in _pruebaContext.platos
                                     where pl.nombrePlato == nombre
                                     select pl).FirstOrDefault();

            if (listaPlatos == null)
            {
                return NotFound();
            }

            return Ok(listaPlatos);

        }


        [HttpPost]
        [Route("Post")]
        public IActionResult Guardar([FromBody] platos listaPlatos)
        {

            try
            {

                _pruebaContext.platos.Add(listaPlatos);
                _pruebaContext.SaveChanges();
                return Ok(listaPlatos);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Update(int id, [FromBody] platos listaPlatosNueva)
        {

            platos? listaPlatosActu = (from pl in _pruebaContext.platos
                                         where pl.platoId == id
                                         select pl).FirstOrDefault();
            if (listaPlatosActu == null)
            {

                return NotFound();

            }

            listaPlatosActu.nombrePlato = listaPlatosNueva.nombrePlato;
            listaPlatosActu.precio = listaPlatosNueva.precio;


            _pruebaContext.Entry(listaPlatosActu).State = EntityState.Modified;
            _pruebaContext.SaveChanges();

            return Ok(listaPlatosNueva);


        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {

            platos? listaPlatos = (from pl in _pruebaContext.platos
                                     where pl.platoId == id
                                     select pl).FirstOrDefault();
            if (listaPlatos == null)
            {

                return NotFound();

            }

            _pruebaContext.platos.Attach(listaPlatos);
            _pruebaContext.platos.Remove(listaPlatos);
            _pruebaContext.SaveChanges();

            return Ok(listaPlatos);


        }


    }





}
