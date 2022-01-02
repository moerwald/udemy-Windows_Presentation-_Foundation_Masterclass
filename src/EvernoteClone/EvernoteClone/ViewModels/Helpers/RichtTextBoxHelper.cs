using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace EvernoteClone.ViewModels.Helpers
{
    public class RichtTextBoxHelper : DependencyObject
    {
        private static readonly HashSet<Thread> _recursionProtection = new();

        public static FlowDocument GetDocumentXaml(DependencyObject obj)
            =>
            (FlowDocument)obj.GetValue(DocumentXamlProperty);


        public static void SetDocumentXaml(DependencyObject obj, FlowDocument value)
        {
            _recursionProtection.Add(Thread.CurrentThread);
            obj.SetValue(DocumentXamlProperty, value);
            _recursionProtection.Remove(Thread.CurrentThread);
        }

        public static readonly DependencyProperty DocumentXamlProperty = DependencyProperty.RegisterAttached(
            "DocumentXaml",
            typeof(FlowDocument),
            typeof(RichtTextBoxHelper),
            new FrameworkPropertyMetadata()
            {
                BindsTwoWayByDefault = true,
                PropertyChangedCallback =
                 (obj, e) =>
                {
                    if (_recursionProtection.Contains(Thread.CurrentThread))
                        return;
                    var rtb = (RichTextBox)obj;

                    rtb.Document = GetDocumentXaml(rtb);

                    rtb.TextChanged += (s, e) =>
                    {
                        if (s is RichTextBox richTextBox2)
                        {
                            var textRange = new TextRange(richTextBox2.Document.ContentStart, richTextBox2.Document.ContentEnd);
                            System.Diagnostics.Debug.WriteLine($"---- New text: {textRange.Text}");
                            SetDocumentXaml(rtb, richTextBox2.Document);
                        }
                    };

                    rtb.SelectionChanged += (s, e) => rtb.SetValue(TextSelectionProperty, rtb.Selection);
                }
            });


        public static readonly DependencyProperty TextSelectionProperty = DependencyProperty.RegisterAttached(
            "TextSelection",
            typeof(TextRange),
            typeof(RichtTextBoxHelper),
            new FrameworkPropertyMetadata()
            {
                BindsTwoWayByDefault = true,
                PropertyChangedCallback = (obj, e) =>
                {
                }
            }
            );


        public static TextRange GetTextSelection(DependencyObject obj)
        {
            return (TextRange)obj.GetValue(TextSelectionProperty);
        }


        public static void SetTextSelection(DependencyObject obj, TextRange value)
        {
            obj.SetValue(TextSelectionProperty, value);
        }


    }
}
