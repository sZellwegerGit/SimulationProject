using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace SimulationProject.Classes.GameClasses
{
    internal class Camera
    {
        private Vector2 offsetPos;
        private float zoom;

        public Camera ()
        {
            this.offsetPos = new Vector2();
            this.zoom = 1f;
        }

        public int getOffsetX ()
        {
            return (int)(offsetPos.X);
        }
        public int getOffsetY()
        {
            return (int)(offsetPos.Y);
        }
        public float getZoom()
        {
            return zoom;
        }

        public void setOffsetX (int newValue)
        {
            offsetPos.X = newValue;
        }
        public void setOffsetY(int newValue)
        {
            offsetPos.Y = newValue;
        }
        public void setZoom(float newValue)
        {
            zoom = newValue;
        }
    }
}
