using Microsoft.Xna.Framework.Graphics;
using Project.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Managers
{
    public class MapManager
    {
        public int MapNumber { get; set; }
        public List<Map> Maps { get; set; }


        public MapManager()
        {
            MapNumber = 1;

            Maps = new List<Map>();
        }

        private int[,] LoadLevelFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int width = lines[0].Length;
            int height = lines.Length;

            int[,] layout = new int[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    layout[y, x] = int.Parse(lines[y][x].ToString());
                }
            }

            return layout;
        }

        public void LoadMap(string filePath)
        {
            int[,] layout = LoadLevelFromFile(filePath);

            Map map = new Map(layout);
            Maps.Add(map);
        }

        public Map GetCurrentMap()
        {
            if(MapNumber > Maps.Count)
                return null;

            return Maps[MapNumber - 1];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map map = Maps[MapNumber - 1];
            map.Draw(spriteBatch);
        }
    }
}
