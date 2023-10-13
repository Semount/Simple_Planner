using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Simple_Planner.ViewModels
{
    internal class QuickNotesViewModel
    {
        private ICommand _addNewRowCommand {  get; set; }
        public ICommand AddNewRowCommand 
        {
            get
            {
                if (_addNewRowCommand == null)
                    return _addNewRowCommand = new RelayCommand<Object>(AddNewRow);
                else return _addNewRowCommand;
            }
        }
        public void AddNewRow(object sender)
        {
            MessageBox.Show("UFCK");
        }
    }
}
