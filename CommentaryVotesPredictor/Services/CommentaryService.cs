using CommentaryVotes.Models;
using CommentaryVotesPredictor.Services.Interfaces;
using Microsoft.Extensions.ML;

namespace CommentaryVotesPredictor.Services
{
	public class CommentaryService : ICommentaryService
	{
		private readonly PredictionEnginePool<ModelInput,OutputModel> enginePool;

        public CommentaryService(PredictionEnginePool<ModelInput, OutputModel> enginePool)
        {
			this.enginePool = enginePool;
		}
        public OutputModel Predict(string commentary)
		{
			return enginePool.Predict(new ModelInput() { Text = commentary });
		}
	}
}
