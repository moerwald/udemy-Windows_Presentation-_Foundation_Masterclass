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
using System.Windows.Controls.Primitives;

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

            InitializeComponent();
            InitSpeechRecognizer();

            // locals
            void InitSpeechRecognizer()
            {
                var availableRecognizers = SpeechRecognitionEngine.InstalledRecognizers().ToList();
                btnSpeechRecognition.IsEnabled = false;
                if (availableRecognizers.Any())
                {
                    var cc = System.Globalization.CultureInfo.GetCultureInfo("en-US");
                    var installedRecognizer = SpeechRecognitionEngine.InstalledRecognizers().Where(r => r.Culture.IetfLanguageTag == cc.IetfLanguageTag).FirstOrDefault();
                    if (installedRecognizer is not null)
                    {
                        _recognizer = new SpeechRecognitionEngine(installedRecognizer);
                        _recognizer.SpeechRecognized += (s, e) =>
                        {
                            tbRichtTextBox.Document.Blocks.Add(new Paragraph(new Run(e.Result.Text)));
                        };

                        GrammarBuilder gb = new();
                        gb.AppendDictation();
                        _recognizer.LoadGrammar(new Grammar(gb));
                        _recognizer.SetInputToDefaultAudioDevice();
                        btnSpeechRecognition.IsEnabled = true;
                    }
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSpeechRecognition_Click(object sender, RoutedEventArgs e)
        {
            if (!_isRecognizing)
            {
                _recognizer?.RecognizeAsync(RecognizeMode.Multiple);
                _isRecognizing = true;
            }
            else
            {
                _recognizer?.RecognizeAsyncStop();
                _isRecognizing = false;
            }
        }

    }
}
