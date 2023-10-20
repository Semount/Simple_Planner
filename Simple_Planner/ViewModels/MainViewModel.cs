using Simple_Planner.Core;

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
