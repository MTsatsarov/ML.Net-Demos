using CommentaryVotesPredictor.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CommentaryVotesPredictor.ViewModels
{
	public partial class MainPageViewModel : ObservableObject
	{
		private readonly ICommentaryService service;

		public MainPageViewModel(ICommentaryService service)
		{
			this.service = service;
		}

		[ObservableProperty]
		private bool  positive;

		[RelayCommand]
		public async Task GetPredictionResult(string text)
		{
			var result = this.service.Predict(text);

			this.Positive = result.Prediction;
		}
	}
}
