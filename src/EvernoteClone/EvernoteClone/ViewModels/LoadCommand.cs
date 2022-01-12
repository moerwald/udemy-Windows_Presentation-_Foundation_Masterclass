using EvernoteClone.Model;
using EvernoteClone.ViewModels.Commands;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace EvernoteClone.ViewModels
{
    internal class LoadCommand : BaseCommand
    {
        private RichTextBoxViewModel _richTextBoxViewModel;

        public LoadCommand(RichTextBoxViewModel richTextBoxViewModel)
        {
            _richTextBoxViewModel = richTextBoxViewModel;
        }

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

            var doc = _richTextBoxViewModel.Text;

            if (note.FileLocation is null)
            {
                doc.Blocks.Clear();
                return;
            }

            var tr = new TextRange(doc.ContentStart, doc.ContentEnd);

            using var fs = new FileStream(note.FileLocation, FileMode.Open);
            tr.Load(fs, DataFormats.Rtf);
        }
    }
}