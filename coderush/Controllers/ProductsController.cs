using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Products.RoleName)]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
