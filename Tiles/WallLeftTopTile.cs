using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Tiles
{
    public class WallLeftTopTile : Tile
    {
        public WallLeftTopTile(int x, int y) : base(x, y)
        {
            SourceRectangle = new Rectangle(32, 0, 16, 16);
        }
    }
}