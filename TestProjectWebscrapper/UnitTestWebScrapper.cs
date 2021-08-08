using NUnit.Framework;
using WpfWebScrapper.Models;
using System.Linq;
namespace TestProjectWebscrapper
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string testContent = "<a href=\"/ url ? q = https ://www.smokeball.com.au/practice-area/conveyancing-software&amp;sa=U&amp;ved=2ahUKEwjthNqWoKDyAhVDwzgGHeEpAUcQFnoECEgQAQ&amp;usg=AOvVaw2bzXRzCLHfTAjD2ZJTZITU\">";
            GoogleEngine engine = new GoogleEngine();
            var result = engine.SearchWithinText(testContent, "https ://www.smokeball.com.au");
            Assert.IsTrue( result.Count() == 1);
            
        }
    }
}