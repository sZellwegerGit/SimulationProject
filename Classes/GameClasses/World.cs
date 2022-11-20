using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimulationProject.Classes.Singletons;
using SimulationProject.Classes.GameClasses.Map;

namespace SimulationProject.Classes.GameClasses
{
    internal class World
    {
        public Random rnd = new Random();
        public Tilemap tilemap;

        public float gravity = 0.9f;

        public World(int worldSizeX, int worldSizeY, int tileSize) 
        {
            tilemap = new Tilemap(worldSizeX, worldSizeY, tileSize);
        }

        public Tilemap returnTilemap()
        {
            return tilemap;
        }
        public int tileMapX()
        {
            return tilemap.worldSizeX;
        }
        public int tileMapY()
        {
            return tilemap.worldSizeY;
        }
        public int tileSize()
        {
            return tilemap.tileSize;
        }
        public Tile[,] getMap()
        {
            return tilemap.map;
        }
    }
}
