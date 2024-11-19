using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Tiles
{
    public class WallSideTile : Tile
    {
        public WallSideTile(int x, int y) : base(x, y)
        {
            SourceRectangle = new Rectangle(32, 16, 16, 16);
            IsCollidable = true;
        }
    }
}