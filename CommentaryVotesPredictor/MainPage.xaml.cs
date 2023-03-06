using CommentaryVotesPredictor.ViewModels;

namespace CommentaryVotesPredictor
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainPageViewModel model)
		{
			InitializeComponent();
			this.BindingContext = model;
		}
	}
}