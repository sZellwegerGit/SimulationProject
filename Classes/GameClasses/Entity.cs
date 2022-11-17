using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;

namespace SimulationProject.Classes.GameClasses
{
    // SZ
    // This is the base class for every object in the game
    // It has all the base attr and also functions like "tileStorage"
    internal class Entity
    {

        public Vector2 position;
        public Vector2 offset;
        private Texture2D texture;
        private int textureWidth = 0;
        private int textureHeight = 0;
        private float textureScale = 1.0f;

        // is entity being rendered
        Boolean visible = true;

        // does entity execute updates
        Boolean active = true;

        public Entity(Vector2 pos, Texture2D texture)
        {
            this.position = pos;
            this.setTexture(texture);
        }
        public void setTexture(Texture2D texture)
        {
            this.texture = texture;
            this.textureWidth = (int)(texture.Width * textureScale);
            this.textureHeight = (int)(texture.Height * textureScale);
        }
        public Texture2D getTexture()
        {
            return texture;
        }
        public int getTextureWidth()
        {
            return textureWidth;
        }
        public int getTextureHeight()
        {
            return textureHeight;
        }
        // final position on screen
        public int getRenderPosX ()
        {
            return (int)(position.X + offset.X);
        }
        // final position on screen
        public int getRenderPosY()
        {
            return (int)(position.Y + offset.Y);
        }

    }
}
