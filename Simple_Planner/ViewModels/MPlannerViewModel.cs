using Simple_Planner.Models;
using Simple_Planner.Usage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Simple_Planner.View;
using System.Windows.Controls;

namespace Simple_Planner.ViewModels
{
    internal class MPlannerViewModel
    {
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
                    return _closeRowCommand = new RelayCommand<Object>(CloseRow);
                else return _closeRowCommand;
            }
        }
        public void CloseRow(object sender)
        {
            var ToClose = sender as DataGrid;
            ToClose.UnselectAllCells();
        }
    }
}
