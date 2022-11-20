using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationProject.Classes.Singletons;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SimulationProject.Classes.GameClasses.Map
{
    internal class Tilemap
    {
        public Tile[,] map;
        public int worldSizeX;
        public int worldSizeY;
        public int tileSize;

        public Tilemap (int wX, int wY, int tileSize)
        {
            this.worldSizeX= wX;
            this.worldSizeY= wY;
            this.tileSize = tileSize;
        }

        public void createMap ()
        {
            for (int x = 0; x < worldSizeX - 1; x++)
            {
                for (int y = 0; y < worldSizeY - 1; y++)
                {
                    // if type == 1
                    map[x, y] = new Tile(new Vector2(x * worldSizeX * tileSize, y * worldSizeX * tileSize), TextureHolder.tile1, "grass");
                }
            }
        }

        public Tile returnTile(int x, int y)
        {
            if (map == null) { return null; }
            if (isInBounds(x, y))
            {
                return map[x, y];
            }
            return null;
        }

        public bool isInBounds(int x, int y)
        {
            if (x > - 1 && x < worldSizeX)
            {
                if (y > -1 && y < worldSizeY)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
