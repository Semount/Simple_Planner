using Simple_Planner.Models;
using Simple_Planner.Core;
using System.Windows.Input;
using System;
using System.Windows;
using Simple_Planner.Usage;
using System.ComponentModel;

namespace Simple_Planner.ViewModels
{
    internal class QuickNotesViewModel
    {
        public static readonly string PATH = $"{Environment.CurrentDirectory}\\Simple_PlannerQuickNotes.json";
        private static BindingList<QuickNotesModel> _quickNotesData;
        public static BindingList<QuickNotesModel> QuickNotesData
        {
            get
            {
                return _quickNotesData;
            }
            set
            {
                if (_quickNotesData != value)
                {
                    _quickNotesData = value;
                }
            }
        }
        private static Output _fileOutput;

        public static void QuickNotes_ListChanged(object sender, ListChangedEventArgs e)
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

        private ICommand _removeRowCommand { get; set; }
        public ICommand RemoveRowCommand
        {
            get
            {
                if (_removeRowCommand == null)
                    return _removeRowCommand = new RelayCommand<QuickNotesModel>(RemoveRow);
                else return _removeRowCommand;
            }
            set { _removeRowCommand = value; }
        }
        private void RemoveRow(QuickNotesModel Note)
        {
            QuickNotesData.Remove(Note);
        }

        public QuickNotesViewModel()
        {
            _fileOutput = new Output(PATH);
            try
            {
                QuickNotesData = _fileOutput.LoadQuickNotesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            QuickNotesData.ListChanged += QuickNotes_ListChanged;
        }
    }
}
