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
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private productionContext production;
        private CustomersRepository customersRepository;

        public CustomersController(ApplicationDbContext context)
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
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                customersRepository = new CustomersRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Customers> Items = customersRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });

            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }


        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Customers> payload)
        {
            customersRepository = new CustomersRepository();
            Customers Customers = payload.value;
            var dato = customersRepository.Add(Customers);
            if (dato != null)
                return Ok(Customers);
            else
                return BadRequest("Error : " + Customers.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Customers> payload)
        {
            customersRepository = new CustomersRepository();
            Customers customers = payload.value;
            var dato = customersRepository.Modify(customers);
            _context.SaveChanges();
            if (dato != null)
                return Ok(customers);
            else
                return BadRequest("Error : " + customers.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Customers> payload)
        {
            customersRepository = new CustomersRepository();
            Customers customers = payload.value;
            var dato = customersRepository.Delete(customers.CustomerId);
            if (dato != null)
                return Ok(customers);
            else
                return BadRequest("Error : " + customers.ToString());

        }
    }
}
