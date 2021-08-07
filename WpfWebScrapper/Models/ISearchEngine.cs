using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWebScrapper.Models
{
    public interface ISearchEngine
    {
        public string SearchEngineUrl { get; set; }
        public List<string> Keywords { get; set; }
        public int PageCount { get; set; }
        public List<KeyValuePair<string, int>> Search(string urlIn);
    }
}
