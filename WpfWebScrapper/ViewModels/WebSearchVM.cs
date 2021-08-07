using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;

namespace WpfWebScrapper.ViewModels
{
    public class WebSearchVM: INotifyPropertyChanged
    {
        private ObservableCollection<KeywordVM> m_Result;
        private string m_Strings;
        public WebSearchVM()
        {
            Result = new ObservableCollection<KeywordVM>();
            KeyWords = "conveyancing software";
            URL = "www.smokeball.com.au";
            
            
            
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
                    if (word.Any())
                    {
                        Result.Add(new KeywordVM
                        {
                            Name = word,
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

        
    }
}
