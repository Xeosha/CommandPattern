using CommandPattern.Interfaces;

namespace CommandPatter.Services
{
    public class CommandHistory
    {
        private readonly List<ICommand> _commands = new(); // Список всех команд
        private int _currentIndex = -1; // Индекс последней выполненной команды

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
            _currentIndex++;
        }

        public void Undo()
        {
            if (_currentIndex >= 0)
            {
                var command = _commands[_currentIndex];
                command.Undo();
                _currentIndex--;
            }
        }

        public void Redo()
        {
            if (_currentIndex < _commands.Count - 1)
            {
                _currentIndex++;
                var command = _commands[_currentIndex];
                command.Execute();
            }
        }
    }
}
