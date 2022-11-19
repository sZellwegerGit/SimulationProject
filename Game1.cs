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
        private RenderHandler render;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = Settings.getScreenX();
            _graphics.PreferredBackBufferHeight = Settings.getScreenY();
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // load all textures
            TextureHolder.loadAll(this);
            // gameWorld = new World(Settings.getScreenX(), Settings.getScreenY());
            gameWorld = new World(Settings.getScreenX(), Settings.getScreenY());
            cam = new Camera();
            render = new RenderHandler();

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


            for (int x = 0; x < gameWorld.amountOfTiles; x++)
            {
                for (int y = 0; y < gameWorld.amountOfTiles; y++)
                {
                    Entity tile = gameWorld.debugTiles[x, y];
                    if (tile.offset.Y > 0)
                    {
                        tile.offset.Y -= 5;
                    } else
                    {
                        tile.offset.Y = 0;
                    }
                    
                    render.addToRenderer(gameWorld.debugTiles[x, y], false);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            render.addFontToRenderer(new RenderFont(TextureHolder.baseFont, (gameTime.ElapsedGameTime.TotalMilliseconds).ToString() + " ms", Vector2.Zero, null));

            render.drawAll(_spriteBatch, cam);

            base.Draw(gameTime);
        }
    }
}