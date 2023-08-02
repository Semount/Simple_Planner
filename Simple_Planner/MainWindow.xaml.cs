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

namespace Simple_Planner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<PlannerModel> _PlannerData;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _PlannerData = new BindingList<PlannerModel>()
            {
                new PlannerModel {Text = "First"},
                new PlannerModel {Text = "Second"}
            };

            TaskList.ItemsSource = _PlannerData;
        }

        bool collapse = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Collapse(object sender, RoutedEventArgs e)
        {
            if (collapse == false)
            {
                this.Left_Bar.Width = new GridLength(35, GridUnitType.Pixel);
                this.Collapse_button.Content = "->";
                collapse = true;
            }
            else
            {
                this.Left_Bar.Width = new GridLength(180, GridUnitType.Pixel);
                this.Collapse_button.Content = "Collapse";
                collapse = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
