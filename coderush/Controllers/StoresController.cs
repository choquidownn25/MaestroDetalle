using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Stores.RoleName)]
    public class StoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
