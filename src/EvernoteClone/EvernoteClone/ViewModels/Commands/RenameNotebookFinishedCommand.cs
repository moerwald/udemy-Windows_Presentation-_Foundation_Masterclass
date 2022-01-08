using EvernoteClone.Model;

namespace EvernoteClone.ViewModels.Commands
{
    public class RenameNotebookFinishedCommand : BaseCommand
    {
        private readonly NotesViewModel _notesViewModel;

        public RenameNotebookFinishedCommand(NotesViewModel notesViewModel) 
            => _notesViewModel = notesViewModel;

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            if (parameter is Notebook notebook)
            {
                _notesViewModel.RenameFinished(notebook);
            }
        }
    }
}
