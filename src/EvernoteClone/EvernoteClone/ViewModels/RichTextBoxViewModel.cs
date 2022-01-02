using EvernoteClone.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EvernoteClone.ViewModels
{
    internal class RichTextBoxViewModel : INotifyPropertyChanged
    {
        private FlowDocument _text;
        private TextSelection _textSelection;
        private bool _textIsBold;

        public RichTextBoxViewModel()
        {
            // Indirectly trigger RichtTextBoxHelper PropertyChanged event, don't remove this code, otherwise Binding between RichTextBox and this
            // ViewModel won't work
            Text = new FlowDocument();

            TextBoldCommand = new MakeTextBoldCommand(this);

        }

        public FlowDocument Text
        {
            get => _text;
            set
            {
                _text = value;

                OnPropertyChanged(nameof(Text));
            }
        }


        public TextSelection SelectedText
        {
            get => _textSelection;
            set
            {
                _textSelection = value;

                TextIsBold = (FontWeight)_textSelection.GetPropertyValue(TextElement.FontWeightProperty) == FontWeights.Bold;

                OnPropertyChanged(nameof(SelectedText));
            }
        }

        public bool TextIsBold
        {
            get => _textIsBold;
            set
            {
                _textIsBold = value;
                OnPropertyChanged(nameof(TextIsBold));
            }
        }

        public MakeTextBoldCommand TextBoldCommand { get; }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

    }
}
