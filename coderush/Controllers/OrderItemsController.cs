using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [Authorize(Roles = Pages.MainMenu.OrderItems.RoleName)]
    public class OrderItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
