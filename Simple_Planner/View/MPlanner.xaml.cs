using Simple_Planner.Models;
using Simple_Planner.Usage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using Simple_Planner.ViewModels;
using Simple_Planner.Core;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

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

        public MPlanner()
        {
            InitializeComponent();

            _fileOutput = new Output(PATH);
            try
            {
                _plannerData = _fileOutput.LoadData();
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
