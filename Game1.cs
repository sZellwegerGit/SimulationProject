using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimulationProject.Classes.Singletons;
using SimulationProject.Classes.GameClasses;
using SimulationProject.Classes;

namespace SimulationProject
{
    // My Simulation Project
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
            gameWorld = new World(Settings.getScreenX(), Settings.getScreenY());
            cam = new Camera();
            render = new RenderHandler();

            base.Initialize();
        }

        // use this.Content to load your game content here
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        // Add your update logic here
        protected override void Update(GameTime gameTime)
        {
            PerformanceClockHolder.updatePerformance.startClock();

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


            render.addTextureToRenderer(TextureHolder.debugBackground, Vector2.Zero, null, false);

            for (int x = 0; x < gameWorld.amountOfTiles; x++)
            {
                for (int y = 0; y < gameWorld.amountOfTiles; y++)
                {
                    Entity tile = gameWorld.debugTiles[x, y];
                    if (tile.offset.Y > 0)
                    {
                        tile.offset.Y -= 12;
                    } else
                    {
                        tile.offset.Y = 0;
                    }

                    render.addToRenderer(gameWorld.debugTiles[x, y], true);
                }
            }

            PerformanceClockHolder.updatePerformance.endClock();

            base.Update(gameTime);
        }

        // RenderHandler is currently VERY VERY SLOW
        // Test : amountOfTiles = 500 > 250000 Tiles

        // Standart Batching
        // - Update Performance: 49ms
        // - Draw Performance: 34ms

        // RenderHandler
        // - Update Performance: 35ms ?
        // - Draw Performance: 940ms

        // Possible Problems
        // - Creation of RenderObj is incredible slow
        //      Solutions
        //      - Create a max of 300000 RenderObj at the beginning and then dont delete them
        //      - Then reuse these objects

        protected override void Draw(GameTime gameTime)
        {
            PerformanceClockHolder.drawPerformance.startClock();

            GraphicsDevice.Clear(Color.Black);

            render.addFontToRenderer(new RenderFont(TextureHolder.baseFont, (gameTime.ElapsedGameTime.TotalMilliseconds).ToString() + " ms", Vector2.Zero, null, Color.White));
            render.addFontToRenderer(new RenderFont(TextureHolder.baseFont, PerformanceClockHolder.updatePerformance.getTextOutput(), new Vector2(10,20), null, PerformanceClockHolder.updatePerformance.color));
            render.addFontToRenderer(new RenderFont(TextureHolder.baseFont, PerformanceClockHolder.drawPerformance.getTextOutput(), new Vector2(10, 40), null, PerformanceClockHolder.drawPerformance.color));

            render.drawAll(_spriteBatch, cam);
            // render.drawFont(_spriteBatch, cam);
            // oldRender();

            PerformanceClockHolder.drawPerformance.endClock();

            base.Draw(gameTime);
        }

        public void oldRender()
        {
            _spriteBatch.Begin();
            for (int x = 0; x < gameWorld.amountOfTiles; x++)
            {
                for (int y = 0; y < gameWorld.amountOfTiles; y++)
                {
                    Entity co = gameWorld.debugTiles[x, y];
                    _spriteBatch.Draw(co.getTexture(), new Rectangle(co.getRenderPosX(), co.getRenderPosY(), co.getTextureWidth(), co.getTextureHeight()), Color.White);
                }
            }
            _spriteBatch.End();
        }
    }
}