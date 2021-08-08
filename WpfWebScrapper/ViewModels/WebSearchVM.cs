using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using WpfWebScrapper.Models;
using System.Windows.Input;
using System;
using System.Collections.Generic;

namespace WpfWebScrapper.ViewModels
{
    public class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(CanExecuteChanged!=null)
            {

            }
                return true;
            
        }

        public void Execute(object parameter)
        {
            var vm = parameter as WebSearchVM;
            if (vm != null)
            {
                vm.MyEgine.Keywords = vm.KeyWords.Split(";").Where(i=> i.Any()).ToList();
                vm.Result.Clear();
                vm.MyEgine.SearchEngineUrl = "https://www.google.com/search?";
                vm.MyEgine.PageCount = 100;
                vm.MyEgine.Search(vm.URL).ForEach(pair =>
                {

                    vm.Result.Add(new KeywordVM
                    {
                        Name = pair.Key,
                        Count = pair.Value
                    });
                });
            }
        }
    }
    public class WebSearchVM: INotifyPropertyChanged
    {
        private ObservableCollection<KeywordVM> m_Result;
        private string m_Strings;
        public ISearchEngine MyEgine { get; set; }
        public WebSearchVM(ISearchEngine engineIn)
        {
            MyEgine = engineIn;
            Result = new ObservableCollection<KeywordVM>();
            KeyWords = "conveyancing software";
            URL = "www.smokeball.com.au";

            ButtonCommand = new ButtonCommand();


        }
        public string KeyWords 
        {
            get { return m_Strings; }
            set
            {
                m_Strings = value;
                OnPropertyChanged("KeyWords");
                Result.Clear();
                m_Strings.Split(";").ToList().ForEach(word => {
                    var toadd = word.Trim();
                    if (toadd.Any())
                    {
                        Result.Add(new KeywordVM
                        {
                            Name = toadd,
                            Count = 0
                        });
                    }
                });
                OnPropertyChanged("Result");
            }
        }
        public string URL { get; set; }

        public ObservableCollection<KeywordVM> Result 
        {
            get { return m_Result; }
            set
            {
                m_Result = value;
                OnPropertyChanged("Result");
                
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ButtonCommand { get; set; }
    }
}
