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
            float scale = 2f;

            AnimationFrame currentFrame = animationState.GetCurrentFrame();

            int width = (int)(currentFrame.SourceRectangle.Width * scale);
            int height = (int)(currentFrame.SourceRectangle.Height * scale);

            int offsetX = 8;
            int offsetY = 16;

            return new Rectangle(
                (int)Position.X + offsetX,
                (int)Position.Y + offsetY,
                width - 24,
                height -20
            );
        }
    }
}
