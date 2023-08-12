using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Simple_Planner.Models;
using Simple_Planner.Usage;

namespace Simple_Planner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\Simple_PlannerDataList.json";
        private BindingList<PlannerModel> _PlannerData;
        private Output _fileOutput;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileOutput = new Output(PATH);
            try
            {
                _PlannerData = _fileOutput.LoadData();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                Close();
            }

            TaskList.ItemsSource = _PlannerData;
            _PlannerData.ListChanged += _PlannerData_ListChanged;
        }

        private void _PlannerData_ListChanged(object sender, ListChangedEventArgs e)
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
                    Close();
                }
            }
            
        }

        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
