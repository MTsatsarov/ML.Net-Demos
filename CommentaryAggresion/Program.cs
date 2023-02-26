using CommentaryVotes;
using Microsoft.ML;

namespace CommentaryAggresion
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			var crawer = new CommentariesCrawer();
			//await crawer.GetCommentaries();

			Console.WriteLine("Enter your commentary here:");

			var comment = Console.ReadLine();
			var engine = new CommentaryLikes();

			var obj = new CommentaryLikes.ModelInput
			{
				Text = comment
			};

			//var result = engine.Predict(obj);
		}
	}
}