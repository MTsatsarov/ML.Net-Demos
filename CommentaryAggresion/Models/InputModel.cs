using Microsoft.ML.Data;

namespace CommentaryVotes.Models
{
	public class InputModel
	{
		[LoadColumn(0)]
		public bool Label { get; set; }

		[LoadColumn(2)]
		public string Text { get; set; }
	}
}
