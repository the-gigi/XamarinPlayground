using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace XamarinPlayground
{
    /// <summary>
    /// Fetch the #1 article from HackerNews
    /// </summary>
    public class FeatureFetcher
    {
        public string Title { get; set; }
        public string Url { get; set; }

        public FeatureFetcher()
        {            
        }

        public async Task Fetch()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://news.ycombinator.com/news");

            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            await Task.Run(() => parse(content));
        }

        private void parse(string page)
        {
            var start = page.IndexOf ("1.</span>");
            var end = page.IndexOf ("2.</span>");

            var text = page.Substring (start, end);
            // Skip over first link
            text = text.Substring(text.IndexOf("</a>"));
            // Skip to article link
            var index = text.IndexOf("<a href");
            text = text.Substring(index);

            // Trim rest
            var endIndex = text.IndexOf("</a>");
            text = text.Substring(0, endIndex);

            // Trim up to first quote

            text = text.Substring(text.IndexOf('"') + 1);
            var secondQuote = text.IndexOf ('"');

            Url = text.Substring (0, secondQuote);
            Title = text.Substring(secondQuote + 2);
        }
    }
}

