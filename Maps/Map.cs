using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Tiles;
using Project.Enums;
using System;

namespace Project.Maps
{
    public class Map
    {
        private Tile[,] tiles;
        private TileFactory tileFactory;
        private int tileSize = 32;

        public Map(int[,] layout)
        {
            this.tileFactory = new TileFactory();
            tiles = new Tile[layout.GetLength(1), layout.GetLength(0)];
            GenerateLevel(layout);
        }

        public void GenerateLevel(int[,] layout)
        {
            for (int x = 0; x < layout.GetLength(1); x++)
            {
                for (int y = 0; y < layout.GetLength(0); y++)
                {
                    TileType type = (TileType)layout[y, x];
                    tiles[x, y] = tileFactory.Add(type, x * tileSize, y * tileSize);
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in tiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }

}
