using Project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Scenes;

namespace Project.Tiles
{
    public class Tile : IMapComponent, ICollidable
    {
        public Vector2 Position { get; }
        public Rectangle SourceRectangle { get; set; }
        public bool IsCollidable { get; set; }

        public Tile(int x, int y)
        {
            Position = new Vector2(x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GameScene.tilesTexture, Position, SourceRectangle, Color.White, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 0);
        }

        public Rectangle GetBoundingBox()
        {
            return IsCollidable ? new Rectangle((int)Position.X, (int)Position.Y, SourceRectangle.Width, SourceRectangle.Height) : Rectangle.Empty;
        }
    }
}
