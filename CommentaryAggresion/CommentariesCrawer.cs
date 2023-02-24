using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.IO;
using System.Text;

namespace CommentaryAggresion
{
	public class CommentariesCrawer
	{
		public async Task GetCommentaries()
		{
			var page = 1;
			Console.OutputEncoding = Encoding.UTF8;
			var newsNumber = 561000;
			while (true)
			{
				var endpoint = $"https://www.dnes.bg/politika/2023/02/24/bsp-zove-diplomaciiata-na-sloji-krai-na-voinata-v-ukraina.{newsNumber},{page}";
				var document = await this.GetDocument(endpoint);

				var commentaries = document.All.Where(x => x.ClassName == "commen_cont").ToList();
				if (!commentaries.Any())
				{
					newsNumber += 1;
					page = 1;
					continue;
				}

				foreach (var comment in commentaries)
				{
					var commentVotes = comment.Children.FirstOrDefault(c => c.ClassName == "comment_nav").Children.FirstOrDefault(cc => cc.ClassName == "comment_vote grade");
					var negativeVoteCount = double.Parse(commentVotes.Children.FirstOrDefault(c => c.ClassName == "comments-grade comments-grades-down").TextContent);
					var positiveVoteCount = double.Parse(commentVotes.Children.FirstOrDefault(c => c.ClassName == "comments-grade comments-grades-up").TextContent);

					var commentText = comment.Children.FirstOrDefault(c => c.ClassName == "comment_text");
					var commentTextChildren = comment.Children.FirstOrDefault(c => c.ClassName == "comment_text").Children[0];
					commentText.RemoveChild(commentTextChildren);

					var votesCount = negativeVoteCount + positiveVoteCount;

					if (votesCount > 15)
					{
						bool isPositiveVote = (positiveVoteCount / votesCount) > 0.70;
						bool isNegativeVote = (negativeVoteCount / votesCount) > 0.70;
						if (isPositiveVote || isNegativeVote)
						{
							Console.WriteLine(commentText.TextContent);
							Console.WriteLine($"Negative votes count - {negativeVoteCount}");
							Console.WriteLine($"Positive votes count - {positiveVoteCount}");
							Console.WriteLine();

							if (isPositiveVote)
							{
								await this.SaveCommentData(commentText.TextContent, true);
							}
							else
							{
								await this.SaveCommentData(commentText.TextContent, false);
							}
						}
					}
				}
				page += 1;
			}
		}

		private async Task SaveCommentData(string textContent, bool positive)
		{
			var path = "commentaries.txt";
			var content = textContent.Replace("\"", string.Empty).Replace(",", string.Empty);
			try
			{
				using (StreamWriter file = new StreamWriter(path, true))
				{
					await file.WriteLineAsync($"{textContent},{positive}");
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IHtmlDocument> GetDocument(string uri)
		{
			var httpClient = new HttpClient();
			var request = await httpClient.GetAsync(uri);

			var response = await request.Content.ReadAsStreamAsync();
			var parser = new HtmlParser();
			var document = parser.ParseDocument(response);
			return document;
		}

		public async Task<IHtmlDocument> ParseDocument(HttpResponseMessage httpResponseMessage)
		{
			var parser = new HtmlParser();
			var stringContent = await httpResponseMessage.Content.ReadAsStringAsync();
			var document = parser.ParseDocument(stringContent);
			return document;
		}
	}
}
