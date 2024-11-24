using CommandPatter.Commands;
using CommandPattern.Commands;
using CommandPattern.Interfaces;
using CommandPattern.Services;

namespace CommandPatter.Services
{
    public class CommandParser
    {
        private readonly TextProcessor _processor;
        private readonly CommandExecutor _executor;
        private readonly CommandHistory _history;

        public CommandParser(TextProcessor processor, CommandExecutor executor, CommandHistory history)
        {
            _processor = processor;
            _executor = executor;
            _history = history;
        }

        public List<ICommand> ParseCommands(string filePath)
        {
            var commands = new List<ICommand>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                ICommand command = null;

                switch (parts[0])
                {
                    case "copy":
                        command = new CopyCommand(_processor, int.Parse(parts[1]), int.Parse(parts[2]));
                        break;

                    case "paste":
                        command = new PasteCommand(_processor, int.Parse(parts[1]));
                        break;

                    case "insert":
                        var insertText = parts[1].Trim('"');
                        command = new InsertCommand(_processor, insertText, int.Parse(parts[2]));
                        break;

                    case "delete":
                        command = new DeleteCommand(_processor, int.Parse(parts[1]), int.Parse(parts[2]));
                        break;

                    case "undo":
                        command = new UndoCommand(_history);
                        break;

                    case "redo":
                        command = new RedoCommand(_history);
                        break;

                    default:
                        throw new InvalidOperationException($"Unknown command: {parts[0]}");
                }

                commands.Add(command);

                // Оборачиваем команду в декоратор для логирования
                //if (command != null)
                //{
                //    command = new CommandLoggerDecorator(command, _processor);
                //    commands.Add(command);
                //}
            }

            return commands;
        }
    }

}
