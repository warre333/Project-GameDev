using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UI
{
    public class DifficultyButton : StartSceneButton
    {
        public DifficultyButton(Texture2D texture, Rectangle rectangle, GameDifficulty difficulty) : base(texture, rectangle)
        {

        }
    }
}
