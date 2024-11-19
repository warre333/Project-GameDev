using Project.Interfaces;
using Project.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.UI;

namespace Project.Characters
{
    public class Player : Character, IMovable, ICollidable
    {
        public IInputReader InputReader { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Speed { get; set; }
        public Health Health { get; set; }
        private Camera camera;

        public Player(Texture2D texture, IInputReader inputReader, Texture2D heartTexture, Camera camera) : base(texture)
        {
            animationState.AddAnimation(CharacterAnimation.IDLE, 256, 320, 8, 10, 0, 3, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_RIGHT, 256, 320, 8, 10, 8, 11, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_LEFT, 256, 320, 8, 10, 12, 15, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_UP, 256, 320, 8, 10, 71, 71, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_DOWN, 256, 320, 8, 10, 71, 71, 8);
            animationState.PlayAnimation(CharacterAnimation.IDLE);

            InputReader = inputReader;
            Position = new Vector2(1, 1);
            Speed = new Vector2(1, 1) * 10;
            Size = new Vector2(32, 32);
            Health = new Health(10, heartTexture);

            this.camera = camera;
        }
        override public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, animationState.GetCurrentFrame().SourceRectangle, Color.White, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 1);
            Health.Draw(spriteBatch, new Vector2(-camera.Transform.Translation.X + 10, -camera.Transform.Translation.Y + 10), 32); // Heart size: 32x32, spacing: 5 pixels
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

        public Rectangle GetBoundingBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
        }
    }
}
