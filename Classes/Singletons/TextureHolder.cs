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
        public static String spriteFolder = "Sprites";
        public static String backgroundFolder = "Background";
        public static String tilesFolder = "Tiles";

        // overall sprites
        public static Texture2D simpleCircle = null;

        // tiles
        public static Texture2D tile1 = null;

        // backgrounds
        public static Texture2D debugBackground = null;

        // fonts
        public static SpriteFont baseFont = null;

        // load all textures
        public static void loadAll(Game manager)
        {
            simpleCircle = manager.Content.Load<Texture2D>(spriteFolder + "/SimpleCircle");
            tile1 = manager.Content.Load<Texture2D>(spriteFolder + "/" + tilesFolder + "/Tile1");
            baseFont = manager.Content.Load<SpriteFont>("baseFont");
            debugBackground = manager.Content.Load<Texture2D>(spriteFolder + "/" + backgroundFolder + "/DebugBackground");
        }
    }
}
