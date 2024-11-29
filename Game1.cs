using Project.Characters;
using Project.Inputs;
using Project.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Project.Tiles;
using System.Collections.Generic;
using Project.Sprites.Characters.Enemy;
using Project.Sprites;

namespace Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Camera camera = new Camera();

        private Texture2D playerTexture;
        private Texture2D wizardTexture;
        private Texture2D knightTexture;
        private Texture2D fairyTexture;
        private Texture2D healthTexture;
        static public Texture2D swordTexture;
        static public Texture2D fireballTexture;
        static public Texture2D tilesTexture;

        static public int tileSize = 16;

        public static Player player;
        private PlayerSword playerSword;
        public static List<Enemy> enemies;
        public static MapManager mapManager = new MapManager();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            ScreenManager.Setup(graphics, Window);

            player = new Player(playerTexture, new KeyboardReader(), healthTexture, camera);
            playerSword = new PlayerSword(swordTexture, player);
            enemies = new List<Enemy>();
            enemies.Add(new Wizard(wizardTexture, healthTexture));
            enemies.Add(new Knight(knightTexture, healthTexture));
            enemies.Add(new Fairy(fairyTexture, healthTexture));
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTexture = Content.Load<Texture2D>("lancelot_");
            swordTexture = Content.Load<Texture2D>("excalibur_");
            fireballTexture = Content.Load<Texture2D>("FB001");
            wizardTexture = Content.Load<Texture2D>("merlin_"); 
            knightTexture = Content.Load<Texture2D>("mordred_");
            fairyTexture = Content.Load<Texture2D>("morganLeFay_");
            healthTexture = Content.Load<Texture2D>("heart");
            tilesTexture = Content.Load<Texture2D>("Dungeon tileset");

            mapManager.LoadMap("Content/Maps/Map-1.txt");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            camera.Follow(player);
            player.Update(gameTime);
            playerSword.Update(gameTime);

            foreach (Enemy enemy in enemies)
            {
                switch(enemy)
                {
                    case Wizard wizard:
                        wizard.Update(gameTime);
                        break;
                    case Knight knight:
                        knight.Update(gameTime);
                        break;
                    case Fairy fairy:
                        fairy.Update(gameTime);
                        break;
                    default:
                        enemy.Update(gameTime);
                        break;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(
                transformMatrix: camera.Transform, 
                sortMode: SpriteSortMode.FrontToBack,
                samplerState: SamplerState.PointClamp
            );
            mapManager.Draw(spriteBatch);
                        
            player.Draw(spriteBatch);
            playerSword.Draw(spriteBatch);

            foreach (Enemy enemy in enemies)
            {
                switch (enemy)
                {
                    case Wizard wizard:
                        wizard.Draw(spriteBatch);
                        break;
                    case Knight knight:
                        knight.Draw(spriteBatch);
                        break;
                    case Fairy fairy:
                        fairy.Draw(spriteBatch);
                        break;
                    default:
                        enemy.Draw(spriteBatch);
                        break;
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
