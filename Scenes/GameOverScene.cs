using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Managers;
using Project.UI;

namespace Project.Scenes
{
    public class GameOverScene : Scene
    {
        private SpriteFont font;

        public GameOverScene(Game1 game) : base(game) { }

        public override void LoadContent()
        {
            font = game.Content.Load<SpriteFont>("SigmarFont");

            base.LoadContent();
        }

        override public void Update(GameTime gameTime)
        {
        }

        override public void Draw(SpriteBatch spriteBatch)
        {
            if (!isLoaded) return;

            spriteBatch.Begin();

            spriteBatch.DrawString(font, "Game Over", new Vector2(ScreenManager.ScreenWidth / 2 - 100, ScreenManager.ScreenHeight / 2 - 50), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 1);

            spriteBatch.End();
        }
    }
}
