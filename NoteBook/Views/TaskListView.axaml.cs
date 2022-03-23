using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NoteBook.ViewModels;
using System;
using Avalonia.Interactivity;

namespace NoteBook.Views
{
    public partial class TaskListView : UserControl
    {
        public TaskListView()
        {
            InitializeComponent();
            //this.FindControl<DatePicker>("DateP").SelectedDate = DateTime.Today;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
