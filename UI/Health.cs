using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Project.UI
{
    public class Health
    {
        private Texture2D heartTexture;
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public Health(int maxHealth, Texture2D heartTexture)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            this.heartTexture = heartTexture;
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth = Math.Max(0, CurrentHealth - amount);
        }

        public void Heal(int amount)
        {
            CurrentHealth = Math.Min(MaxHealth, CurrentHealth + amount);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, int heartSize)
        {
            for (int i = 0; i < CurrentHealth; i++)
            {
                Vector2 heartPosition = new Vector2(
                    position.X + heartSize * i,
                    position.Y
                );

                spriteBatch.Draw(heartTexture, heartPosition, null, Color.White, 0f, Vector2.Zero, new Vector2((float)heartSize / heartTexture.Width), SpriteEffects.None, 0f);
            }
        }
    }
}
