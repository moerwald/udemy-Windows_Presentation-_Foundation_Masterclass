using System.Windows;
using System.Windows.Documents;

namespace EvernoteClone.ViewModels.Commands
{
    internal class TextItalicCommand : BaseCommand
    {
        private readonly RichTextBoxViewModel _richTextBoxViewModel;

        public TextItalicCommand(RichTextBoxViewModel richTextBoxViewModel) 
            => _richTextBoxViewModel = richTextBoxViewModel;

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            if (parameter is bool isChecked)
            {
                _richTextBoxViewModel.SelectedText.ApplyPropertyValue(TextElement.FontStyleProperty,
                    isChecked ? FontStyles.Italic : FontStyles.Normal);
            }
        }
    }
}