using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileApp.Services.Interfaces;

namespace MobileApp.ViewModels
{
	public partial class MainPageViewModel : ObservableObject
	{
		private readonly ICommentaryService commentaryService;

		public MainPageViewModel(ICommentaryService commentaryService)
		{
			this.commentaryService = commentaryService;
		}

		[ObservableProperty]
		private string text;

		[ObservableProperty]
		private string result;

		[RelayCommand]
		public void PredictScore()
		{
			var result = this.commentaryService.Predict(this.Text);
			var predictedLabel =(int)(result.PredictedLabel);
			var sentiment = result.PredictedLabel == 1 ? "sentiment" : "not sentiment";
			var score = result.Score[predictedLabel].ToString("F2");

			this.Result = $"Your commentary has {score} % to be {sentiment} !";
		}
	}
}
