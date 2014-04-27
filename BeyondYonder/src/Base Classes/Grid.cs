using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BeyondYonder.src.Base_Classes
{
    public class Grid : DrawableGameComponent
    {
        Texture2D texture;

        private Tile[][] _tiles;
        private int _cols;
        private int _rows;
        private int _gridSize;

        float centerX;
        float centerY;

        private Game _game;

        public Grid(Game game, int rows = 28, int cols = 21, int gridSize = 38) : base(game)
        {
            _game = game;
            _rows = rows;
            _cols = cols;
            _gridSize = gridSize;

            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.Black });

            centerX = _game.GraphicsDevice.Viewport.Width / 2;
            centerY = _game.GraphicsDevice.Viewport.Height / 2;

            //_tiles = new Tile[_rows][];
            //for (int row = 0; row < _tiles.Length; row++)
            //{
            //    _tiles[row] = new Tile[_cols];
            //}

            //for (int col = 0; col < _tiles.Length; col++)
            //{
            //    for (int x = 0; x < _tiles[col].Length; x++)
            //    {
            //        _tiles[col][x] = new Tile(_game);
            //    }
            //}
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteBatch.Begin();
            var startX = centerX - (_gridSize * _rows / 2);
            var startY = centerY - (_gridSize * _cols / 2);
            for (float x = 0; x <= _rows; x++)
            {
                Rectangle rect = new Rectangle((int)(x * _gridSize + startX), (int)startY, 1, _gridSize * _cols);
                spriteBatch.Draw(texture, rect, Color.Red);
            }
            for (float y = 0; y <= _cols; y++)
            {
                Rectangle rect = new Rectangle((int)startX, (int)(y * _gridSize + startY), _gridSize * _rows, 1);
                spriteBatch.Draw(texture, rect, Color.Red);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
