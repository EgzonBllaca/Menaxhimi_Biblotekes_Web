using Microsoft.AspNetCore.Mvc;

namespace Menaxhimi_Biblotekes_Web.Controllers
{
    public class MesazhetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
