using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Prueba.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Customers.RoleName)]
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
