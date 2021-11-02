using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Prueba.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Staffs.RoleName)]
    public class StaffsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
