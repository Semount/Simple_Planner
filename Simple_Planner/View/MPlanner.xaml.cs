using Simple_Planner.Models;
using Simple_Planner.Usage;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


namespace Simple_Planner.View
{
    /// <summary>
    /// Interaction logic for MPlanner.xaml
    /// </summary>

    public partial class MPlanner : UserControl
    {

        public static readonly string PATH = $"{Environment.CurrentDirectory}\\Simple_PlannerDataList.json";
        private static BindingList<PlannerModel> _plannerData { get; set; }
        public static BindingList<PlannerModel> PlannerData
        {
            get
            {
                return _plannerData;
            }
            set
            {
                if (_plannerData != value)
                {
                    _plannerData = value;
                }
            }
        }
        private static Output _fileOutput;

        public static void PlannerData_ListChanged(object sender, ListChangedEventArgs e)
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
        protected virtual void OnCheckboxChecked(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                System.Media.SoundPlayer player =
                new System.Media.SoundPlayer();
                player.SoundLocation = $"{Environment.CurrentDirectory}\\complete.wav";
                player.Load();
                player.Play();
            }
        }

        public MPlanner()
        {
            InitializeComponent();

            _fileOutput = new Output(PATH);
            try
            {
                _plannerData = _fileOutput.LoadPlannerData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            _plannerData.ListChanged += PlannerData_ListChanged;
            TaskList.ItemsSource = _plannerData;
        }
    }
}
