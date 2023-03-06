using CommentaryVotes.Models;
using CommentaryVotesPredictor.Services;
using CommentaryVotesPredictor.Services.Interfaces;
using CommentaryVotesPredictor.ViewModels;
using Microsoft.Extensions.ML;

namespace CommentaryVotesPredictor
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

			//Services
			builder.Services.AddTransient<ICommentaryService,CommentaryService>();

			//viewModels
			builder.Services.AddSingleton<MainPageViewModel>();

			//Pages
			builder.Services.AddSingleton<MainPage>();

			//ML
			var path = "..\\CommentaryAggresion\\model.zip";
			builder.Services.AddPredictionEnginePool<ModelInput,OutputModel>().FromFile(path,true);

			return builder.Build();
		}
	}
}