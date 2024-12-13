using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Managers;
using Project.UI;

namespace Project.Scenes
{
    public class StartScene : Scene
    {
        private Texture2D easyPlayButtonTexture;
        private Texture2D normalPlayButtonTexture;
        private Texture2D hardPlayButtonTexture;
        private Texture2D exitButtonTexture;
        private SpriteFont font;

        private StartSceneButton easyPlayButton;
        private StartSceneButton normalPlayButton;
        private StartSceneButton hardPlayButton;
        private StartSceneButton exitButton;

        public StartScene(Game1 game) : base(game) { }

        public override void LoadContent()
        {
            easyPlayButtonTexture = game.Content.Load<Texture2D>("UI/Easy/Easy1");
            normalPlayButtonTexture = game.Content.Load<Texture2D>("UI/Normal/Normal1");
            hardPlayButtonTexture = game.Content.Load<Texture2D>("UI/Hard/Hard1");
            exitButtonTexture = game.Content.Load<Texture2D>("UI/Exit/Quit1");

            CreateComponents();
            base.LoadContent();
        }

        private void CreateComponents()
        {
            easyPlayButton = new DifficultyButton(easyPlayButtonTexture, new Rectangle(ScreenManager.ScreenWidth / 2 - 100, 300, 200, 50), Enums.GameDifficulty.EASY);
            normalPlayButton = new DifficultyButton(normalPlayButtonTexture, new Rectangle(ScreenManager.ScreenWidth / 2 - 100, 370, 200, 50), Enums.GameDifficulty.NORMAL);
            hardPlayButton = new DifficultyButton(hardPlayButtonTexture, new Rectangle(ScreenManager.ScreenWidth / 2 - 100, 440, 200, 50), Enums.GameDifficulty.HARD);
            exitButton = new StartSceneButton(exitButtonTexture, new Rectangle(ScreenManager.ScreenWidth / 2 - 100, 540, 200, 50));
        }

        override public void Update(GameTime gameTime)
        {
            if (!isLoaded) return;

            MouseState mouseState = Mouse.GetState();
            Point mousePosition = new Point(mouseState.X, mouseState.Y);

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (easyPlayButton.Contains(mousePosition))
                {
                    game.SceneManager.AddScene(SceneType.Game, new GameScene(game, Enums.GameDifficulty.EASY));
                    game.SceneManager.SetScene(SceneType.Game);
                }
                else if (normalPlayButton.Contains(mousePosition))
                {
                    game.SceneManager.AddScene(SceneType.Game, new GameScene(game, Enums.GameDifficulty.NORMAL));
                    game.SceneManager.SetScene(SceneType.Game);
                }
                else if (hardPlayButton.Contains(mousePosition))
                {
                    game.SceneManager.AddScene(SceneType.Game, new GameScene(game, Enums.GameDifficulty.HARD));
                    game.SceneManager.SetScene(SceneType.Game);
                }

                if (exitButton.Contains(mousePosition))
                    game.Exit();
            }
        }

        override public void Draw(SpriteBatch spriteBatch)
        {
            if (!isLoaded) return;

            spriteBatch.Begin();

            easyPlayButton.Draw(spriteBatch);
            normalPlayButton.Draw(spriteBatch);
            hardPlayButton.Draw(spriteBatch);
            exitButton.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
