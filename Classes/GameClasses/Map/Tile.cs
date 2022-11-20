using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimulationProject.Classes.Singletons;

namespace SimulationProject.Classes.GameClasses.Map
{
    internal class Tile : Entity
    {
        public List<Entity> cache;
        public String type;

        public Tile(Vector2 pos, Texture2D texture, String type) : base(pos, texture)
        {

        }
    }
}
