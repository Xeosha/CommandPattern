using CommandPattern.Interfaces;
using CommandPattern.Services;

namespace CommandPatter.Commands
{
    public class CommandLoggerDecorator : ICommand
    {
        private readonly ICommand _command;
        private readonly TextProcessor _processor;

        public CommandLoggerDecorator(ICommand command, TextProcessor processor)
        {
            _command = command;
            _processor = processor;
        }

        public void Execute()
        {
            LogAction("Execute", _command.Execute);
        }

        public void Undo()
        {
            LogAction("Undo", _command.Undo);
        }

        private void LogAction(string actionName, Action commandAction)
        {
            var commandName = _command.GetType().Name;
            Console.WriteLine($"\n===== {actionName.ToUpper()} START: {commandName} =====");
            Console.WriteLine($"[BEFORE] Text: {_processor.GetText()}");

            try
            {
                commandAction();
                Console.WriteLine($"[AFTER] Text: {_processor.GetText()}");
                Console.WriteLine($"===== {actionName.ToUpper()} END: {commandName} =====\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed during {actionName}: {ex.Message}");
                Console.WriteLine($"===== {actionName.ToUpper()} FAILED: {commandName} =====\n");
            }
        }
    }
}
