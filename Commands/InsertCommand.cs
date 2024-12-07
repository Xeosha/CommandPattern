

using CommandPattern.Interfaces;
using CommandPattern.Services;

namespace CommandPattern.Commands
{
    public class InsertCommand : ICommand
    {
        private readonly TextProcessor _processor;
        private readonly string _text;
        private readonly int _idx;
        private string _previousText = string.Empty;

        public InsertCommand(TextProcessor processor, string text, int idx)
        {
            _processor = processor;
            _text = text;
            _idx = idx;
        }

        public void Execute()
        {
            _previousText = _processor.GetText();
            _processor.Insert(_text, _idx);
        }

        public void Undo() => _processor.SetText(_previousText);
        public void Redo() => Execute();
    }
}
