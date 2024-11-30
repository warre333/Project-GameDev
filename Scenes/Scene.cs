using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project.Scenes
{
    public class Scene
    {
        protected Game1 game;
        protected bool isLoaded;

        public Scene(Game1 game)
        {
            this.game = game;
            isLoaded = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!isLoaded)
                return;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!isLoaded)
                return;
        }
        public virtual void LoadContent() { isLoaded = true; } 
        public virtual void UnloadContent() { }
    }
}
