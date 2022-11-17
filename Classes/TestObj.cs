using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimulationProject.Classes.GameClasses;
using SimulationProject.Classes.Singletons;

namespace SimulationProject.Classes
{
    internal class TestObj
    {
        public Vector2 position;
        public Vector2 velocity;
        public float scale;
        private Texture2D texture;
        public int width = 0;
        public int height = 0; 
        

        public TestObj(float x, float y, float scale)
        {
            this.position = new Vector2(x, y);
            this.scale = scale;

            Random rnd = new Random();


            this.velocity.X = (float)((rnd.NextDouble() * 40f) - 20f);
        }  

        public void physics(World world)
        {

            if (Math.Abs(velocity.Y) < 0.5)
            {
                velocity.Y = 0;
            }

            if (Math.Abs(velocity.X) < 0.5)
            {
                velocity.X = 0;
            }

            if (position.Y + height > Settings.screenY)
            {
                velocity.Y = +-(float)(velocity.Y * 0.8);
                velocity.X = velocity.X * 0.9f;
                position.Y = Settings.screenY - height;
            }

            if (position.X + width > Settings.screenX)
            {
                velocity.X = +-(float)(velocity.X * 0.8);
                position.X = Settings.screenX - width;
            }

            if (position.X < 0)
            {
                velocity.X = +-(float)(velocity.X * 0.8);
                position.X = 0;
            }

            velocity.Y += world.gravity;

            position += velocity;
        }

        public void setTexture(Texture2D texture)
        {
            this.texture = texture;
            width = (int)(texture.Width * scale);
            height = (int)(texture.Height * scale);
        }
        public Texture2D getTexture()
        {
            return texture;
        }
    }
}
