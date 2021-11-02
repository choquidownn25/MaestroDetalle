using Microsoft.EntityFrameworkCore;
using coderush.Data;
using coderush.Models;
using coderush.Services;
using coderush.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;
//using Conexion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
//using LogicaCapa.Repositorios;
using System;
using Prueba.Models;

namespace coderush.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/TipoDocumento")]
    public class TipoDocumentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoDocumentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Metodo Obtner todos los elementos
        /// </summary>
        /// <returns>Retorna clase</returns>
        [HttpGet]
        public async Task<IActionResult> GetTipoDocumento()
        {
            try
            {
                
                //Pasamos el listado de la conexión
                List<TipoDocumento> Items = await _context.TipoDocumento.ToListAsync();
                int Count = Items.Count();
                return Ok(new { Items, Count });
               
            }catch(Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }
            

        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<TipoDocumento> payload)
        {
            TipoDocumento TipoDocumento = payload.value;
            _context.TipoDocumento.Add(TipoDocumento);
            _context.SaveChanges();
            return Ok(TipoDocumento);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<TipoDocumento> payload)
        {
            TipoDocumento tipoDocumento = payload.value;
            _context.TipoDocumento.Update(tipoDocumento);
            _context.SaveChanges();
            return Ok(tipoDocumento);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<TipoDocumento> payload)
        {
            TipoDocumento tipoDocumento = _context.TipoDocumento
                .Where(x => x.Id == (int)payload.key)
                .FirstOrDefault();
            _context.TipoDocumento.Remove(tipoDocumento);
            _context.SaveChanges();
            return Ok(tipoDocumento);

        }
    }
}
