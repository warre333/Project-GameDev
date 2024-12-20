using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Enums;
using Project.Scenes;
using Project.Sprites.Characters.Enemy;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project.Managers
{
    public class EnemyManager
    {
        public List<Enemy> enemies { get; }
        private Texture2D fairyTexture;
        private Texture2D knightTexture;
        private Texture2D wizardTexture;
        private Texture2D heartTexture;
        private Random random = new Random();
        public EnemyManager(Texture2D fairyTexture, Texture2D knightTexture, Texture2D wizardTexture, Texture2D heartTexture)
        {
            enemies = new List<Enemy>();
            this.fairyTexture = fairyTexture;
            this.knightTexture = knightTexture;
            this.wizardTexture = wizardTexture;
            this.heartTexture = heartTexture;
        }

        public void CreateEnemiesForDifficulty(GameDifficulty difficulty)
        {

            enemies.Add(new Fairy(fairyTexture, heartTexture, RandomPosition()));

            for (int i = 0; i < (int)difficulty; i++)
            {
                enemies.Add(new Knight(knightTexture, heartTexture, RandomPosition()));
            }

            for (int i = 0; i < (int)Math.Ceiling((decimal)difficulty / 2); i++)
            {
                enemies.Add(new Wizard(wizardTexture, heartTexture, RandomPosition()));
            }
        }

        private Vector2 RandomPosition()
        {
            int lengthX = GameScene.mapManager.GetCurrentMap().Tiles.GetLength(0);
            int lengthY = GameScene.mapManager.GetCurrentMap().Tiles.GetLength(1);

            float randomX = (float)(random.NextDouble() * (lengthX - 4) * GameScene.tileSize + 2 * GameScene.tileSize);
            float randomY = (float)(random.NextDouble() * (lengthY - 4) * GameScene.tileSize + 2 * GameScene.tileSize);

            return new Vector2(randomX, randomY);
        }

        public void Update(GameTime gameTime)
        {
            OpenVictorySceneWhenEnemiesAreDeath();

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];

                if (enemy.Health.CurrentHealth <= 0)
                {
                    enemies.Remove(enemy);
                }

                switch (enemy)
                {
                    case Wizard wizard:
                        wizard.Update(gameTime);
                        break;
                    default:
                        enemy.Update(gameTime);
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
        
        private void OpenVictorySceneWhenEnemiesAreDeath()
        {
            if (enemies.Count == 0)
            {
                Game1.SceneManager.SetScene(SceneType.Victory);
                Game1.SceneManager.RemoveScene(SceneType.Game);
            }
        }
    }
}
