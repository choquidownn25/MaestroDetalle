using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Prueba.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Brands.RoleName)]
    public class BrandsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
