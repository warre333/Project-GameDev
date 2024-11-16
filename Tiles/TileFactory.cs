using Project.Enums;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Tiles
{
    public class TileFactory
    {
        public Tile Add(TileType type, int x, int y)
        {
            Tile newBlock = null;

            switch (type)
            {
                case TileType.FLOOR:
                    newBlock = new FloorTile(x, y);
                    break;
                case TileType.WALL_TOP:
                    newBlock = new WallTopTile(x, y);
                    break;
                case TileType.WALL_BOTTOM:
                    newBlock = new WallBottomTile(x, y);
                    break;
                case TileType.WALL_SIDE:
                    newBlock = new WallSideTile(x, y);
                    break;
                case TileType.WALL_TOP_LEFT:
                    newBlock = new WallLeftTopTile(x, y);
                    break;
                case TileType.WALL_TOP_RIGHT:
                    newBlock = new WallRightTopTile(x, y);
                    break;
            }

            return newBlock;
        }
    }
}