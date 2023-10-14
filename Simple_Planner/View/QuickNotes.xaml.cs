using GalaSoft.MvvmLight.Command;
using Simple_Planner.Models;
using Simple_Planner.ViewModels;
using Simple_Planner.Usage;
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

namespace Simple_Planner.View
{
    public partial class QuickNotes : UserControl
    {
        public static readonly string PATH = $"{Environment.CurrentDirectory}\\Simple_PlannerQuickNotes.json";
        private static BindingList<QuickNotesModel> _quickNotesData { get; set; }
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _textu;

        public string Textu
        {
            get { return _textu; }
            set
            {
                if (value != _textu)
                {
                    _textu = value;
                    OnPropertyChanged("Name2");
                }
            }
        }
        public void AddNewRow(object sender, RoutedEventArgs e)
        {
            if (QuickNotesTextBox.Text != null)
            {
                //Textu = QuickNotesTextBox.Text;
                //MessageBox.Show(Textu);
                var help = new QuickNotesModel { NoteText = QuickNotesTextBox.Text };
                QuickNotesData.Add(help);
                QuickNotesTextBox.Text = null;
            }

        }

        public void RemoveThisRow(object sender, RoutedEventArgs e)
        {
            QuickNotesModel d = sender as QuickNotesModel;
            QuickNotesData.Remove(d);
        }

        public QuickNotes()
        {
            InitializeComponent();
            
            _fileOutput = new Output(PATH);
            try
            {
                _quickNotesData = _fileOutput.LoadQuickNotesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            _quickNotesData.ListChanged += QuickNotes_ListChanged;
            QuickNotesList.ItemsSource = _quickNotesData;
            NoteColumn.Width = 480 - RemoveButtonColumn.Width;
        }
    }
}
