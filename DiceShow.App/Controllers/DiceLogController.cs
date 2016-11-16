using Microsoft.AspNetCore.Mvc;


namespace DiceShow.App.Controllers
{


    using DiceShow.Model;

    public class DiceLogController : Controller
    {

        IRepository _repo;
        public DiceLogController(IRepository repo)
        {
            _repo = repo;
        }

        [Route("log")]
        public IActionResult RedirectToHome()
        {


            return Redirect("");
        }


        [Route("log/{name}")]
        public IActionResult ShowDiceLog(string name)
        {

            ViewBag.LogName = name;

            return View("DiceLog");
        }

        [Route("log/{name}/{roll}")]
        public IActionResult ShowDiceRoll(string name, int roll)
        {

            ViewBag.LogName = name;
            ViewBag.Roll = roll;
            return View("DiceLog");

        }


    }
}