using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Characters;
using Project.Enums;
using Project.Inputs;
using Project.Interfaces;
using Project.Sprites.Characters.Enemy;

namespace Project.Sprites
{
    public abstract class Weapon : Sprite, IWeapon
    {
        public int Damage { get; set; }
        public Character Owner { get; set; }

        protected bool isVisible;
        protected double attackTimer;
        protected double attackTime;
        protected bool hasAttacked;

        public Weapon(Texture2D texture, Character owner) : base(texture)
        {
            Owner = owner;
            Position = Owner.Position;
            isVisible = false;
            attackTimer = 0;
            attackTime = 1;
            hasAttacked = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
                spriteBatch.Draw(Texture, Position, animationState.GetCurrentFrame().SourceRectangle, Color.White, Owner.Direction == CharacterAnimation.WALK_LEFT ? -MathHelper.PiOver4 : MathHelper.PiOver4, new Vector2(0), Size / 16, SpriteEffects.None, 0.89f);
        }

        public void Update(GameTime gameTime)
        {
            Follow();

            base.Update(gameTime);
        }

        public Rectangle GetBoundingBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }

        protected virtual void Follow()
        {
            if (Owner.Direction == CharacterAnimation.WALK_LEFT)
            {
                Position = Owner.Position + new Vector2(-36, 32);
            }
            else
            {
                Position = Owner.Position + new Vector2(54, -12);
            }
        }

        private CharacterAnimation GetAttackingDirection()
        {
            return Owner.Direction == CharacterAnimation.WALK_LEFT ? CharacterAnimation.ATTACKING_LEFT : CharacterAnimation.ATTACKING_RIGHT;
        }

        protected void AttackAnimation(GameTime gameTime)
        {
            if (attackTimer == 0)
            {

                isVisible = true;
                animationState.PlayAnimation(GetAttackingDirection());
                attackTimer += gameTime.ElapsedGameTime.TotalSeconds;
                hasAttacked = false;
            }
            else
            {
                attackTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (attackTimer >= attackTime)
                {
                    attackTimer = 0;
                    isVisible = false;
                    animationState.PlayAnimation(CharacterAnimation.IDLE);
                }
            }
        }

        public abstract void DealDamage();

    }
}
