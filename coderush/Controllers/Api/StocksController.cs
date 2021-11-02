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
    [Route("api/Stocks")]
    public class StocksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private productionContext production;
        private StocksRepository StocksRepository;

        public StocksController(ApplicationDbContext context)
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
        public async Task<IActionResult> GetStocks()
        {
            try
            {
                StocksRepository = new StocksRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Stocks> Items = StocksRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });

            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }


        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Stocks> payload)
        {
            StocksRepository = new StocksRepository();
            Stocks Stocks = payload.value;
            var dato = StocksRepository.Add(Stocks);
            if (dato != null)
                return Ok(Stocks);
            else
                return BadRequest("Error : " + Stocks.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Stocks> payload)
        {
            StocksRepository = new StocksRepository();
            Stocks stocks = payload.value;
            var dato = StocksRepository.Modify(stocks);
            _context.SaveChanges();
            if (dato != null)
                return Ok(stocks);
            else
                return BadRequest("Error : " + stocks.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Stocks> payload)
        {
            StocksRepository = new StocksRepository();
            Stocks Stocks = payload.value;
            var dato = StocksRepository.Delete(Stocks.ProductId);
            if (dato != null)
                return Ok(Stocks);
            else
                return BadRequest("Error : " + Stocks.ToString());

        }
    }
}
