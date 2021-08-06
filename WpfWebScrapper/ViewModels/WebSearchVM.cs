using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWebScrapper.ViewModels
{
    public class WebSearchVM
    {
        public WebSearchVM()
        {
            KeyWords = "conveyancing software";
            URL = "www.smokeball.com.au";
        }
        public string KeyWords { get; set; }
        public string URL { get; set; }

        public List<KeywordVM> Result { get; set; }
    }
}
