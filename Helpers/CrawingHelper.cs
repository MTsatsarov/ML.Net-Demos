
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace Helpers
{
	public class CrawlingHelper
	{
		public async Task<IHtmlDocument> GetDocument(string uri)
		{
			var httpClient = new HttpClient();
			var request = await httpClient.GetAsync(uri);

			var document = await this.ParseDocument(request);
			return document;
		}
		public async Task<IHtmlDocument> ParseDocument(HttpResponseMessage httpResponseMessage)
		{
			var parser = new HtmlParser();
			var stringContent = await httpResponseMessage.Content.ReadAsStreamAsync();
			var document = parser.ParseDocument(stringContent);
			return document;
		}

	}
}
