using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using MobileApp.Services;
using MobileApp.Services.Interfaces;
using MobileApp.ViewModels;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MobileApp
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

			builder.Services.AddTransient<ICommentaryService, CommentaryService>();

			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<MainPageViewModel>();

			builder.Services.AddPredictionEnginePool<ModelBuilder.ModelInput, ModelBuilder.ModelOutput>()
			.FromFile(filePath: "C:\\Users\\MihailTsatsarov\\Documents\\MyPracticeRepos\\ML.Net-Demos\\MobileApp\\ML\\ModelBuilder.zip", watchForChanges: true);

			return builder.Build();
		}
	}
}