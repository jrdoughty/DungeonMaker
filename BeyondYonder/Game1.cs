using BeyondYonder.src.GameComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


using BeyondYonder.src.Game_Screens;
using BeyondYonder.src;
using BeyondYonder.src.Base_Classes;

namespace BeyondYonder
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        #region Variables Region
        GraphicsDeviceManager _graphics;
        public SpriteBatch SpriteBatch;
        
        GameStateManager _gameStateManager;
        public TitleScreen TitleScreen;
        public StartMenuScreen StartMenuScreen;
        public GridScreen GridScreen; 

        const int screenWidth = 1366;
        const int screenHeight = 768;

        public readonly Rectangle ScreenRectangle;

        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.IsFullScreen = false;
            ScreenRectangle = new Rectangle(
                 0,
                 0,
                 screenWidth,
                 screenHeight);

            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";

            Components.Add(new InputHandler(this));

            _gameStateManager = new GameStateManager(this);
            Components.Add(_gameStateManager);
            //TitleScreen = new TitleScreen(this, _gameStateManager);
            //StartMenuScreen = new StartMenuScreen(this, _gameStateManager);
            GridScreen = new GridScreen(this, _gameStateManager);
            //_gameStateManager.ChangeState(TitleScreen);
            _gameStateManager.ChangeState(GridScreen);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            //map.LoadMap();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
        }
    }
}
