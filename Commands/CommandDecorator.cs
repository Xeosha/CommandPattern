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

        public ICommand GetCommand { get { return _command; } } 

        public void Execute()
        {
            Console.WriteLine("\t-----Execute-----");
            Console.WriteLine($"-----\tВыполяется: {_command.GetType().Name}\t-----");
            Console.WriteLine($"Текст до: {_processor.GetText()}");
            _command.Execute();
            Console.WriteLine($"Текст после: {_processor.GetText()}");
            Console.WriteLine($"-----\tВыполнено: {_command.GetType().Name}\t-----");
            Console.WriteLine("\t-----EndExecute-----\n");
        }

        public void Undo()
        {
            Console.WriteLine("\t-----Undo-----");
            Console.WriteLine($"-----\tВыполяется: {_command.GetType().Name}\t-----");
            Console.WriteLine($"Текст до: {_processor.GetText()}");
            _command.Undo();
            Console.WriteLine($"Текст после:: {_processor.GetText()}");
            Console.WriteLine($"-----\tВыполнено: {_command.GetType().Name}\t-----");
            Console.WriteLine("\t-----EndUndo-----\n");
        }
    }
}
