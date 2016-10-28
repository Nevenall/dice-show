


using Microsoft.AspNetCore.Mvc;

namespace DiceShow.App.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

    }
 
}