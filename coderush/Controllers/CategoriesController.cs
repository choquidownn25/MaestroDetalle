using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Categories.RoleName)]
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
