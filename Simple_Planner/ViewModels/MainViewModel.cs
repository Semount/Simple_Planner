using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Simple_Planner.Core;
using Simple_Planner.Models;
using Simple_Planner.Usage;
using Simple_Planner.View;


namespace Simple_Planner.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand MPlannerViewCommand { get; set; }
        public RelayCommand QuickNotesViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }

        public MPlannerViewModel MPlannerVM { get; set; }

        public QuickNotesViewModel QuickNotesVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            MPlannerVM = new MPlannerViewModel();
            QuickNotesVM = new QuickNotesViewModel();
            CurrentView = HomeVM;


            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            MPlannerViewCommand = new RelayCommand(o =>
            {
                CurrentView = MPlannerVM;
                
            });

            QuickNotesViewCommand = new RelayCommand(o =>
            {
                CurrentView = QuickNotesVM;
            });

        }
    }
}
