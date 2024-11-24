// See https://aka.ms/new-console-template for more information
using CommandPatter.Commands;
using CommandPatter.Services;
using CommandPattern.Services;


var initialText = File.ReadAllText("text.txt");
var processor = new TextProcessor(initialText);

var history = new CommandHistory();

var executor = new CommandExecutor(history, processor);

var parser = new CommandParser(processor, executor, history);
var commands = parser.ParseCommands("commands.txt");

foreach (var command in commands)
{
    executor.ExecuteCommand(command);
}

// Вывод результата
Console.WriteLine("\nFinal text: " + processor.GetText());

