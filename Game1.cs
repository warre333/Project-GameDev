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
        private Texture2D swordTexture;
        private Texture2D wizardTexture;
        private Texture2D knightTexture;
        private Texture2D fairyTexture;
        private Texture2D healthTexture;
        static public Texture2D tilesTexture;

        static public int tileSize = 16;

        public static Player player;
        private Weapon playerSword;
        private List<Enemy> enemies;
        private Enemy wizard;
        private Enemy knight;
        private Enemy fairy;
        public static MapManager mapManager = new MapManager();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            ScreenManager.Setup(graphics, Window);

            player = new Player(playerTexture, new KeyboardReader(), healthTexture, camera);
            playerSword = new Weapon(swordTexture, player);
            enemies = new List<Enemy>();
            wizard = new Wizard(wizardTexture, healthTexture);
            knight = new Knight(knightTexture, healthTexture);
            fairy = new Fairy(fairyTexture, healthTexture);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            playerTexture = Content.Load<Texture2D>("lancelot_");
            swordTexture = Content.Load<Texture2D>("excalibur_");
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

            // TODO: Add your update logic here

            camera.Follow(player);
            player.Update(gameTime);
            playerSword.Update(gameTime);
            wizard.Update(gameTime);
            knight.Update(gameTime);
            fairy.Update(gameTime);

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
            wizard.Draw(spriteBatch);
            knight.Draw(spriteBatch);
            fairy.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
