using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project.Scenes;
using System.Collections.Generic;

namespace Project.Managers
{
    public class SceneManager
    {
        public Dictionary<SceneType, Scene> Scenes { get; set; }
        public Scene CurrentScene { get; set; }

        public SceneManager()
        {
            Scenes = new Dictionary<SceneType, Scene>();
        }

        public void AddScene(SceneType sceneType, Scene scene)
        {
            Scenes.Add(sceneType, scene);
        }

        public void SetScene(SceneType sceneType)
        {
            if (CurrentScene != null)
                CurrentScene.UnloadContent();

            CurrentScene = Scenes[sceneType];
            CurrentScene.LoadContent();
        }
        public void Update(GameTime gameTime)
        {
            CurrentScene?.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentScene?.Draw(spriteBatch);
        }
    }
}
