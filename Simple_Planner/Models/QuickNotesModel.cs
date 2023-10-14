using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Planner.Models
{
    public class QuickNotesModel : INotifyPropertyChanged
    {
        private string _noteText;

        [JsonProperty(PropertyName = "noteText")]
        public string NoteText
        {
            get { return _noteText; }
            set 
            {
                if (_noteText == value) return;
                _noteText = value;
                OnPropertyChanged("NoteText");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
