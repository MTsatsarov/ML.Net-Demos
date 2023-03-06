
using CommentaryVotes.Models;

namespace CommentaryVotesPredictor.Services.Interfaces
{
	public interface ICommentaryService
	{
		OutputModel Predict(string commentary);
	}
}
