using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simple_Planner.Models
{
    internal class PlannerModel: INotifyPropertyChanged
    {
        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        public bool _IsDone;
        private string _Text; 
        
        [JsonProperty(PropertyName = "isDone")] 
    
        public bool IsDone 
        { 
            get { return _IsDone; }
            set 
            { 
                if (_IsDone == value) return;
                _IsDone = value;
                OnPropertyChanged("IsDone");
                OnCheckboxPropertyChanged();
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

        public event PropertyChangedEventHandler CheckBoxPropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        }

        protected virtual void OnCheckboxPropertyChanged()
        {
            if (_IsDone == true)
            {
                System.Media.SoundPlayer player =
                new System.Media.SoundPlayer();
                player.SoundLocation = $"{Environment.CurrentDirectory}\\complete.wav";
                player.Load();
                player.Play();
            }
        }
    }
}
