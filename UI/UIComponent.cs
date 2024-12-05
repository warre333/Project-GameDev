using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.UI
{
    public class UIComponent
    {
        protected Texture2D texture;
        protected Rectangle rectangle;

        public UIComponent(Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
        }
    }
}
