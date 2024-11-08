using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Interfaces
{
    public interface IMapComponent
    {
        public Vector2 Position { get; }
        public Rectangle SourceRectangle { get; }
        void Draw(SpriteBatch spriteBatch);

    }
}