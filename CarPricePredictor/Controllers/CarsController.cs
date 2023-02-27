using CarPricePredictor.Models;
using CarPricePredictor.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPricePredictor.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly ICarService carService;

		public CarsController(ICarService carService)
        {
			this.carService = carService;
		}

        [HttpPost]
		public IActionResult Post(CarPredictionModel model)
		{
			var price = carService.CalculatePrice(model);
			return this.Ok(price);
		}
	}
}
