
using Microsoft.ML.Data;

namespace CommentaryVotes.Models
{
	public class ModelInput
	{
		[LoadColumn(0)]
		public string Text { get; set; }

		[LoadColumn(1),ColumnName("Label")]
        public bool Liked { get; set; }
    }
}
