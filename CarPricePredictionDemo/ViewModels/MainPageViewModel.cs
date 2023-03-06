using CarPricePredictionDemo.Models;
using CarPricePredictionDemo.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarPricePredictionDemo.ViewModels
{
	public partial class MainPageViewModel : ObservableObject
	{
		[ObservableProperty]
		private CarShowModel model;

		private ICarService carService;
		public MainPageViewModel(ICarService carService)
		{
			this.carService = carService;
			this.Model = carService.GetCarsDropdownLists();
		}

	}
}
