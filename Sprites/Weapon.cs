using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Characters;
using Project.Enums;
using Project.Inputs;
using Project.Interfaces;
using System.Diagnostics;

namespace Project.Sprites
{
    public class Weapon : Sprite, ICollidable, IInputReadable
    {
        public int Damage { get; set; }
        public Character Owner { get; set; }
        public IInputReader InputReader { get; set; }

        private bool isVisible;
        private double attackTimer;
        private double attackTime;

        public Weapon(Texture2D texture, Character owner) : base(texture)
        {
            animationState.AddAnimation(CharacterAnimation.IDLE, 128, 128, 4, 4, 0, 0, 1);
            animationState.AddAnimation(CharacterAnimation.ATTACKING_RIGHT, 128, 128, 4, 4, 4, 7, 4);
            animationState.AddAnimation(CharacterAnimation.ATTACKING_LEFT, 128, 128, 4, 4, 8, 11, 4);
            animationState.PlayAnimation(CharacterAnimation.IDLE);

            Owner = owner;
            Position = Owner.Position;
            Damage = 1;
            isVisible = false;
            attackTimer = 0;
            attackTime = 1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
                spriteBatch.Draw(Texture, Position, animationState.GetCurrentFrame().SourceRectangle, Color.White, Owner.Direction == CharacterAnimation.WALK_LEFT ? -MathHelper.PiOver4 : MathHelper.PiOver4, new Vector2(0), 2f, SpriteEffects.None, 0.89f);
        }

        public void Update(GameTime gameTime)
        {
            Follow();

            if (MouseReader.IsLeftMouseClicked() || isVisible)
            {
                if (attackTimer == 0)
                {

                    isVisible = true;
                    animationState.PlayAnimation(GetAttackingDirection());
                    attackTimer += gameTime.ElapsedGameTime.TotalSeconds;
                } else
                {
                    attackTimer += gameTime.ElapsedGameTime.TotalSeconds;
                    if(attackTimer >= attackTime)
                    {
                        attackTimer = 0;
                        isVisible = false;
                        animationState.PlayAnimation(CharacterAnimation.IDLE);
                    } 
                }
                
            }

            base.Update(gameTime);
        }

        public Rectangle GetBoundingBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
        }

        private void Follow()
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
    }
}
