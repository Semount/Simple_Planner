using Simple_Planner.Models;
using System;
using System.Windows.Input;
using Simple_Planner.View;
using System.Windows.Controls;
using Simple_Planner.Core;

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
        private void RemoveRow(object SelectedItem)
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
        private void CloseRow(object sender)
        {
            var ToClose = sender as DataGrid;
            ToClose.UnselectAllCells();
        }
    }
}
