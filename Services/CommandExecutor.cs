

using CommandPatter.Commands;
using CommandPatter.Services;
using CommandPattern.Interfaces;

namespace CommandPattern.Services
{
    public class CommandExecutor
    {
        private ICommand? _command;
        private readonly CommandHistory _history;

        public CommandExecutor(CommandHistory history)
        {
            _history = history;
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            if (_command == null)
                return;

            _history.AddCommand(_command);

            _command.Execute();
        }

        public void UndoCommand()
        {
            var command = _history.Undo();  // Получаем команду из истории для отмены
            command?.Undo();
        }
            
        public void RedoCommand()
        {
            var command = _history.Redo();  // Получаем команду из истории для повтора
            command?.Redo();
        }
    }
}
