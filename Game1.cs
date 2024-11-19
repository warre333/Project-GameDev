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
        static public Texture2D tilesTexture;

        static public int tileSize = 16;

        private Player player;
        private List<Enemy> enemies;
        private Enemy enemy;
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
            enemies = new List<Enemy>();
            enemy = new Enemy(wizardTexture, healthTexture);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            playerTexture = Content.Load<Texture2D>("lancelot_");
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
            enemy.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(transformMatrix: camera.Transform, sortMode: SpriteSortMode.FrontToBack);
                        
            player.Draw(spriteBatch);
            mapManager.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
