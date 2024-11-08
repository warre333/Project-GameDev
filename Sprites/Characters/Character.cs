using Project.Animations;
using Project.Interfaces;
using Project.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Characters
{
    abstract public class Character : IGameObject
    {
        protected AnimationState animationState;
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }

        public Character(Texture2D texture)
        {
            animationState = new AnimationState();
            Texture = texture;
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
    }
}
