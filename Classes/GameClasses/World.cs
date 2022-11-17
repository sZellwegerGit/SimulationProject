using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationProject.Classes.GameClasses
{
    internal class World
    {
        public Random rnd = new Random();
        public List<TestObj> testObjEntities;
        public int worldSizeX = 0;
        public int worldSizeY = 0;

        public float gravity = 0.9f;

        public World(int worldSizeX, int worldSizeY) 
        { 
            testObjEntities = new List<TestObj>();
            this.worldSizeX = worldSizeX;
            this.worldSizeY = worldSizeY;

            for (int n = 0; n < 200; n++)
            {
                testObjEntities.Add(generateBall());
            }
        }

        public TestObj generateBall()
        {
            return new TestObj(
                (float)rnd.NextDouble() * worldSizeX,
                (float)rnd.NextDouble() * worldSizeY,
                (float)rnd.NextDouble() * 2f);
        }
    }
}
