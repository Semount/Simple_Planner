using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Simple_Planner.Core;
using Simple_Planner.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Simple_Planner.Models
{
    public class PlannerModel: INotifyPropertyChanged
    {
        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool _IsDone;
        public string _Text;

        

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

        private ICommand _removeRowCommand { get; set; }
        public ICommand RemoveRowCommand
        {
            get
            {
                if (_removeRowCommand == null)
                    return _removeRowCommand = new RelayCommand<Object>(RemoveRow);
                else return _removeRowCommand;
            }
        }
        public static void RemoveRow(object SelectedItem)
        {
            if (null != SelectedItem)
            {
                PlannerModel model = SelectedItem as PlannerModel;
                MPlanner.PlannerData.Remove(model);
            }
        }
        private ICommand _closeRowCommand { get; set; }
        public ICommand CloseRowCommand
        {
            get
            {
                if (_closeRowCommand == null)
                    return _closeRowCommand = new GalaSoft.MvvmLight.Command.RelayCommand<Object>(CloseRow);
                else return _closeRowCommand;
            }
        }
        public void CloseRow(object sender)
        {
            //var fuckme = new MPlanner();
            //fuckme.CloseRow(sender);
            var dg = sender as DataGrid;
            dg.UnselectAllCells();
        }
    }
}
