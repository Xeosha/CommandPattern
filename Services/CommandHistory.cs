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

        public ICommand? Undo()
        {
            if (_currentIndex >= 0)
            {
                var command = _commands[_currentIndex];
                _currentIndex--;
                return command;
            }
            return null;
        }

        public ICommand? Redo()
        {
            if (_currentIndex < _commands.Count - 1)
            {
                _currentIndex++;
                var command = _commands[_currentIndex];
                return command;
            }

            return null;
        }
    }
}
