using Microsoft.ML.Data;

namespace IssueCategorizer.Models
{
	public class IssueOutputModel
	{
		[ColumnName("PredictedLabel")]
		public string Area { get; set; }
	}
}
