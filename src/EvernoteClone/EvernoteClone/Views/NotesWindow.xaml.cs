using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Speech.Recognition;

namespace EvernoteClone.Views
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        private SpeechRecognitionEngine _recognizer;
        private bool _isRecognizing;

        public NotesWindow()
        {
            var x = SpeechRecognitionEngine.InstalledRecognizers().ToList();
            var c = SpeechRecognitionEngine.InstalledRecognizers().Where(r => r.Culture == System.Threading.Thread.CurrentThread.CurrentCulture).FirstOrDefault();
            _recognizer = new SpeechRecognitionEngine(c);
            _recognizer.SpeechRecognized += (s, e) =>
            {
                tbRichtTextBox.Document.Blocks.Add(new Paragraph(new Run(e.Result.Text)));
            };

            GrammarBuilder gb = new();
            gb.AppendDictation();
            _recognizer.LoadGrammar(new Grammar(gb));
            _recognizer.SetInputToDefaultAudioDevice();

            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void tbRichtTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tr = new TextRange(tbRichtTextBox.Document.ContentStart, tbRichtTextBox.Document.ContentEnd);
            tbStatusBar.Text = $"Document length: {tr.Text.Length}";
        }

        private void btnBold_Click(object sender, RoutedEventArgs e)
        {
            tbRichtTextBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
        }

        private void btnSpeechRecognition_Click(object sender, RoutedEventArgs e)
        {
            if (!_isRecognizing)
            {
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
                _isRecognizing = true;
            }
            else
            {
                _recognizer.RecognizeAsyncStop();
                _isRecognizing = false;
            }
        }
    }
}
