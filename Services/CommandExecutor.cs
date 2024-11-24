

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
            if (command is not UndoCommand && command is not RedoCommand)
            {
                _history.AddCommand(command);
            }

            Console.WriteLine(command.GetType().Name);
            Console.WriteLine($"ДО: {_textProcessor}");

            command.Execute();

            Console.WriteLine($"ПОСЛЕ: {_textProcessor}");
        }

        public void Undo()
        {
            _history.Undo();
        }

        public void Redo()
        {
            _history.Redo();
        }
    }
}
