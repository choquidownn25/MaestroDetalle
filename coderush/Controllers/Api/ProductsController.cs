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
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private productionContext production;
        private ProductsRepository productsRepository = new ProductsRepository();
        public ProductsController(ApplicationDbContext context)
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
        public async Task<IActionResult> GetProducts()
        {
            try
            {

                //Pasamos el listado de la conexión
                IEnumerable<Products> Items = productsRepository.GetAll();
                int Count =  Items.Count();
                return Ok(new { Items, Count });

            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }


        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Products> payload)
        {
            Products products = payload.value;
            var  dato = productsRepository.Add(products);
            if( dato != null)
            return Ok(products);
            else
                return BadRequest("Error : " + products.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Products> payload)
        {

            Products products = payload.value;
            var dato = productsRepository.Modify(products);
            _context.SaveChanges();
            if (dato != null)
                return Ok(products);
            else
                return BadRequest("Error : " + products.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Products> payload)
        {
            Products products = payload.value;
            var dato = productsRepository.Delete(products.ProductId);
            if (dato != null)
                return Ok(products);
            else
                return BadRequest("Error : " + products.ToString());

        }
    }
}
