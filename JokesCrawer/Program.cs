using System.Reflection;

namespace JokesCrawer
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			var crawer = new Crawer();

			await crawer.GetData();
		}
	}
}