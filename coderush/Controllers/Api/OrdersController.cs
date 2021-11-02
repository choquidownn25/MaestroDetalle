using CapaConexion.Models;
using CapaRepository.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private productionContext production;
        private OrdersRepository ordersRepository;

        public OrdersController(ApplicationDbContext context)
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
        public async Task<IActionResult> GetOrder()
        {
            try
            {
                ordersRepository = new OrdersRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Orders> Items = ordersRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });

            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }


        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Orders> payload)
        {
            ordersRepository = new OrdersRepository();
            Orders orders = payload.value;
            var dato = ordersRepository.Add(orders);
            if (dato != null)
                return Ok(orders);
            else
                return BadRequest("Error : " + orders.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Orders> payload)
        {
            ordersRepository = new OrdersRepository();
            Orders orders = payload.value;
            var dato = ordersRepository.Modify(orders);
            if (dato != null)
                return Ok(orders);
            else
                return BadRequest("Error : " + orders.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Orders> payload)
        {
            ordersRepository = new OrdersRepository();
            Orders orders = payload.value;
            var dato = ordersRepository.Delete(orders.OrderId);
            if (dato != null)
                return Ok(orders);
            else
                return BadRequest("Error : " + orders.ToString());

        }
    }
}
