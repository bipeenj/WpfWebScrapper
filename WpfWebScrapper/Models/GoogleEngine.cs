using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWebScrapper.Models
{
    class GoogleEngine : ISearchEngine
    {
        public string SearchEngineUrl { get ; set ; }
        public int PageCount { get; set; }
        public List<string> Keywords { get; set; }
        public List<KeyValuePair<string, int>> Search(string urlIn)
        {
            List<KeyValuePair<string, int>> returnValue= new List<KeyValuePair<string, int>>();
            //returnValue.Add(new KeyValuePair<string, int>("Test",10));
            Keywords.ForEach(word => {
                var count = GetCount(word);
                returnValue.Add(new KeyValuePair<string, int>(word, count));
            });
            return returnValue;
        }
        private int GetCount(string wordIn)
        {
            int resultOut = 0;

            return resultOut;
        }
    }
}
