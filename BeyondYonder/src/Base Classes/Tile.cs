using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BeyondYonder.src.Base_Classes
{
    public class Tile : DrawableGameComponent
    {
        public Vector2 Position;

        private Texture2D _tex;
        private Rectangle _bounds;

        private SpriteBatch spriteBatch;
        private Game _game;

        public Tile(Game game, int height = 38, int width = 38) : base(game)
        {
            _game = game;
            Init(height, width);
        }

        public void Init(int height, int width)
        {
            spriteBatch = new SpriteBatch(_game.GraphicsDevice);

            Position = new Vector2(0, 0);

            _tex = new Texture2D(this.Game.GraphicsDevice, width, height);

            Color[] data = new Color[height * width];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = Color.Chocolate;
            }
            _tex.SetData(data);
            _bounds = new Rectangle(0, 0, width, height);

            Game.Components.Add(this);
        }

        public override void Initialize()
        {
            //Game.Components.Add(this);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            spriteBatch.Begin();
            //spriteBatch.Draw(_tex, _bounds, Color.Transparent);
            spriteBatch.Draw(_tex, Position, Color.White);
            spriteBatch.End();
        }
    }
}
