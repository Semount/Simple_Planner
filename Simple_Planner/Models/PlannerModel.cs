using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Simple_Planner.Models
{
    public class PlannerModel: INotifyPropertyChanged
    {
        private bool _IsDone;
        private string _Text;
        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        

        [JsonProperty(PropertyName = "isDone")] 
    
        public bool IsDone 
        { 
            get { return _IsDone; }
            set 
            { 
                if (_IsDone == value) return;
                _IsDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        [JsonProperty(PropertyName = "text")]
        public string Text
        {
            get { return _Text; }
            set 
            { 
                if( _Text == value) return;
                _Text = value; 
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
