using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfWebScrapper.Models;

namespace WpfWebScrapper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; set; }
        public App()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GoogleEngine>().As<ISearchEngine>();
            Container = builder.Build();
        }
    }
}
