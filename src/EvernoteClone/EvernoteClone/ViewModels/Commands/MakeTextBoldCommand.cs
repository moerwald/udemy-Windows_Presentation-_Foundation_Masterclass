using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace EvernoteClone.ViewModels.Commands
{
    internal class MakeTextBoldCommand : BaseCommand
    {
        private readonly RichTextBoxViewModel _richTextBoxViewModel;

        public MakeTextBoldCommand(RichTextBoxViewModel richTextBoxViewModel) => _richTextBoxViewModel = richTextBoxViewModel;

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            if (parameter is bool isChecked)
            {
                _richTextBoxViewModel.SelectedText.ApplyPropertyValue(
                    TextElement.FontWeightProperty,
                    isChecked ? FontWeights.Bold : FontWeights.Normal);
            }
        }
    }
}
