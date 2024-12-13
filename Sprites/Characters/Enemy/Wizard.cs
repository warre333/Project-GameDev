using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Enums;
using Project.Managers;
using Project.Scenes;
using Project.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Project.Sprites.Characters.Enemy
{
    public class Wizard : Enemy
    {
        public List<Fireball> Fireballs { get; set; }
        private double timer;
        public Wizard(Texture2D texture, Texture2D heartTexture, Vector2 position) : base(texture, heartTexture, position)
        {
            //Position = GameScene.mapManager.GetCurrentMap().MidOfMap; 
            Speed = new Vector2(1, 1);
            Health = new Health(2, heartTexture);
            Damage = 1;
            Fireballs = new List<Fireball>();
        }

        public override void Attack(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= 1)
            {
                Vector2 fireballDirection = GameScene.player.Position - Position;
                fireballDirection.Normalize();

                Vector2 fireballPosition = Position + fireballDirection * 16;


                fireballDirection.Normalize();

                var fireball = new Fireball(GameScene.fireballTexture, fireballPosition, fireballDirection);
                Fireballs.Add(fireball);

                timer = 0;
            }
            
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

            if (direction.Length() < 100)
            {
                if (direction.Length() < 80)
                {
                    direction = -direction;
                }
                else
                {
                    direction = Vector2.Zero;
                }
            }

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }

            MovementManager.Move(this, animationState, direction);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var fireball in Fireballs)
            {
                fireball.Update(gameTime);

                if (fireball.IsActive && fireball.GetBoundingBox().Intersects(GameScene.player.GetBoundingBox()))
                {
                    fireball.OnCollide(GameScene.player);
                    GameScene.player.Health.TakeDamage(fireball.Damage);
                }
            }

            Fireballs.RemoveAll(fb => !fb.IsActive);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var projectile in Fireballs)
            {
                projectile.Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }
    }
}
