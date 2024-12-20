using Microsoft.Xna.Framework.Graphics;
using Project.Characters;
using Project.Managers;
using Project.Sprites.Characters.Enemy;
using Project.Sprites;
using System.Collections.Generic;
using Project.Inputs;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Project.Enums;
using System.Security.Cryptography.X509Certificates;

namespace Project.Scenes
{
    public class GameScene: Scene
    {
        Camera camera = new Camera();

        private Texture2D playerTexture;
        private Texture2D wizardTexture;
        private Texture2D knightTexture;
        private Texture2D fairyTexture;
        private Texture2D healthTexture;
        static public Texture2D swordTexture;
        static public Texture2D fireballTexture;
        static public Texture2D tilesTexture;

        static public int tileSize = 32;

        public static Player player;
        private PlayerSword playerSword;
        public static EnemyManager enemyManager;
        public static MapManager mapManager = new MapManager();

        public GameScene(Game1 game, GameDifficulty difficulty) : base(game)
        {
            LoadContent();
            enemyManager = new EnemyManager(fairyTexture, knightTexture, wizardTexture, healthTexture);
            enemyManager.CreateEnemiesForDifficulty(difficulty);

            player = new Player(playerTexture, new KeyboardReader(), healthTexture, camera);
            playerSword = new PlayerSword(swordTexture, player, enemyManager);
        }

        public override void LoadContent()
        {
            playerTexture = game.Content.Load<Texture2D>("lancelot_");
            swordTexture = game.Content.Load<Texture2D>("excalibur_");
            fireballTexture = game.Content.Load<Texture2D>("FB001");
            wizardTexture = game.Content.Load<Texture2D>("merlin_");
            knightTexture = game.Content.Load<Texture2D>("mordred_");
            fairyTexture = game.Content.Load<Texture2D>("morganLeFay_");
            healthTexture = game.Content.Load<Texture2D>("heart");
            tilesTexture = game.Content.Load<Texture2D>("Dungeon tileset");

            mapManager.LoadMap("Content/Maps/Map-1.txt");

            base.LoadContent();
        }

        public override void UnloadContent()
        {
            game.Content.UnloadAssets(["lancelot_", "excalibur_", "FB001", "merlin_", "mordred_", "morganLeFay_", "heart", "Gungeon tileset"]);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            camera.Follow(player);
            player.Update(gameTime);
            playerSword.Update(gameTime);

            enemyManager.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin(
                transformMatrix: camera.Transform,
                sortMode: SpriteSortMode.FrontToBack,
                samplerState: SamplerState.PointClamp
            );

            mapManager.Draw(spriteBatch);
            enemyManager.Draw(spriteBatch);

            player.Draw(spriteBatch);
            playerSword.Draw(spriteBatch);

            spriteBatch.End();
        }

    }
}
