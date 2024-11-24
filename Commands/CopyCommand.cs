using CommandPattern.Interfaces;
using CommandPattern.Services;

namespace CommandPattern.Commands
{
    public class CopyCommand : ICommand
    {
        private readonly TextProcessor _processor;
        private readonly int _startIdx;
        private readonly int _endIdx;

        public CopyCommand(TextProcessor processor, int startIdx, int endIdx)
        {
            _processor = processor;
            _startIdx = startIdx;
            _endIdx = endIdx;
        }

        public void Execute() => _processor.Copy(_startIdx, _endIdx);

        public void Undo() { /* Нет действия для undo */ }
    }
}
