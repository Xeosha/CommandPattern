

using CommandPatter.Commands;
using CommandPatter.Services;
using CommandPattern.Interfaces;

namespace CommandPattern.Services
{
    public class CommandExecutor
    {
        private readonly CommandHistory _history;
        private readonly TextProcessor _textProcessor;

        public CommandExecutor(CommandHistory history, TextProcessor textProcessor)
        {
            _history = history;
            _textProcessor = textProcessor;
        }

        public void ExecuteCommand(ICommand command)
        {
            var loggedCommand = new CommandLoggerDecorator(command, _textProcessor);

            if (command is not UndoCommand && command is not RedoCommand)
            {
                _history.AddCommand(loggedCommand);
            }

            loggedCommand.Execute();
        }
    }
}
