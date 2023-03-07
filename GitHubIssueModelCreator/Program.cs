using GitHubIssueModelCreator.Models;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using System.Reflection;

namespace GitHubIssueModelCreator
{
	public class Program
	{
		static void Main(string[] args)
		{
			var path = Assembly.GetExecutingAssembly().Location;
			var trainingDataPath = Path.Combine(path, @"../../../../trainingData.txt");
			var testDataPath = Path.Combine(path, @"../../../../testData.txt");
			var modelPath = Path.Combine(path, @"../../../../model.zip");

			//Creating MlContext
			var mlContext = new MLContext();

			//LoadingData
			var trainingData = mlContext.Data.LoadFromTextFile<GitIssueInputModel>(trainingDataPath);

			//Prepare Data
			EstimatorChain<ColumnConcatenatingTransformer> transformer = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "Label", inputColumnName: "Area")
				.Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "Title", outputColumnName: "FeaturizedTitle"))
				.Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "Description", outputColumnName: "FeaturizedDescription"))
				.Append(mlContext.Transforms.Concatenate("Features", "FeaturizedTitle", "FeaturizedDescription"));
			//TODO append cache checkpoint

			//Append trainer
			var trainingPipeLine = transformer
				.Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
				.Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

			//TrainData
			TransformerChain<KeyToValueMappingTransformer> model = trainingPipeLine.Fit(trainingData);

			//Create prediction Engine
			var predictionEngine = mlContext.Model.CreatePredictionEngine<GitIssueInputModel, GitHubIssueOutputModel>(model);

			//Predict
			GitIssueInputModel issue = new GitIssueInputModel()
			{
				Title = "WebSockets communication is slow in my machine",
				Description = "The WebSockets communication used under the covers by SignalR looks like is going slow in my development machine.."
			};

			var prediction = predictionEngine.Predict(issue);

			Console.WriteLine(prediction.Area);

			//Evaluate
			var testData = mlContext.Data.LoadFromTextFile<GitIssueInputModel>(testDataPath);

			var testMetrics = mlContext.MulticlassClassification.Evaluate(model.Transform(testData));

			Console.WriteLine($"*************************************************************************************************************");
			Console.WriteLine($"*       Metrics for Multi-class Classification model - Test Data     ");
			Console.WriteLine($"*------------------------------------------------------------------------------------------------------------");
			Console.WriteLine($"*       MicroAccuracy:    {testMetrics.MicroAccuracy:0.###}");
			Console.WriteLine($"*       MacroAccuracy:    {testMetrics.MacroAccuracy:0.###}");
			Console.WriteLine($"*       LogLoss:          {testMetrics.LogLoss:#.###}");
			Console.WriteLine($"*       LogLossReduction: {testMetrics.LogLossReduction:#.###}");
			Console.WriteLine($"*************************************************************************************************************");

			mlContext.Model.Save(model, trainingData.Schema, modelPath);

			Console.WriteLine($"Model saved to {modelPath}");
		}
	}
}