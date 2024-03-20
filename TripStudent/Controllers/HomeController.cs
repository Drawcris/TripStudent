using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TripStudent.Models;
using TripStudent.ViewModel;

namespace TripStudent.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		

        private IEnumerable<TripDetailViewModel> _trip = new List<TripDetailViewModel>
		{

			new TripDetailViewModel
			{
				ID = 1,
				Destination = "Kraków",
				Price = 500,
				Start_date = DateTime.Parse("2024/03/20"),
				End_date = DateTime.Parse("2024/04/01")
			},

			new TripDetailViewModel
			{
				ID = 2,
				Destination = "Francja",
				Price = 1500,
				Start_date = DateTime.Parse("2024/05/1"),
				End_date = DateTime.Parse("2024/05/14")
			},

			new TripDetailViewModel
			{
				ID = 3,
				Destination = "Wiedeñ",
				Price = 600,
				Start_date = DateTime.Parse("2024/06/01"),
				End_date = DateTime.Parse("2024/6/14")
			},

		};



		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View(_trip);
		}
        public IActionResult Detail(int id)
        {
            var trip = _trip
                .FirstOrDefault(x => x.ID == id);
            return View(trip);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
