using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThirdPartyAPI.Models;

namespace ThirdPartyAPI.Controllers
{
	public class HomeController : Controller
	{
		private readonly IHolidayAPIService _holidayAPIService;

		public HomeController(IHolidayAPIService holidayAPIService)
		{
			_holidayAPIService = holidayAPIService;
		}

		public async Task<IActionResult> Index(string countryCode,int year)
		{
            _ = new List<HolidayModel>();
            List<HolidayModel> holidays = await _holidayAPIService.GetHolidays(countryCode, year);
            return View(holidays);

		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}