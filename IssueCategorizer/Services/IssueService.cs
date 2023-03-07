using IssueCategorizer.Models;
using IssueCategorizer.Services.Interfaces;
using Microsoft.Extensions.ML;

namespace IssueCategorizer.Services
{
	public class IssueService : IIssueService
	{
		private readonly PredictionEnginePool<IssueInputModel, IssueOutputModel> enginePool;

		public IssueService(PredictionEnginePool<IssueInputModel, IssueOutputModel> enginePool)
		{
			this.enginePool = enginePool;
		}

		public string GetPrediction(IssueInputModel model)
		{
			var result = this.enginePool.Predict(model);

			return result.Area;
		}
	}
}
