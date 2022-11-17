using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SimulationProject.Classes.Singletons
{
    public static class TextureHolder
    {
        public static Texture2D simpleCircle = null;

        public static Texture2D tile1 = null;

        public static SpriteFont baseFont = null;

        public static void loadAll(Game manager)
        {
            simpleCircle = manager.Content.Load<Texture2D>("Sprites/SimpleCircle");
            tile1 = manager.Content.Load<Texture2D>("Sprites/Tiles/Tile1");
            baseFont = manager.Content.Load<SpriteFont>("baseFont");
        }
    }
}
