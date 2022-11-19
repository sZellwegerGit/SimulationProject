using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimulationProject.Classes.GameClasses
{
    // SZ
    // This Class handles all the rendering for the game
    // Entities can be loaded in to the Render obj via the addToRender() function
    // Font/Strings can be loaded in to the Render obj via the addFontToRender() function
    // this obj then converts all Entities to RenderObj objs with only the data necessary
    // before the sprites are rendered on to the screen, they will be...
    // - moved by the Camera offset
    // - sorted by there Y coordinates (unimplemented)
    // - sorted by there Z-Index (unimplemented)
    // - applyed with given shaders (unimplemented)
    // - colored by given color (unimplemented)
    internal class RenderHandler
    {
        // list of RenderObj's / Entities
        private List<RenderObj> finalList;
        // list of Strings
        private List<RenderFont> fontList;

        // ctor
        public RenderHandler()
        {
            finalList = new List<RenderObj>();
            fontList = new List<RenderFont>();
        }

        // clears both lists
        public void resetList()
        {
            finalList.Clear();
            fontList.Clear();
        }

        // adds a Entity into the RenderHandler
        public void addToRenderer(Entity entity, bool centered)
        {
            finalList.Add(new RenderObj(
                entity.getTexture(),
                new Vector2(
                    entity.getRenderPosX(),
                    entity.getRenderPosY()
                ),
                new Vector2(
                    entity.getTextureWidth(),
                    entity.getTextureHeight()
                ),
                null,
                centered
            ));
        }

        // adds a String into the RenderHandler
        public void addFontToRenderer(RenderFont font)
        {
            fontList.Add(font);
        }

        // Y and Z + CAM
        // performs all the additional calculations for Y and Z + CAM
        public void performRenderCalculations(Camera cam)
        {
            for (int n = 0; n < finalList.Count; n++)
            {
                finalList[n].finalPosition.X += cam.getOffsetX();
                finalList[n].finalPosition.Y += cam.getOffsetY();
            } 
        }

        // renders all sprites to the screen
        public void drawAll(SpriteBatch _sB, Camera cam)
        {
            performRenderCalculations(cam);
            _sB.Begin();
            for (int n = 0; n < finalList.Count; n++)
            {
                RenderObj cro = finalList[n];
                _sB.Draw(
                    cro.entityTexture,
                    new Rectangle(
                        (int)cro.finalPosition.X,
                        (int)cro.finalPosition.Y,
                        (int)cro.finalSize.X,
                        (int)cro.finalSize.Y
                    ),
                    Color.White
                ); ;
            }
            for (int n = 0; n < fontList.Count; n++)
            {
                RenderFont crf = fontList[n];
                _sB.DrawString(crf.font, crf.text, crf.position, Color.White);
            }
            _sB.End();
            resetList();
        }
    }

    // RenderObj < Entity
    internal class RenderObj {
        public Texture2D entityTexture;
        public Vector2 finalPosition;
        public Vector2 finalSize;
        public Effect spriteEffect;
        bool centered;

        public RenderObj (Texture2D texture, Vector2 finalPos, Vector2 finalSize, Effect spriteEffect, bool centered)
        {
            this.entityTexture = texture;
            this.finalPosition = finalPos;
            this.finalSize = finalSize;
            this.spriteEffect = spriteEffect;
            this.centered = centered;
        }
    }
    // RenderFont < Strings
    internal class RenderFont
    {
        public SpriteFont font;
        public String text;
        public Vector2 position;
        public Effect spriteEffect;
        public RenderFont(SpriteFont font, String text, Vector2 position, Effect spriteEffect)
        {
            this.font = font;
            this.text = text;
            this.position = position;
            this.spriteEffect = spriteEffect;
        }
    }
}
