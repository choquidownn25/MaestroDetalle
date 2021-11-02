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
    [Route("api/Staffs")]
    public class StaffsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private productionContext production;
        private StaffsRepository StaffsRepository;

        public StaffsController(ApplicationDbContext context)
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
        public async Task<IActionResult> GetStaffs()
        {
            try
            {
                StaffsRepository = new StaffsRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Staffs> Items = StaffsRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });

            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }


        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Staffs> payload)
        {
            payload.value.ManagerId = 1;
            payload.value.Active = 1;
            StaffsRepository = new StaffsRepository();
            Staffs staffs = payload.value;
            
            var dato = StaffsRepository.Add(staffs);
            if (dato != null)
                return Ok(staffs);
            else
                return BadRequest("Error : " + staffs.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Staffs> payload)
        {
            StaffsRepository = new StaffsRepository();
            payload.value.Active = 1;
            payload.value.ManagerId = 1;
            Staffs Staffs = payload.value;
            var dato = StaffsRepository.Modify(Staffs);
            if (dato != null)
                return Ok(Staffs);
            else
                return BadRequest("Error : " + Staffs.ToString());
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Staffs> payload)
        {
            StaffsRepository = new StaffsRepository();
            Staffs Staffs = payload.value;
            var dato = StaffsRepository.Delete(Staffs.StaffId);
            if (dato != null)
                return Ok(Staffs);
            else
                return BadRequest("Error : " + Staffs.ToString());

        }
    }
}
