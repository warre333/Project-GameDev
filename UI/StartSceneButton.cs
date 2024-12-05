using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UI
{
    public class StartSceneButton : UIComponent
    {
        public StartSceneButton(Texture2D texture, Rectangle rectangle) : base(texture, rectangle)
        {
        }

        public bool Contains(Point point)
        {
            return rectangle.Contains(point);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
