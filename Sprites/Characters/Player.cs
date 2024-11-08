using Project.Interfaces;
using Project.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Characters
{
    public class Player : Character, IMovable
    {
        public IInputReader InputReader { get; set; }

        public Player(Texture2D texture, IInputReader inputReader) : base(texture)
        {
            animationState.AddAnimation(CharacterAnimation.IDLE, 256, 320, 8, 10, 0, 3, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_RIGHT, 256, 320, 8, 10, 8, 11, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_LEFT, 256, 320, 8, 10, 12, 15, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_UP, 256, 320, 8, 10, 71, 71, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_DOWN, 256, 320, 8, 10, 71, 71, 8);
            animationState.PlayAnimation(CharacterAnimation.IDLE);

            InputReader = inputReader;
            Position = new Vector2(1, 1);
            Speed = new Vector2(1, 1);

        }
        override public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, animationState.GetCurrentFrame().SourceRectangle, Color.White, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 1);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            base.Update(gameTime);
        }

        private void Move()
        {
            MovementManager.Move(this, animationState);
        }
    }
}
