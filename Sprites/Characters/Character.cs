using Project.Animations;
using Project.Interfaces;
using Project.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.UI;

namespace Project.Characters
{
    abstract public class Character : IGameObject, ICollidable
    {
        protected AnimationState animationState;
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Health Health { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Size { get; set; }

        public Character(Texture2D texture, Texture2D heartTexture)
        {
            animationState = new AnimationState();
            Texture = texture;
            Health = new Health(3, heartTexture);
        }

        abstract public void Draw(SpriteBatch spriteBatch);

        public void Update(GameTime gameTime)
        {
            animationState.Update(gameTime);
        }

        public AnimationFrame GetCurrentAnimation()
        {
            return animationState.GetCurrentFrame() == null ? null : animationState.GetCurrentFrame();
        }

        public Rectangle GetBoundingBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
        }
    }
}
