﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Characters;
using Project.Enums;
using Project.Inputs;
using Project.Interfaces;
using Project.Scenes;
using Project.Sprites.Characters.Enemy;

namespace Project.Sprites
{
    public class PlayerSword : Weapon
    {
        public IInputReader InputReader { get; set; }

        public PlayerSword(Texture2D texture, Character owner) : base(texture, owner)
        {
            animationState.AddAnimation(CharacterAnimation.IDLE, 128, 128, 4, 4, 0, 0, 1);
            animationState.AddAnimation(CharacterAnimation.ATTACKING_RIGHT, 128, 128, 4, 4, 4, 7, 4);
            animationState.AddAnimation(CharacterAnimation.ATTACKING_LEFT, 128, 128, 4, 4, 8, 11, 4);
            animationState.PlayAnimation(CharacterAnimation.IDLE);

            Damage = 1;
        }

        public void Update(GameTime gameTime)
        {
            if (MouseReader.IsLeftMouseClicked() || isVisible)
            {
                AttackAnimation(gameTime);

                if(!hasAttacked)
                    DealDamage();
            }

            base.Update(gameTime);
        }

        override protected void DealDamage()
        {
            hasAttacked = true;
            foreach (Enemy enemy in GameScene.enemies)
            {
                if (GetBoundingBox().Intersects(enemy.GetBoundingBox()))
                {
                    enemy.Health.TakeDamage(Damage);
                }
            }
        }
    }
}
