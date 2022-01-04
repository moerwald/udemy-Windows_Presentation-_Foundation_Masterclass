using EvernoteClone.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace EvernoteClone.ViewModels
{
    internal class RichTextBoxViewModel : INotifyPropertyChanged
    {
        private FlowDocument _text;
        private TextSelection _textSelection;
        private bool _textIsBold;
        private bool _textIsItalic;
        private bool textIsUnderlined;
        private FontFamily selectedFontFamily;
        private double _selectedFontSize;

        public RichTextBoxViewModel()
        {
            // Indirectly trigger RichtTextBoxHelper PropertyChanged event, don't remove this code, otherwise Binding between RichTextBox and this
            // ViewModel won't work
            Text = new FlowDocument();

            FontFamilies = new ObservableCollection<FontFamily>(Fonts.SystemFontFamilies.OrderBy(f => f.Source));
            FontSizes = new ObservableCollection<double>(new List<double> { 8, 9, 11, 13, 14, 16, 20, 24, 32, 48, 72 });

            TextBoldCommand = new MakeTextBoldCommand(this);
            TextItalicCommand = new TextItalicCommand(this);
            TextUnderlineCommand = new TextUnderlineCommand(this);

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

                TextIsBold = (FontWeight)_textSelection.GetPropertyValue(Inline.FontWeightProperty) == FontWeights.Bold;
                TextIsItalic = (FontStyle)_textSelection.GetPropertyValue(Inline.FontStyleProperty) == FontStyles.Italic;
                TextIsUnderlined = (TextDecorationCollection)_textSelection.GetPropertyValue(Inline.TextDecorationsProperty) == TextDecorations.Underline;

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

        public bool TextIsItalic
        {
            get => _textIsItalic;
            set
            {
                _textIsItalic = value;
                OnPropertyChanged(nameof(TextIsItalic));
            }
        }

        public bool TextIsUnderlined
        {
            get => textIsUnderlined; set
            {
                textIsUnderlined = value;
                OnPropertyChanged(nameof(TextIsUnderlined));
            }
        }


        public ObservableCollection<FontFamily> FontFamilies { get; init; }

        public ObservableCollection<double> FontSizes { get; init; }

        public FontFamily SelectedFontFamily
        {
            get => selectedFontFamily; set
            {
                selectedFontFamily = value;
                OnPropertyChanged();
            }
        }
        public double SelectedFontSize
        {
            get => _selectedFontSize; set
            {
                _selectedFontSize = value;
                OnPropertyChanged();
            }
        }

        public MakeTextBoldCommand TextBoldCommand { get; }
        public TextItalicCommand TextItalicCommand { get; }
        public TextUnderlineCommand TextUnderlineCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propName = "")
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
