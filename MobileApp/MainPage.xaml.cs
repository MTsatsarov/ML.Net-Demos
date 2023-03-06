using MobileApp.ViewModels;

namespace MobileApp
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