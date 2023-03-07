using Microsoft.ML.Data;

namespace IssueCategorizer.Models
{
	public class IssueInputModel
	{
		[LoadColumn(0)]
		public int Id { get; set; }

		[LoadColumn(1)]
		public string Area { get; set; }

		[LoadColumn(2)]
		public string Title { get; set; }

		[LoadColumn(3)]
		public string Description { get; set; }
	}
}
