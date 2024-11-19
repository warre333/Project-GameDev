using Microsoft.Xna.Framework;

namespace Project.Interfaces
{
    public interface IMovable
    {
        Vector2 Position { get; set; }
        Vector2 Speed { get; set; }
        Vector2 Size { get; }
        IInputReader InputReader { get; set; }

    }
}
