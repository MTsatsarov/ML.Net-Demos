using CarPricePredictionDemo.ViewModels;

namespace CarPricePredictionDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainPageViewModel viewModel)
		{
			InitializeComponent();
			this.BindingContext = viewModel;
		}
	}
}