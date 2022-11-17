using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimulationProject.Classes.Singletons;
using SimulationProject.Classes.GameClasses;
using SimulationProject.Classes;

namespace SimulationProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private World gameWorld;
        private Camera cam;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = Settings.screenX;
            _graphics.PreferredBackBufferHeight = Settings.screenY;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // load all textures
            TextureHolder.loadAll(this);
            gameWorld = new World(Settings.screenX, Settings.screenY);
            cam = new Camera();

            base.Initialize();
        }

        // use this.Content to load your game content here
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // holds all textures (is static/singleton)
        }

        // Add your update logic here
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                cam.setOffsetX(cam.getOffsetX() + 10);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                cam.setOffsetX(cam.getOffsetX() - 10);

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                cam.setOffsetY(cam.getOffsetY() + 10);

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                cam.setOffsetY(cam.getOffsetY() - 10);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();

            
             
            for (int x = 0; x < gameWorld.amountOfTiles; x++)
            {
                for (int y = 0; y < gameWorld.amountOfTiles; y++)
                {
                    /*
                     IMPLEMENT A RENDER CLASS WHERE EVERY ENTITY THAT SHOULD GET RENDERED GETS PASSED TO
                     IT NEEDS FUNCTIONS LIKE CAM MOVEMENT, Y-SORT ETC.
                     */

                    Entity currentTile = gameWorld.debugTiles[x, y];
                    currentTile.offset.Y -= 7;
                    if (currentTile.offset.Y < 0)
                    {
                        currentTile.offset.Y = 0;
                    }
                    _spriteBatch.Draw(currentTile.getTexture(), new Rectangle(currentTile.getRenderPosX(), currentTile.getRenderPosY(), currentTile.getTextureWidth(), currentTile.getTextureHeight()), Color.White);
                }
            }

            _spriteBatch.DrawString(TextureHolder.baseFont, (gameTime.ElapsedGameTime.TotalMilliseconds).ToString() + " ms", Vector2.Zero, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}