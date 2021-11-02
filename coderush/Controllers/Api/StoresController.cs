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
    [Route("api/Stores")]
    public class StoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private productionContext production;
        private StoresRepository StoresRepository;

        public StoresController(ApplicationDbContext context)
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
        public async Task<IActionResult> GetStores()
        {
            try
            {
                StoresRepository = new StoresRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Stores> Items = StoresRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });

            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }


        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Stores> payload)
        {
            StoresRepository = new StoresRepository();
            Stores Stores = payload.value;
            var dato = StoresRepository.Add(Stores);
            if (dato != null)
                return Ok(Stores);
            else
                return BadRequest("Error : " + Stores.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Stores> payload)
        {
            StoresRepository = new StoresRepository();
            Stores products = payload.value;
            var dato = StoresRepository.Modify(products);
            _context.SaveChanges();
            if (dato != null)
                return Ok(products);
            else
                return BadRequest("Error : " + products.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Stores> payload)
        {
            StoresRepository = new StoresRepository();
            Stores Stores = payload.value;
            var dato = StoresRepository.Delete(Stores.StoreId);
            if (dato != null)
                return Ok(Stores);
            else
                return BadRequest("Error : " + Stores.ToString());

        }
    }
}
