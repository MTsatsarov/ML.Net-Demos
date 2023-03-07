using Microsoft.ML;
using MovieRecommendationModelCreator.Models;
using System.Reflection;
using Microsoft.ML.Trainers;

namespace MovieRecommendationModelCreator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var assemblyPath = Assembly.GetExecutingAssembly().Location;
			var trainingDataPath = Path.Combine(assemblyPath, "../../../../trainingData.csv");
			var testDataPath = Path.Combine(assemblyPath, "../../../../testData.csv");
			var saveModelPath = Path.Combine(assemblyPath, "../../../../model.zip");

			//Create MlContext
			var mlContext = new MLContext();

			//Load Data
			var trainingData = mlContext.Data.LoadFromTextFile<InputModel>(trainingDataPath, separatorChar: ',');
			var testData = mlContext.Data.LoadFromTextFile<InputModel>(testDataPath, separatorChar: ',');

			//Prepare Data
			var transformer = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "UserIdEncoded", inputColumnName: "UserId")
				.Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "MovieIdEncoded", inputColumnName: "MovieId"));

			//Add model
			var opt = new MatrixFactorizationTrainer.Options
			{
				MatrixColumnIndexColumnName = "UserIdEncoded",
				MatrixRowIndexColumnName = "MovieIdEncoded",
				LabelColumnName = "Label",
				NumberOfIterations = 20,
				ApproximationRank = 100
			};

			var model = transformer.Append(mlContext.Recommendation().Trainers.MatrixFactorization(opt));

			//Train model
			var trainedModel = model.Fit(trainingData);

			//Evaluate model
			var evaluate = trainedModel.Transform(testData);

			var metrics = mlContext.Regression.Evaluate(evaluate, labelColumnName: "Label", scoreColumnName: "Score");
			Console.WriteLine("Root Mean Squared Error : " + metrics.RootMeanSquaredError.ToString());
			Console.WriteLine("RSquared: " + metrics.RSquared.ToString());

			var predictionEngine = mlContext.Model.CreatePredictionEngine<InputModel, OutputModel>(trainedModel);

			var testInput = new InputModel { UserId = 6, MovieId = 10 };
			var movieRatingPrediction = predictionEngine.Predict(testInput);

			if (Math.Round(movieRatingPrediction.Score, 1) > 3.5)
			{
				Console.WriteLine("Movie " + testInput.MovieId + " is recommended for user " + testInput.UserId);
			}
			else
			{
				Console.WriteLine("Movie " + testInput.MovieId + " is not recommended for user " + testInput.UserId);
			}

			//Save model

			mlContext.Model.Save(trainedModel, testData.Schema, saveModelPath);
		}
	}
}