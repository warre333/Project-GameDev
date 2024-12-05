using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Interfaces;
using System;

namespace Project.Sprites
{
    public class Fireball : Sprite, ICollidable
    {
        public Vector2 Direction { get; set; } 
        public float Speed { get; set; }      
        public int Damage { get; set; }
        public bool IsActive { get; set; }

        private float rotation;

        public Fireball(Texture2D texture, Vector2 position, Vector2 direction) : base(texture)
        {
            Position = position;
            Direction = direction;
            Speed = 200;
            Damage = 1;
            IsActive = true; 
            
            rotation = (float)Math.Atan2(direction.Y, direction.X);

            Size = new Vector2(Texture.Bounds.Width / 3f, Texture.Bounds.Width / 3f);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
                spriteBatch.Draw(Texture, Position, null, Color.White, rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), Size / 16, SpriteEffects.None, 0.8f);
        }

        public void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public Rectangle GetBoundingBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }

        public void OnCollide(ICollidable collidable)
        {
            IsActive = false;
        }
    }
}
