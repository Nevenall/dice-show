using Microsoft.AspNetCore.Mvc;


namespace DiceShow.App.Controllers
{
	 public class LogController : Controller
	 {


		  [Route("log")]
		  public IActionResult RedirectToHome()
		  {


				return Redirect("");
		  }


		  [Route("log/{name}")]
		  public IActionResult ShowDiceLog(string name)
		  {

				ViewBag.LogName = name;

				return View("Log");
		  }

		  [Route("log/{name}/{roll}")]
		  public IActionResult ShowDiceRoll(string name, int roll)
		  {

				ViewBag.LogName = name;
				ViewBag.Roll = roll;
				return View("Log");

		  }


	 }
}