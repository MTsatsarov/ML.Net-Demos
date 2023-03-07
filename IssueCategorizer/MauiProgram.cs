using IssueCategorizer.Models;
using IssueCategorizer.Services;
using IssueCategorizer.Services.Interfaces;
using IssueCategorizer.ViewModels;
using Microsoft.Extensions.ML;
using System.Reflection;
namespace IssueCategorizer
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

			builder.Services.AddTransient<IIssueService,IssueService>();

			builder.Services.AddSingleton<MainPageViewModel>();
			builder.Services.AddSingleton<MainPage>();

			//Register prediction Engine
			var path = Assembly.GetExecutingAssembly().Location;
			var absolutePath = Path.Combine(path, "../../../../../../ML/model.zip");
			builder.Services.AddPredictionEnginePool<IssueInputModel, IssueOutputModel>()
			.FromFile(filePath: absolutePath, watchForChanges: true);

			return builder.Build();
		}
	}
}