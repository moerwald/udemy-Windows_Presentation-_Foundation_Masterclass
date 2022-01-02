using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModels.Commands
{

    public class NewNotebookCommand : BaseCommand
    {
        public NewNotebookCommand(NotesViewModel notesViewModel) => NotesViewModel = notesViewModel;

        public NotesViewModel NotesViewModel { get; }

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter) => NotesViewModel.NewNotebook();

    }
}
