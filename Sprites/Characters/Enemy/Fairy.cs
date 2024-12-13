using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Managers;
using Project.Scenes;
using Project.UI;
using System;

namespace Project.Sprites.Characters.Enemy
{
    public class Fairy : Enemy
    {
        public Fairy(Texture2D texture, Texture2D heartTexture, Vector2 position) : base(texture, heartTexture, position)
        {
            //Position = GameScene.mapManager.GetCurrentMap().MidOfMap;
            Speed = new Vector2(1, 1);
            Health = new Health(1, heartTexture);
            Damage = 0;
        }

        public override void Attack(GameTime gameTime)
        {
            return; // Doet geen damage
        }

        internal override void Move()
        {
            Vector2 direction = Position - GameScene.player.Position;
            Random random = new Random();
            float randomOffsetX = (float)(random.NextDouble() - 0.5) * 32;
            float randomOffsetY = (float)(random.NextDouble() - 0.5) * 32;
            direction += new Vector2(randomOffsetX, randomOffsetY);

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }

            MovementManager.Move(this, animationState, direction);
        }
    }
}
