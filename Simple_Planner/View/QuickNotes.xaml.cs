using Simple_Planner.Models;
using System.Windows;
using System.Windows.Controls;
using Simple_Planner.ViewModels;

namespace Simple_Planner.View
{
    public partial class QuickNotes : UserControl
    { 
        public void AddNewRow(object sender, RoutedEventArgs e)
        {
            if (QuickNotesTextBox.Text != null)
            {
                var NewNote = new QuickNotesModel { NoteText = QuickNotesTextBox.Text };
                QuickNotesViewModel.QuickNotesData.Add(NewNote);
                QuickNotesTextBox.Text = null;
            }

        }

        public QuickNotes()
        {
            InitializeComponent();
            QuickNotesList.ItemsSource = QuickNotesViewModel.QuickNotesData;
        }
        
    }
}
