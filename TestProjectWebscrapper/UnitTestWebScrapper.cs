using NUnit.Framework;
using WpfWebScrapper.Models;
using System.Linq;
using System.Windows.Automation;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;

namespace TestProjectWebscrapper
{
    public class Tests
    {
        public const string DriverUrl = "http://127.0.0.1:4723";
        public WindowsDriver<WindowsElement> DesktopSession;
        [SetUp]
        public void Setup()
        {
            //AppiumOptions Options = new AppiumOptions();
            //Options.AddAdditionalCapability("app", "..\\WpfWebScrapper\\bin\\Debug\\netcoreapp3.1\\WpfWebScrapper.exe");
            //Options.AddAdditionalCapability("deviceName", "WindowsPC");
            //DesktopSession = new WindowsDriver<WindowsElement>(new Uri(DriverUrl), Options);
            //Assert.IsNotNull(DesktopSession);
        }

        [Test]
        public void Test1()
        {
            string testContent = "<a href=\"/ url ? q = https ://www.smokeball.com.au/practice-area/conveyancing-software&amp;sa=U&amp;ved=2ahUKEwjthNqWoKDyAhVDwzgGHeEpAUcQFnoECEgQAQ&amp;usg=AOvVaw2bzXRzCLHfTAjD2ZJTZITU\">";
            GoogleEngine engine = new GoogleEngine();
            var result = engine.SearchWithinText(testContent, "https ://www.smokeball.com.au");
            Assert.IsTrue( result.Count() == 1);
            
        }
        [Test]
        public void Test2()
        {
            
            Assert.Pass();

        }
        [TearDown]
        public void Close()
        {
            DesktopSession?.CloseApp();
        }
    }
}