using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CapaConexion.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Prueba.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Orders.RoleName)]
    public class OrdersController : Controller
    {
        private productionContext production = new productionContext();
        public IActionResult Index()
        {
           
            Customers customers = production.Customers.Where(x => x.CustomerId.Equals(true)).FirstOrDefault();
            ViewData["CustomerId"] = new SelectList(production.Customers, "CustomerId", "FirstName", customers?.CustomerId);
            Stores stores = production.Stores.Where(x => x.StoreId.Equals(true)).FirstOrDefault();
            ViewData["StoreId"] = new SelectList(production.Stores, "StoreId", "StoreName", stores?.StoreId);
            Staffs staffs = production.Staffs.Where(x => x.StaffId.Equals(true)).FirstOrDefault();
            ViewData["StaffId"] = new SelectList(production.Staffs, "StaffId", "FirstName", staffs?.StaffId);
            return View();
         
        }
    }
}
