using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using NoteBook.Models;
using ReactiveUI;
using System.Reactive;

namespace NoteBook.ViewModels
{
    public class TaskListViewModel : ViewModelBase
    {
        DateTime currentDate;
        public TaskListViewModel()
        {
            DateChanged = ReactiveCommand.Create<DateTime, DateTime>((date) => date);
        }

        public ReactiveCommand<DateTime, DateTime> DateChanged { get; }

        public DateTime CurrentDate
        {
            set => currentDate = value;
            get => currentDate;
        }
    }
}
