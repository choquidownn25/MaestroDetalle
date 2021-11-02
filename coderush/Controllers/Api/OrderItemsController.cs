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
    [Route("api/OrderItems")]
    public class OrderItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private productionContext production;
        private OrderItemsRepository OrderItemsRepository;

        public OrderItemsController(ApplicationDbContext context)
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
        public async Task<IActionResult> GetOrderItems()
        {
            try
            {
                OrderItemsRepository = new OrderItemsRepository();
                //Pasamos el listado de la conexión
                IEnumerable<OrderItems> Items = OrderItemsRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });

            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }


        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<OrderItems> payload)
        {
            OrderItemsRepository = new OrderItemsRepository();
            OrderItems OrderItems = payload.value;
            var dato = OrderItemsRepository.Add(OrderItems);
            if (dato != null)
                return Ok(OrderItems);
            else
                return BadRequest("Error : " + OrderItems.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<OrderItems> payload)
        {
            OrderItemsRepository = new OrderItemsRepository();
            OrderItems OrderItems = payload.value;
            var dato = OrderItemsRepository.Modify(OrderItems);
            if (dato != null)
                return Ok(OrderItems);
            else
                return BadRequest("Error : " + OrderItems.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<OrderItems> payload)
        {
            OrderItemsRepository = new OrderItemsRepository();
            OrderItems OrderItems = payload.value;
            var dato = OrderItemsRepository.Delete(OrderItems.ItemId);
            if (dato != null)
                return Ok(OrderItems);
            else
                return BadRequest("Error : " + OrderItems.ToString());

        }
    }
}
