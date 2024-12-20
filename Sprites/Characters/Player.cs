using Project.Interfaces;
using Project.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.UI;
using Project.Enums;
using Project.Scenes;

namespace Project.Characters
{
    public class Player : Character, IInputReadable
    {
        public IInputReader InputReader { get; set; }
        public Vector2 Velocity { get; set; }
        private bool invincible = false;
        public bool Invincible { 
            get 
            {
                return invincible;
            } 
            set 
            {
                if(value == true)
                {
                    invincibleTimer = 3;
                }
                invincible = value;
            } 
        }
        private double invincibleTimer;
        private Camera camera;
        private SceneManager sceneManager;

        public Player(Texture2D texture, IInputReader inputReader, Texture2D heartTexture, Camera camera) : base(texture, heartTexture)
        {
            animationState.AddAnimation(CharacterAnimation.IDLE, 256, 320, 8, 10, 0, 3, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_RIGHT, 256, 320, 8, 10, 8, 11, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_LEFT, 256, 320, 8, 10, 12, 15, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_UP, 256, 320, 8, 10, 71, 71, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_DOWN, 256, 320, 8, 10, 71, 71, 8);
            animationState.PlayAnimation(CharacterAnimation.IDLE);

            InputReader = inputReader;
            Position = GameScene.mapManager.GetCurrentMap().MidOfMap; 
            Speed = new Vector2(3, 1.5f);
            Health = new Health(10, heartTexture);
            Velocity = Vector2.Zero;

            this.camera = camera;
        }
        override public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, animationState.GetCurrentFrame().SourceRectangle, Color.White, 0, Vector2.Zero, Size / 16, SpriteEffects.None, 0.9f);
            Health.Draw(spriteBatch, new Vector2(-camera.Transform.Translation.X + 10, -camera.Transform.Translation.Y + 10), 32);
        }

        public void Update(GameTime gameTime)
        {
            CheckDeath();
            Move();
            UpdateInvincibleTimer(gameTime);
            base.Update(gameTime);
        }

        private void Move()
        {
            CharacterAnimation animation;
            MovementManager.Move(this, animationState, InputReader.ReadInput(), out animation);
            Direction = animation;
        }

        private void CheckDeath()
        {
            if (Health.CurrentHealth <= 0)
            {
                sceneManager.SetScene(SceneType.GameOver);
            }
        }

        private void UpdateInvincibleTimer(GameTime gameTime)
        {
            if (invincibleTimer <= 0)
            {
                invincibleTimer = 0;
                Invincible = false;
            } 
            else 
            {
                invincibleTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            }           
        }
    }
}
