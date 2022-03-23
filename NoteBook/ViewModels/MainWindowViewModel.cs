using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NoteBook.Models;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using System.Linq;

namespace NoteBook.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase page;
        DateTime currentDate = DateTime.Today;
        ObservableCollection<Note> noteList;

        Dictionary<DateTime, List<Note>> notes = new Dictionary<DateTime, List<Note>>() { { DateTime.Today, new List<Note>()
            {
            new Note("task1", "desc1"),
            new Note("task2", "desc2"),
            new Note("task3", "desc3")
            } } };

        public ObservableCollection<Note> NoteList 
        { 
            get => noteList;
            set
            {
                this.RaiseAndSetIfChanged(ref noteList, value);
            }
        }

        public ViewModelBase Page
        {
            set => this.RaiseAndSetIfChanged(ref page, value);
            get => page;
        }

        public TaskListViewModel MainPage
        {
            get;
        }
        public DateTime CurrentDate
        {
            set => this.RaiseAndSetIfChanged(ref currentDate, value);
            get => currentDate;
        }
        public MainWindowViewModel()
        {
            Page = MainPage = new TaskListViewModel();
            NoteList = new ObservableCollection<Note>(notes[currentDate]);
            ObserveCommand = ReactiveCommand.Create<Note, int>((note) => openObservePage(note));
            SetDateCommand = ReactiveCommand.Create<DateTime, DateTime>((date) => CurrentDate = date);
        }

        public ReactiveCommand<Note, int> ObserveCommand { get; }
        public ReactiveCommand<Note, int> DeleteCommand { get; }
        public ReactiveCommand<DateTime, DateTime> SetDateCommand { get; }
        public void openAddPage()
        {
            var taskPage = new TaskViewModel(new Note("", ""));
            Page = taskPage;
            Observable.Merge(taskPage.AddCommand, taskPage.CancelCommand).Take(1)
                .Subscribe((note) =>
                {
                    if(note.header != "")
                    {
                        bool added = notes.TryAdd(CurrentDate, new List<Note> { note });
                        if (!added)
                        {
                            notes[CurrentDate].Add(note);
                        }
                    }
                    NoteList = new ObservableCollection<Note>(notes[currentDate]);
                    Page = MainPage;
                });
        }

        public int openObservePage(Note selectedNote)
        {
            var taskPage = new TaskViewModel(selectedNote);
            Page = taskPage;
            Observable.Merge(taskPage.AddCommand, taskPage.CancelCommand).Take(1)
                .Subscribe((note) =>
                {
                    if (note.header != "")
                    {
                        selectedNote = note;
                    }
                    NoteList = new ObservableCollection<Note>(notes[currentDate]);
                    Page = MainPage;
                });
            return 1;
        }
    }
}
