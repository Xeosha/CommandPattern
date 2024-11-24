

using CommandPattern.Interfaces;
using CommandPattern.Services;

namespace CommandPattern.Commands
{
    public class DeleteCommand : ICommand
    {
        private readonly TextProcessor _processor;
        private readonly int _startIdx;
        private readonly int _endIdx;
        private string _previousText = string.Empty;

        public DeleteCommand(TextProcessor processor, int startIdx, int endIdx)
        {
            _processor = processor;
            _startIdx = startIdx;
            _endIdx = endIdx;
        }

        public void Execute()
        {
            _previousText = _processor.GetText();
            _processor.Delete(_startIdx, _endIdx);
        }

        public void Undo() => _processor.SetText(_previousText);
    }
}
