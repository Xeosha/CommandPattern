
using CommandPatter.Commands;
using CommandPatter.Services;
using CommandPattern.Services;


var processor = new TextProcessor();
processor.ParseText("text.txt");  

var history = new CommandHistory();

var executor = new CommandExecutor(history);

var parser = new CommandParser(processor);

var commands = parser.ParseCommands("commands.txt");

foreach (var command in commands)
{
    var loggedCommand = new CommandLoggerDecorator(command, processor);

    executor.SetCommand(loggedCommand);

    if (command is UndoCommand)
    {
        executor.UndoCommand();
    }
    else if (command is RedoCommand)
    {
        executor.RedoCommand();
    } else
    {
        executor.ExecuteCommand();  
    }
}

// Вывод результата
Console.WriteLine("\nFinal text: " + processor.GetText());

