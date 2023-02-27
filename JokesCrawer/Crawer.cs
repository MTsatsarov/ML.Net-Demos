
using System.Reflection;
using System.Text;
using AngleSharp.Html.Dom;
using Helpers;

namespace JokesCrawer
{
	public class Crawer
	{
		private CrawlingHelper helper;

		public Crawer()
		{
			this.helper = new CrawlingHelper();
		}

		public async Task GetData()
		{
			Console.OutputEncoding = Encoding.UTF8;

			var endpoint = "https://www.vesti.bg/vicove";

			var document = await this.helper.GetDocument(endpoint);
			var categories = GetCategories(document);

			var listOfTask = new List<Task>();

			var tasks = categories.Select(c => GetJokes(c)).ToList();
			await Task.WhenAll(tasks);
		}

		private async Task GetJokes(KeyValuePair<string, string> category)
		{
			var page = 1;

			while (true)
			{
				var newDocument = await this.helper.GetDocument(category.Value + $"/{page}");

				var jokes = newDocument.All.Where(x => x.ClassName == "anecdote-text").ToList();

				if (!jokes.Any())
				{
					break;
				}

				foreach (var currJoke in jokes)
				{
					var text = currJoke.Children[0].TextContent;
					await this.SaveData(text, category.Key);
					Console.WriteLine(text+ $" - {category.Key}");
				}

				page += 1;
			}
		}

		private async Task SaveData(string text, string key)
		{
			var currentLocation = Assembly.GetEntryAssembly().Location;

			var path = Path.GetFullPath(Path.Combine(currentLocation, @"..\..\..\..\jokes.txt"));

			var content = text.Replace("\"", string.Empty).Replace(",", string.Empty);
			try
			{
				using (StreamWriter file = new StreamWriter(path, true))
				{
					await file.WriteLineAsync($"{content},{key}");
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private Dictionary<string, string> GetCategories(IHtmlDocument document)
		{
			var categoriesNavigation = document.All.FirstOrDefault(x => x.ClassName == "vicove-nav");

			var categories = new Dictionary<string, string>();

			foreach (var child in categoriesNavigation.Children)
			{
				var link = child.Children.FirstOrDefault().GetAttribute("href");

				categories.Add(child.TextContent, link);
				Console.WriteLine($"{child.TextContent} - {link}");
			}
			return categories;
		}
	}
}
