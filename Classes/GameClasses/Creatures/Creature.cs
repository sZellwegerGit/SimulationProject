using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimulationProject.Classes.GameClasses.Creatures
{
    internal class Creature : Entity
    {

        public int maxHealth;
        public int health;
        public int hunger;
        public int thrist;
        public Inventory inventory = new Inventory();
        public int intelligence;
        public bool canSwim;
        public bool isMale;
        public int temperature;
        public Route route;

        public Creature (Vector2 pos, Texture2D texture) : base(pos, texture)
        {

        }
    }
}
