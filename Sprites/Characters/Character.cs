using Project.Animations;
using Project.Interfaces;
using Project.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.UI;
using Project.Sprites;
using Project.Enums;

namespace Project.Characters
{
    abstract public class Character : Sprite, ICollidable, IMovable
    {
        public Health Health { get; set; }
        public Vector2 Speed { get; set; }
        public CharacterAnimation Direction { get; set; }

        public Character(Texture2D texture, Texture2D heartTexture): base(texture)
        {
            Health = new Health(3, heartTexture);
        }

        public Rectangle GetBoundingBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
        }
    }
}
