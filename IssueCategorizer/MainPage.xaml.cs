using IssueCategorizer.ViewModels;

namespace IssueCategorizer
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