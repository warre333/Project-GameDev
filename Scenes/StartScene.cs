using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Scenes;
using Project;

public class StartScreen : Scene
{
    private SpriteFont font;
    private Texture2D background;

    public StartScreen(Game1 game) : base(game)
    {
    }

    public override void LoadContent()
    {
        font = game.Content.Load<SpriteFont>("BokorFont");
        //background = Game.Content.Load<Texture2D>("StartScreenBackground");

        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
        {
            game.SceneManager.SetScene(SceneType.Game);
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        //spriteBatch.Draw(background, Vector2.Zero, Color.White);

        spriteBatch.DrawString(font, "My Awesome Game", new Vector2(200, 150), Color.White);
        spriteBatch.DrawString(font, "Press ENTER to Start", new Vector2(200, 250), Color.White);

        spriteBatch.End();
    }
}
