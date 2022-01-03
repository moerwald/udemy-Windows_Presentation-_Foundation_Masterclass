using System.Windows;
using System.Windows.Documents;

namespace EvernoteClone.ViewModels.Commands
{
    internal class TextUnderlineCommand : BaseCommand
    {
        private RichTextBoxViewModel _richTextBoxViewModel;

        public TextUnderlineCommand(RichTextBoxViewModel richTextBoxViewModel) => _richTextBoxViewModel = richTextBoxViewModel;

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            if (parameter is bool isChecked)
            {
                _richTextBoxViewModel.SelectedText.ApplyPropertyValue(Inline.TextDecorationsProperty, isChecked ? TextDecorations.Underline : null);
            }
        }
    }
}