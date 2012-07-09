using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;

namespace andrena.Usus_net_EditorAdornment
{
    public class CodeTagsEditorAdornment
    {
        IAdornmentLayer _layer;
        IWpfTextView _view;

        public CodeTagsEditorAdornment(IWpfTextView view)
        {
            _view = view;
            _layer = view.GetAdornmentLayer("Usus.net.EditorAdornment");
            _view.LayoutChanged += OnLayoutChanged;
        }

        private void OnLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            foreach (ITextViewLine line in e.NewOrReformattedLines)
            {
                this.CreateVisuals(line);
            }
        }

        private void CreateVisuals(ITextViewLine line)
        {
            IWpfTextViewLineCollection textViewLines = _view.TextViewLines;
            SnapshotSpan span = new SnapshotSpan(_view.TextSnapshot, Span.FromBounds(line.Start, line.End));
            if (span.GetText().IsMethodDefinition())
                AddAdornmentToMethod(line, textViewLines, span);
        }

        private void AddAdornmentToMethod(ITextViewLine line, IWpfTextViewLineCollection textViewLines, SnapshotSpan span)
        {
            Geometry geometry = textViewLines.GetMarkerGeometry(span);
            if (geometry != null)
            {
                UIElement codeTagElement = GetPositionedCodeTag(line, textViewLines, geometry);
                _layer.AddAdornment(AdornmentPositioningBehavior.TextRelative, span, null, codeTagElement, null);
            }
        }

        private UIElement GetPositionedCodeTag(ITextViewLine line, IWpfTextViewLineCollection textViewLines, Geometry geometry)
        {
            int lineNumber = _view.TextSnapshot.GetLineNumberFromPosition(line.Start.Position) + 1;
            UIElement codeTagElement = CodeTag.ElementAtLine(lineNumber, GetFilename);
            PlaceVisualNextToGeometry(geometry, codeTagElement);
            return codeTagElement;
        }

        private string GetFilename()
        {
            ITextDocument document;
            if (_view == null  || !_view.TextDataModel.DocumentBuffer.Properties.TryGetProperty(typeof(ITextDocument), out document))
                return string.Empty;
            return document != null ? document.FilePath : string.Empty;
        }

        private void PlaceVisualNextToGeometry(Geometry geometry, UIElement codeTagElement)
        {
            Canvas.SetTop(codeTagElement, geometry.Bounds.Top);
            Canvas.SetLeft(codeTagElement, geometry.Bounds.Right + 10);
        }
    }
}
