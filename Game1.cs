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
using Project.Scenes;

namespace Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public SceneManager SceneManager { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            ScreenManager.Setup(graphics, Window);

            SceneManager = new SceneManager();

            SceneManager.AddScene(SceneType.MainMenu, new StartScene(this));
            //SceneManager.AddScene(SceneType.Game, new GameScene(this));
            SceneManager.AddScene(SceneType.GameOver, new GameOverScene(this));

            SceneManager.SetScene(SceneType.MainMenu);

            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                SceneManager.CurrentScene.UnloadContent();
                SceneManager.SetScene(SceneType.MainMenu);
                SceneManager.RemoveScene(SceneType.Game);
            }

            SceneManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            SceneManager.Draw(spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
