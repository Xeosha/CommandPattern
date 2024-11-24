using CommandPatter.Services;
using CommandPattern.Interfaces;

namespace CommandPatter.Commands
{
    public class RedoCommand : ICommand
    {
        private readonly CommandHistory _history;

        public RedoCommand(CommandHistory history)
        {
            _history = history;
        }

        public void Execute()
        {
            _history.Redo();
        }

        public void Undo()
        {
            _history.Undo();
        }
    }
}
