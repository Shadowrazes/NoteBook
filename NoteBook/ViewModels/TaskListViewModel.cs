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
        DateTimeOffset? currentDate;
        public TaskListViewModel(DateTime curDate)
        {
            DateChanged = ReactiveCommand.Create<DateTimeOffset?, DateTimeOffset?>((date) => CurrentDate = date);
            CurrentDate = curDate;
        }

        public ReactiveCommand<DateTimeOffset?, DateTimeOffset?> DateChanged { get; }

        public DateTimeOffset? CurrentDate
        {
            set => this.RaiseAndSetIfChanged(ref currentDate, value);
            get => currentDate;
        }
    }
}
