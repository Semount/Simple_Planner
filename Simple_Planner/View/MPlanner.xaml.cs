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

namespace Simple_Planner.View
{
    /// <summary>
    /// Interaction logic for MPlanner.xaml
    /// </summary>
    public partial class MPlanner : UserControl
    {
        public MPlanner()
        {
            InitializeComponent();

            TaskList.ItemsSource = MainViewModel._PlannerData;
            MainViewModel._PlannerData.ListChanged += MainViewModel._PlannerData_ListChanged;
        }
    }
}
