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

        public static readonly string PATH = $"{Environment.CurrentDirectory}\\Simple_PlannerDataList.json";
        public static BindingList<PlannerModel> _PlannerData { get; set; }
        public static Output _fileOutput;

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand MPlannerViewCommand { get; set; }
        public RelayCommand QuickNotesViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }

        public MPlannerViewModel MPlannerVM { get; set; }

        public QuickNotesViewModel QuickNotesVM { get; set; }

        private object _currentView;

        public object currentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public static void _PlannerData_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileOutput.SaveData(sender);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    //Close();
                }
            }

        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            MPlannerVM = new MPlannerViewModel();
            QuickNotesVM = new QuickNotesViewModel();
            currentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                currentView = HomeVM;
            });

            MPlannerViewCommand = new RelayCommand(o =>
            {
                currentView = MPlannerVM;
                _fileOutput = new Output(PATH);
                try
                {
                    _PlannerData = _fileOutput.LoadData();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    //Close();
                }

            });

            QuickNotesViewCommand = new RelayCommand(o =>
            {
                currentView = QuickNotesVM;
            });

        }
    }
}
