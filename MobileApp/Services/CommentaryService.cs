using Microsoft.Extensions.ML;
using MobileApp.Services.Interfaces;

namespace MobileApp.Services
{
	public class CommentaryService : ICommentaryService
	{
		private readonly PredictionEnginePool<ModelBuilder.ModelInput, ModelBuilder.ModelOutput> enginePool;
		public CommentaryService(PredictionEnginePool<ModelBuilder.ModelInput, ModelBuilder.ModelOutput> enginePool)
		{
			this.enginePool = enginePool;
		}

		public ModelBuilder.ModelOutput Predict(string text)
		{

			var predictionModel = this.enginePool.Predict(new ModelBuilder.ModelInput() { Comment = text });

			return predictionModel;
		}
	}
}
