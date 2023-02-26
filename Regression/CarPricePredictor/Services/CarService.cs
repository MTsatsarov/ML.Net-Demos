using CarPricePredictor.Models;
using CarPricePredictor.Services.Interfaces;
using Microsoft.Extensions.ML;

namespace CarPricePredictor.Services
{
	public class CarService : ICarService
	{
		private PredictionEnginePool<CarPrediction.ModelInput, CarPrediction.ModelOutput> enginePool;

        public CarService(PredictionEnginePool<CarPrediction.ModelInput,
			CarPrediction.ModelOutput> enginePool)
        {
			this.enginePool = enginePool;
		}
        public float CalculatePrice(CarPredictionModel model)
		{
			var inputModel = new CarPrediction.ModelInput();
			inputModel.Brand = model.Brand;
			inputModel.Model = model.Model;
			inputModel.HorsePowers = model.HorsePowers;
			inputModel.Color = model.Color;
			inputModel.FuelType = model.FuelType;
			inputModel.Year = model.Year;
			inputModel.GearType = model.GearType;
			inputModel.FuelType = model.FuelType;

			var price = this.enginePool.Predict(inputModel).Score;

			return price;
		}
	}
}
