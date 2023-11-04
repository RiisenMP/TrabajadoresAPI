using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabajadoresAPI.Models;

namespace TrabajadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        public readonly TrabajadoresPruebaContext _dbcontext;

        public TrabajadorController(TrabajadoresPruebaContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("lista")]
        public IActionResult Lista()
        {
            List<Trabajador> lista = new List<Trabajador>();

            try
            {
                lista = _dbcontext.Trabajadores.Include(c => c.oDepartamento).ToList();
                lista = _dbcontext.Trabajadores.Include(c => c.oDistrito).ToList();
                lista = _dbcontext.Trabajadores.Include(c => c.oProvincia).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = lista });
            }
        }


        [HttpGet]
        [Route("obtener/{idTrabajador:int}")]
        public IActionResult Obtener(int idTrabajador)
        {
            Trabajador oTrabajador = _dbcontext.Trabajadores.Find(idTrabajador);

            if (oTrabajador == null)
            {
                return BadRequest("Trabajador no encontrado");
            }

            try
            {
                oTrabajador = _dbcontext.Trabajadores.Include(c => c.oDepartamento).Where(p => p.Id == idTrabajador).FirstOrDefault();
                oTrabajador = _dbcontext.Trabajadores.Include(c => c.oDistrito).Where(p => p.Id == idTrabajador).FirstOrDefault();
                oTrabajador = _dbcontext.Trabajadores.Include(c => c.oProvincia).Where(p => p.Id == idTrabajador).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = oTrabajador });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = oTrabajador });
            }
        }

        [HttpPost]
        [Route("guardar")]
        public IActionResult Guardar([FromBody] Trabajador objeto)
        {

            try
            {
                _dbcontext.Trabajadores.Add(objeto);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message + "ERROR EN EL TRY" });
            }
        }


        [HttpPut]
        [Route("editar")]
        public IActionResult Editar([FromBody] Trabajador objeto)
        {
            Trabajador oTrabajador = _dbcontext.Trabajadores.Find(objeto.Id);

            if (oTrabajador == null)
            {
                return BadRequest("Trabajador no encontrado");
            }

            try
            {
                oTrabajador.TipoDocumento = objeto.TipoDocumento is null ? oTrabajador.TipoDocumento : objeto.TipoDocumento;
                oTrabajador.NumeroDocumento = objeto.NumeroDocumento is null ? oTrabajador.NumeroDocumento : objeto.NumeroDocumento;
                oTrabajador.Nombres = objeto.Nombres is null ? oTrabajador.Nombres : objeto.Nombres;
                oTrabajador.IdDepartamento = objeto.IdDepartamento is null ? oTrabajador.IdDepartamento : objeto.IdDepartamento;
                oTrabajador.IdProvincia = objeto.IdProvincia is null ? oTrabajador.IdProvincia : objeto.IdProvincia;
                oTrabajador.IdDistrito = objeto.IdDistrito is null ? oTrabajador.IdDistrito : objeto.IdDistrito;

                _dbcontext.Trabajadores.Update(oTrabajador);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message + "ERROR EN EL TRY" });
            }
        }



        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public IActionResult Eliminar(int id)
        {
            Trabajador oTrabajador = _dbcontext.Trabajadores.Find(id);

            if (oTrabajador == null)
            {
                return BadRequest("Trabajador no encontrado");
            }

            try
            {
                _dbcontext.Trabajadores.Remove(oTrabajador);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message + "ERROR EN EL TRY" });
            }
        }

    }
}
