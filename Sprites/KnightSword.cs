﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Characters;
using Project.Enums;
using Project.Inputs;
using Project.Interfaces;
using Project.Scenes;
using Project.Sprites.Characters.Enemy;
using System.Diagnostics;

namespace Project.Sprites
{
    public class KnightSword : Weapon
    {
        public KnightSword(Texture2D texture, Character owner) : base(texture, owner)
        {
            animationState.AddAnimation(CharacterAnimation.IDLE, 128, 128, 4, 4, 0, 0, 1);
            animationState.AddAnimation(CharacterAnimation.ATTACKING_RIGHT, 128, 128, 4, 4, 4, 7, 4);
            animationState.AddAnimation(CharacterAnimation.ATTACKING_LEFT, 128, 128, 4, 4, 8, 11, 4);
            animationState.PlayAnimation(CharacterAnimation.IDLE);

            Damage = 1;
            Size = new Vector2(24, 24);
        }

        public void Update(GameTime gameTime)
        {
            if (Vector2.Distance(GameScene.player.Position, Owner.Position) < 40 || isVisible)
            {
                AttackAnimation(gameTime);

                if(!hasAttacked)
                    DealDamage();
            }

            base.Update(gameTime);
        }

        override public void DealDamage()
        {
            hasAttacked = true;

            if (GetBoundingBox().Intersects(GameScene.player.GetBoundingBox()))
            {
                if (!GameScene.player.Invincible)
                {
                    GameScene.player.Health.TakeDamage(Damage);
                    GameScene.player.Invincible = true;
                }
            }
        }

        override protected void Follow()
        {
            if (Owner.Direction == CharacterAnimation.WALK_LEFT)
            {
                Position = Owner.Position + new Vector2(-22, 36);
            }
            else
            {
                Position = Owner.Position + new Vector2(54, 0);
            }
        }
    }
}
