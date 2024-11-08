using Project.Characters;
using Project.Managers;
using Microsoft.Xna.Framework;

namespace Project
{
    public class Camera
    {
        public Matrix Transform { get; set; }

        public void Follow(Character target)
        {
            var position = Matrix.CreateTranslation(
              -target.Position.X + (ScreenManager.ScreenWidth / 2 - (target.GetCurrentAnimation() == null ? 0 : target.GetCurrentAnimation().SourceRectangle.Width)),
              -target.Position.Y + (ScreenManager.ScreenHeight / 2 - (target.GetCurrentAnimation() == null ? 0 : target.GetCurrentAnimation().SourceRectangle.Height)),
              0
            );

            Transform = position;
        }
    }
}
