namespace CommentaryAggresion
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			var crawer = new CommentariesCrawer();
			await crawer.GetCommentaries();

		}
	}
}