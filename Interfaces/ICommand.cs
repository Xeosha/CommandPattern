
namespace CommandPattern.Interfaces
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();
    }
}
