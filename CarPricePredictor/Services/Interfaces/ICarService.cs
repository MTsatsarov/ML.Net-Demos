using CarPricePredictor.Models;

namespace CarPricePredictor.Services.Interfaces
{
	public interface ICarService
	{
		float CalculatePrice(CarPredictionModel model);
	}
}
