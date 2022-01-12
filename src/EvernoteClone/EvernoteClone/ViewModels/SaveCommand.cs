using EvernoteClone.Model;
using EvernoteClone.ViewModels.Commands;
using EvernoteClone.ViewModels.Helpers;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace EvernoteClone.ViewModels
{
    internal class SaveCommand : BaseCommand
    {
        private RichTextBoxViewModel _richTextBoxViewModel;

        public SaveCommand(RichTextBoxViewModel richTextBoxViewModel) => _richTextBoxViewModel = richTextBoxViewModel;

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is not Note note )
            {
                return;
            }

            var fileName = Path.Combine(System.Environment.CurrentDirectory, $"{note.NotebookId}_{note.Id}_{note.UpdatedAt.ToString("MM_dd_yyyy_HH_mm_ss")}.rtf");
            using var fileStream = new FileStream(fileName, FileMode.Create);

            var doc = _richTextBoxViewModel.Text;
            var tr = new TextRange(doc.ContentStart, doc.ContentEnd);

            tr.Save(fileStream, DataFormats.Rtf);

            note.FileLocation = fileName;
            DatabaseHelper.Update(note);
        }
    }
}