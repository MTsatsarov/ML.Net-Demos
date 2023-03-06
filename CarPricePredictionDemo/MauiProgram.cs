using CarPricePredictionDemo.Services;
using CarPricePredictionDemo.Services.Interfaces;
using CarPricePredictionDemo.ViewModels;

namespace CarPricePredictionDemo
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

			builder.Services.AddTransient<ICarService,CarService>();
			builder.Services.AddSingleton<MainPageViewModel>();
			builder.Services.AddSingleton<MainPage>();
			return builder.Build();
		}
	}
}