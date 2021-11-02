using coderush.Data;
using coderush.Models;
using coderush.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coderush.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Personas")]
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PersonasController(ApplicationDbContext context)
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
        public async Task<IActionResult> GetPersonas()
        {
            try
            {

                //Pasamos el listado de la conexión
                List<Personas> Items = await _context.Personas.ToListAsync();
                int Count = Items.Count();
                return Ok(new { Items, Count });

            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }


        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Personas> payload)
        {
            Personas personas = payload.value;
            _context.Personas.Add(personas);
            _context.SaveChanges();
            return Ok(personas);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Personas> payload)
        {
            Personas personas = payload.value;
            _context.Personas.Update(personas);
            _context.SaveChanges();
            return Ok(personas);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Personas> payload)
        {
            Personas personas = _context.Personas
                .Where(x => x.Id == (int)payload.key)
                .FirstOrDefault();
            _context.Personas.Remove(personas);
            _context.SaveChanges();
            return Ok(personas);

        }
    }
}
