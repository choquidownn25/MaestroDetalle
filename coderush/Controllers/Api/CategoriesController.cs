using CapaConexion.Models;
using CapaRepository.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Data;
using Prueba.Models.SyncfusionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private productionContext production;
        private CategoriesRepository categoriesRepository;

        public CategoriesController(ApplicationDbContext context)
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
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                categoriesRepository = new CategoriesRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Categories> Items = categoriesRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });

            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }


        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Categories> payload)
        {
            categoriesRepository = new CategoriesRepository();
            Categories categories = payload.value;
            var dato = categoriesRepository.Add(categories);
            if (dato != null)
                return Ok(categories);
            else
                return BadRequest("Error : " + categories.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Categories> payload)
        {
            categoriesRepository = new CategoriesRepository();
            Categories categories = payload.value;
            var dato = categoriesRepository.Modify(categories);
            _context.SaveChanges();
            if (dato != null)
                return Ok(categories);
            else
                return BadRequest("Error : " + categories.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Categories> payload)
        {
            categoriesRepository = new CategoriesRepository();
            Categories categories = payload.value;
            var dato = categoriesRepository.Delete(categories.CategoryId);
            if (dato != null)
                return Ok(categories);
            else
                return BadRequest("Error : " + categories.ToString());

        }
    }
}
