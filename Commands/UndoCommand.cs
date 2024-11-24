using CommandPatter.Services;
using CommandPattern.Interfaces;
using CommandPattern.Services;

namespace CommandPatter.Commands
{
    public class UndoCommand : ICommand
    {
        private readonly CommandHistory _history;

        public UndoCommand(CommandHistory history)
        {
            _history = history;
        }

        public void Execute()
        {
            _history.Undo();
        }

        public void Undo()
        {
            _history.Redo();
        }
    }
}
