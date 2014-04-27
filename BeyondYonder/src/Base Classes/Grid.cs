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
        }

        public override void Initialize()
        {
            texture = new Texture2D(_game.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.Red });

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

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = new SpriteBatch(_game.GraphicsDevice);
            spriteBatch.Begin();
            for (float x = -_cols; x < _cols; x++)
            {
                Rectangle rect = new Rectangle((int)(centerX + x * _gridSize), 0, 1, _rows);
                spriteBatch.Draw(texture, rect, Color.Red);
            }
            for (float y = -_rows; y < _rows; y++)
            {
                Rectangle rect = new Rectangle(0, (int)(centerY + y * _gridSize), _cols, 1);
                spriteBatch.Draw(texture, rect, Color.Red);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
