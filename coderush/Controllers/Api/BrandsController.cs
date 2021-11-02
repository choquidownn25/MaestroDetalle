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
    [Route("api/Brands")]
    public class BrandsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private productionContext production;
        private BrandsRepository brandsRepository;

        public BrandsController(ApplicationDbContext context)
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
        public async Task<IActionResult> GetBrands()
        {
            try
            {
                brandsRepository = new BrandsRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Brands> Items = brandsRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });

            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }


        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Brands> payload)
        {
            brandsRepository = new BrandsRepository();
            Brands brands = payload.value;
            var dato = brandsRepository.Add(brands);
            if (dato != null)
                return Ok(brands);
            else
                return BadRequest("Error : " + brands.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Brands> payload)
        {
            brandsRepository = new BrandsRepository();
            Brands products = payload.value;
            var dato = brandsRepository.Modify(products);
            _context.SaveChanges();
            if (dato != null)
                return Ok(products);
            else
                return BadRequest("Error : " + products.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Brands> payload)
        {
            brandsRepository = new BrandsRepository();
            Brands brands = payload.value;
            var dato = brandsRepository.Delete(brands.BrandId);
            if (dato != null)
                return Ok(brands);
            else
                return BadRequest("Error : " + brands.ToString());

        }
    }
}
