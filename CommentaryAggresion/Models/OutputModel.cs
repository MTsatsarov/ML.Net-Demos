using Microsoft.ML.Data;

namespace CommentaryVotes.Models
{
	public class OutputModel
	{
		[ColumnName("PredictedLabel")]
		public bool Prediction { get; set; }

		public float Probability { get; set; }

		public float Score { get; set; }
	}
}
