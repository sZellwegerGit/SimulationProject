using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimulationProject.Classes.Singletons;

namespace SimulationProject.Classes.GameClasses
{
    internal class World
    {
        public Random rnd = new Random();
        public Entity[,] debugTiles;
        public int worldSizeX = 0;
        public int worldSizeY = 0;
        public int amountOfTiles = 50;

        public float gravity = 0.9f;

        public World(int worldSizeX, int worldSizeY) 
        {
            debugTiles = new Entity[amountOfTiles, amountOfTiles];
            this.worldSizeX = worldSizeX;
            this.worldSizeY = worldSizeY;

            for (int x = 0; x < amountOfTiles; x++)
            {
                for (int y = 0; y < amountOfTiles; y++)
                {
                    Entity newTile = new Entity(new Vector2((x * 16) + 50, (y * 16) + 50), TextureHolder.tile1);
                    newTile.offset.Y = (x + 1) * (y + 3) * 2; 
                    debugTiles[x, y] = newTile;
                }
            }
        }
    }
}
