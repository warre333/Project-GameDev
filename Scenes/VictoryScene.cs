using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Scenes
{
    public class VictoryScene : Scene
    {
        private SpriteFont font;

        public VictoryScene(Game1 game) : base(game) { }

        public override void LoadContent()
        {
            font = game.Content.Load<SpriteFont>("SigmarFont");

            base.LoadContent();
        }

        override public void Draw(SpriteBatch spriteBatch)
        {
            if (!isLoaded) return;

            spriteBatch.Begin();

            spriteBatch.DrawString(font, "Victory", new Vector2(ScreenManager.ScreenWidth / 2 - 100, ScreenManager.ScreenHeight / 2 - 50), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 1);

            spriteBatch.End();
        }
    }
}
