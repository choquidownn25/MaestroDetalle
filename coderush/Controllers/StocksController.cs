using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Prueba.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Stocks.RoleName)]
    public class StocksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
