using Microsoft.AspNetCore.Mvc;

namespace DiceShow.App.Controllers
{

    public class HomeController : Controller
    {

        [Route("")]
        public  ActionResult Index()
        {
            return View("Index");
        }

        [Route("Error")]
        public ActionResult Error()
        {
            return View("Error");
        }

    }

}