using Microsoft.AspNetCore.Mvc;

namespace CasaDeShow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(){
            return View();
        }
    }
}