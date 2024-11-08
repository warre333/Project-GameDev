using Project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Tiles
{
    public class Tile : IMapComponent
    {
        public Vector2 Position { get; }
        public Rectangle SourceRectangle { get; set; }

        public Tile(int x, int y)
        {
            Position = new Vector2(x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.tilesTexture, Position, SourceRectangle, Color.White, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 1);
        }
    }
}
