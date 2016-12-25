using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DiceShow.App.Controllers
{

	using DiceShow.Model;

	public class DiceLogController : Controller
	{

		private IRepository _repo;

		public DiceLogController(IRepository repo)
		{
			_repo = repo;
		}

		/// <summary>
		/// A log request with no name will redirect to home. We don't just list all logs
		/// </summary>
		/// <returns></returns>
		[Route("log")]
		public async Task<IActionResult> RedirectToHome()
		{
			return await Task.FromResult(RedirectToActionPermanent("Index", "Home"));
		}

		/// Fetch the named log, if possible or return 404
		[Route("log/{name}")]
		public async Task<IActionResult> ShowDiceLog(string name)
		{
			var log = await _repo.GetAysnc(name);
			if (log == null)
			{
				return NotFound();
			}
			return View("DiceLog", log);
		}


	[Route("log/{name}/{roll}")]
	public async Task<IActionResult> ShowDiceRoll(string name, int roll)
	{
		var log = await _repo.GetAysnc(name);
        var record = await _repo.GetAysnc(name, roll);

		if (log == null)
		{
			return NotFound();
		}
		/// directing to a new view, not sure if that's the thing that we want right now. 
        /// rolls are displayed as a separate thing. we can navigate back to the log from their
        return View("DiceRoll", new { Log = log, RollId = roll });

	}


}
}