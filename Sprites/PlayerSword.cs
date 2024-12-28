using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Characters;
using Project.Enums;
using Project.Inputs;
using Project.Interfaces;
using Project.Managers;
using Project.Sprites.Characters.Enemy;

namespace Project.Sprites
{
    public class PlayerSword : Weapon
    {
        private EnemyManager enemyManager;

        public PlayerSword(Texture2D texture, Character owner, EnemyManager enemyManager) : base(texture, owner)
        {
            animationState.AddAnimation(CharacterAnimation.IDLE, 128, 128, 4, 4, 0, 0, 1);
            animationState.AddAnimation(CharacterAnimation.ATTACKING_RIGHT, 128, 128, 4, 4, 4, 7, 4);
            animationState.AddAnimation(CharacterAnimation.ATTACKING_LEFT, 128, 128, 4, 4, 8, 11, 4);
            animationState.PlayAnimation(CharacterAnimation.IDLE);

            Damage = 1;

            this.enemyManager = enemyManager;
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

        override public void DealDamage()
        {
            hasAttacked = true;
            foreach (Enemy enemy in enemyManager.enemies)
            {
                if (GetBoundingBox().Intersects(enemy.GetBoundingBox()))
                {
                    enemy.Health.TakeDamage(Damage);
                }
            }
        }
    }
}
