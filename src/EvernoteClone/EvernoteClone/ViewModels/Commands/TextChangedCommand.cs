using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModels.Commands
{
    internal class TextChangedCommand : BaseCommand
    {
        private readonly RichTextBoxViewModel richTextBoxViewModel;

        public TextChangedCommand(RichTextBoxViewModel richTextBoxViewModel)
        {
            this.richTextBoxViewModel = richTextBoxViewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
