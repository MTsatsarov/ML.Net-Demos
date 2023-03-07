using CarPricePredictionDemo.ViewModels;

namespace CarPricePredictionDemo
{
	public partial class MainPage : ContentPage
	{
		private readonly MainPageViewModel viewModel;

		public MainPage(MainPageViewModel viewModel)
		{
			InitializeComponent();
			this.BindingContext = viewModel;
			this.viewModel = viewModel;
		}

		private void Picker_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.viewModel.Picker_SelectedIndexChanged(sender, e);
		}
	}
}