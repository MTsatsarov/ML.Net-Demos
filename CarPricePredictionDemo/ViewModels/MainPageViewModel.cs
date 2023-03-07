using CarPricePredictionDemo.Models;
using CarPricePredictionDemo.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
			this.Model = this.carService.GetCarsDropdownLists();
			this.Model.Models = new List<string>();
		}

        public CarPredictionModel PredictionModel { get; set; }

		public void Picker_SelectedIndexChanged(object sender, EventArgs a)
		{
			var picker = (Picker)sender;
			int selectedIndex = picker.SelectedIndex;

			if (selectedIndex != -1)
			{
				var brand = this.Model.Brands[selectedIndex];

				this.Model.Models = this.Model.BrandModels[brand].ToList();
			}
		}

	}
}
