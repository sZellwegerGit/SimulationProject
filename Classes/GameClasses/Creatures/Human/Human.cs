using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimulationProject.Classes.GameClasses.Creatures.Human
{
    internal class Human : Creature
    {
        public int energy;
        public int happy;
        public int reproductionPoints;
        public int money;
        public Dictionary<String, int> skills;

        public Human(Vector2 pos, Texture2D texture) : base(pos, texture)
        {

        }
    }
}
