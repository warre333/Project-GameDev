using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Characters;
using Project.Enums;
using Project.Interfaces;
using Project.Managers;
using Project.Scenes;
using Project.UI;
using System;
using System.Diagnostics;

namespace Project.Sprites.Characters.Enemy
{
    public class Knight : Enemy
    {
        private KnightSword weapon;
        public Knight(Texture2D texture, Texture2D heartTexture, Vector2 position) : base(texture, heartTexture, position)
        {
            //Position = GameScene.mapManager.GetCurrentMap().MidOfMap; 
            Speed = new Vector2(2, 1);
            Health = new Health(3, heartTexture);
            Damage = 1;
            weapon = new KnightSword(GameScene.swordTexture, this);
        }

        public override void Attack(GameTime gameTime)
        {
            weapon.Update(gameTime);
        }

        internal override void Move()
        {
            Vector2 playerLeft = GameScene.player.Position - new Vector2(GameScene.player.Size.X, 0);
            Vector2 playerRight = GameScene.player.Position + new Vector2(GameScene.player.Size.X, 0);

            float distanceToLeft = Vector2.Distance(Position, playerLeft);
            float distanceToRight = Vector2.Distance(Position, playerRight);

            Vector2 targetPosition = distanceToLeft < distanceToRight ? playerLeft : playerRight;

            Random random = new Random();
            float randomOffsetX = (float)(random.NextDouble() - 0.5) * 32;
            float randomOffsetY = (float)(random.NextDouble() - 0.5) * 32;
            targetPosition += new Vector2(randomOffsetX, randomOffsetY);

            Vector2 direction = targetPosition - Position;

            if (direction.Length() < 4)
            {
                direction = Vector2.Zero;
            }

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }


            CharacterAnimation animation;
            MovementManager.Move(this, animationState, direction, out animation);
            Direction = animation;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            weapon.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
