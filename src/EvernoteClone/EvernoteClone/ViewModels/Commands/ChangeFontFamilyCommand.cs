using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EvernoteClone.ViewModels.Commands
{
    internal class ChangeFontFamilyCommand : BaseCommand
    {
        private readonly RichTextBoxViewModel _richTextBoxViewModel;

        public ChangeFontFamilyCommand(RichTextBoxViewModel richTextBoxViewModel) 
            => _richTextBoxViewModel = richTextBoxViewModel;

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter) 
            => 
            _richTextBoxViewModel.SelectedText.ApplyPropertyValue(TextElement.FontFamilyProperty, _richTextBoxViewModel.SelectedFontFamily);
    }
}
