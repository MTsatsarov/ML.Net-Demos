using Microsoft.ML.Data;
namespace GitHubIssueModelCreator.Models
{
	public class GitHubIssueOutputModel
	{
		[ColumnName("PredictedLabel")]
        public string Area { get; set; }
    }
}
