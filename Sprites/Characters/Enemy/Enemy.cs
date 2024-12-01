using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Characters;
using Project.Enums;
using Project.Interfaces;
using Project.Managers;
using Project.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Sprites.Characters.Enemy
{
    public abstract class Enemy : Character
    {
        public int Damage { get; set; }

        public Enemy(Texture2D texture, Texture2D heartTexture) : base(texture, heartTexture)
        {
            animationState.AddAnimation(CharacterAnimation.IDLE, 256, 320, 8, 10, 0, 3, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_RIGHT, 256, 320, 8, 10, 8, 11, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_LEFT, 256, 320, 8, 10, 12, 15, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_UP, 256, 320, 8, 10, 71, 71, 8);
            animationState.AddAnimation(CharacterAnimation.WALK_DOWN, 256, 320, 8, 10, 71, 71, 8);
            animationState.PlayAnimation(CharacterAnimation.IDLE);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, animationState.GetCurrentFrame().SourceRectangle, Color.White, 0, new Vector2(0, 0), Size / 16, SpriteEffects.None, 0.9f);
            Health.Draw(spriteBatch, new Vector2(Position.X + 16, Position.Y), 16);

        }

        public void Update(GameTime gameTime)
        {
            Move();
            Attack(gameTime);
            base.Update(gameTime);
        }

        abstract internal void Move();
        abstract public void Attack(GameTime gameTime);
    }
}
