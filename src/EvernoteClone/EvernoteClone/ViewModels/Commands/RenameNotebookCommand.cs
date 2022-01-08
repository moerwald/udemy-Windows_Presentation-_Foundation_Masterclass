using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModels.Commands
{
    public class RenameNotebookCommand : BaseCommand
    {
        private readonly NotesViewModel _notesViewModel;

        public RenameNotebookCommand(NotesViewModel notesViewModel)
        {
            _notesViewModel = notesViewModel;
        }

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            _notesViewModel.RenameIsVisible = System.Windows.Visibility.Visible;
        }
    }
}
