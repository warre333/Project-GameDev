using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Tiles;
using Project.Enums;

namespace Project.Maps
{
    public class Map
    {
        public Tile[,] Tiles { get; set; }
        private TileFactory tileFactory;
        private int tileSize = 32;
        public Vector2 MidOfMap { get
            {
                return new Vector2(Tiles.GetLength(0) * tileSize / 2 - 32, Tiles.GetLength(1) * tileSize / 2 - 32);
            }
        }

        public Map(int[,] layout)
        {
            this.tileFactory = new TileFactory();
            Tiles = new Tile[layout.GetLength(1), layout.GetLength(0)];
            GenerateLevel(layout);
        }

        public void GenerateLevel(int[,] layout)
        {
            for (int x = 0; x < layout.GetLength(1); x++)
            {
                for (int y = 0; y < layout.GetLength(0); y++)
                {
                    TileType type = (TileType)layout[y, x];
                    Tiles[x, y] = tileFactory.Add(type, x * tileSize, y * tileSize);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in Tiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }

}
