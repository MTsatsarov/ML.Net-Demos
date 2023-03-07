using IssueCategorizer.Models;

namespace IssueCategorizer.Services.Interfaces
{
	public interface IIssueService
	{
		string GetPrediction(IssueInputModel model);
	}
}
