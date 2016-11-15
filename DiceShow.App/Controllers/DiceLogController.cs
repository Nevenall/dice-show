using Microsoft.AspNetCore.Mvc;


namespace DiceShow.App.Controllers
{
	 public class DiceLogController : Controller
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