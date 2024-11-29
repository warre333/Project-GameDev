using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Managers;
using Project.UI;
using System.Diagnostics;

namespace Project.Sprites.Characters.Enemy
{
    public class Wizard : Enemy
    {
        public Wizard(Texture2D texture, Texture2D heartTexture) : base(texture, heartTexture)
        {
            Position = new Vector2(1, 1);
            Speed = new Vector2(1, 1);
            Health = new Health(2, heartTexture);
            Damage = 1;
        }

        public override void Attack(GameTime gameTime)
        {
            return;
        }

        internal override void Move()
        {
            Vector2 playerLeft = Game1.player.Position - new Vector2(Game1.player.Size.X, 0);
            Vector2 playerRight = Game1.player.Position + new Vector2(Game1.player.Size.X, 0);

            float distanceToLeft = Vector2.Distance(Position, playerLeft);
            float distanceToRight = Vector2.Distance(Position, playerRight);

            Vector2 targetPosition = distanceToLeft < distanceToRight ? playerLeft : playerRight;
            Vector2 direction = targetPosition - Position;

            if (direction.Length() < 100)
            {
                if(direction.Length() < 80)
                {
                    direction = -direction;
                } else
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
    }
}
