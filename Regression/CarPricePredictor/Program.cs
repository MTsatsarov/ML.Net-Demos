using CarPricePredictor.Services;
using CarPricePredictor.Services.Interfaces;
using Microsoft.Extensions.ML;

namespace CarPricePredictor
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddTransient<ICarService, CarService>();

			builder.Services.AddPredictionEnginePool<CarPrediction.ModelInput, CarPrediction.ModelOutput>()
				.FromFile(filePath: "C:\\Users\\MihailTsatsarov\\Documents\\MyPracticeRepos\\Demos\\CarPricePredictor\\Services\\ML\\CarPrediction.zip", watchForChanges: true);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}