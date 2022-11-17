using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimulationProject.Classes.Singletons;
using SimulationProject.Classes.GameClasses;
using SimulationProject.Classes;
using SharpDX.Direct2D1.Effects;

namespace SimulationProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private World gameWorld;

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
            // TODO: Add your initialization logic here
            gameWorld = new World(Settings.screenX, Settings.screenY);

            base.Initialize();
        }

        // use this.Content to load your game content here
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // holds all textures (is static/singleton) {good programming ????}
            TextureHolder.simpleCircle = this.Content.Load<Texture2D>("Sprites/SimpleCircle");
            TextureHolder.baseFont = this.Content.Load<SpriteFont>("baseFont");

            for (int i = 0; i < gameWorld.testObjEntities.Count - 1; i++)
            {
                gameWorld.testObjEntities[i].setTexture(TextureHolder.simpleCircle);
            }
        }

        // Add your update logic here
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // c# is fast as fuck boi
            if (gameWorld.testObjEntities.Count < 300000)
            {
                for (int n = 0; n < 750; n++)
                {
                    TestObj temp = gameWorld.generateBall();
                    temp.setTexture(TextureHolder.simpleCircle);
                    gameWorld.testObjEntities.Add(temp);
                }
            }

            base.Update(gameTime);
        }

        // Add your drawing code here
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // physics update and draw will be done in the same loop (reason is obvious)
            for (int i = 0; i < gameWorld.testObjEntities.Count - 1; i++)
            {
                TestObj currentObj = gameWorld.testObjEntities[i];
                gameWorld.testObjEntities[i].physics(gameWorld);
                // texture wont be instantly instanced ???
                if (currentObj.getTexture() != null)
                {
                    _spriteBatch.Draw(
                        currentObj.getTexture(),
                        new Rectangle(
                            (int)currentObj.position.X,
                            (int)currentObj.position.Y,
                            currentObj.width,
                            currentObj.height
                            ),
                    Color.RosyBrown
                    );
                }
            }

            _spriteBatch.DrawString(TextureHolder.baseFont, (gameTime.ElapsedGameTime.TotalMilliseconds).ToString() + " ms", Vector2.Zero, Color.White);
            _spriteBatch.DrawString(TextureHolder.baseFont, "Test Objects: " + (gameWorld.testObjEntities.Count).ToString(), new Vector2(0, 20), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}