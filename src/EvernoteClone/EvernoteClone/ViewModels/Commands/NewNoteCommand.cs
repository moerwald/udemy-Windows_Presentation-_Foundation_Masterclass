using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EvernoteClone.ViewModels.Commands
{
    public class NewNoteCommand: BaseCommand
    {
        public NewNoteCommand(NotesViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public NotesViewModel ViewModel { get; }

        public override bool CanExecute(object? parameter)
            =>
            parameter is Notebook nb && nb is not null;

        public override void Execute(object? parameter)
        {
            if (parameter is not Notebook nb)
                return;

            ViewModel.NewNote(nb);
        }
    }
}
