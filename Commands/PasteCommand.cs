

using CommandPattern.Interfaces;
using CommandPattern.Services;

namespace CommandPattern.Commands
{
    public class PasteCommand : ICommand
    {
        private readonly TextProcessor _processor;
        private readonly int _idx;
        private string _previousText = string.Empty;

        public PasteCommand(TextProcessor processor, int idx)
        {
            _processor = processor;
            _idx = idx;
        }

        public void Execute()
        {
            _previousText = _processor.GetText();
            _processor.Paste(_idx);
        }

        public void Undo() => _processor.SetText(_previousText);
        public void Redo() => Execute();
    }
}
