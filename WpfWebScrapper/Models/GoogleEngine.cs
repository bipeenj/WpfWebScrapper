using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfWebScrapper.Models
{
    public class GoogleEngine : ISearchEngine
    {
        public string SearchEngineUrl { get ; set ; }
        public int PageCount { get; set; }
        public List<string> Keywords { get; set; }
        public List<KeyValuePair<string, int>> Search(string urlIn)
        {
            List<KeyValuePair<string, int>> returnValue= new List<KeyValuePair<string, int>>();
            //returnValue.Add(new KeyValuePair<string, int>("Test",10));
            Keywords.ForEach(word => {
                var count = GetCount(word, urlIn);
                returnValue.Add(new KeyValuePair<string, int>(word, count));
            });
            return returnValue;
        }
        private int GetCount(string wordIn,string matchingurl)
        {
            int resultOut = 0;
            var tosearch = wordIn.Replace(' ', '+');
            var urlToSearch = $"{SearchEngineUrl}num={PageCount}&q={tosearch}";
            resultOut = SearchContent(urlToSearch, matchingurl).Count();
            return resultOut;
        }
        private IEnumerable<int> SearchContent(string urlToSearch,string matchingurl)
        {
            string html;
            using (var webClient = new WebClient())
            {
                html = webClient.DownloadString(urlToSearch);
            }

            return SearchWithinText(html, matchingurl);
        }
        public IEnumerable<int> SearchWithinText(string textContent, string expressionTosearch)
        {
            var regex = new Regex(@"href=\""(.*?)\""");

            var matches = regex.Matches(textContent).Cast<Match>().ToList();

            var indexes = matches.Select((x, i) => new { i, x })
                .Where(x => x.ToString().Contains(expressionTosearch))
                .Select(x => x.i + 1)
                .ToList();
            return indexes;
        }
    }
}
