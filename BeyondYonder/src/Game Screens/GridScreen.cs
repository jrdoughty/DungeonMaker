using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using BeyondYonder.src.Base_Classes;
using BeyondYonder.src.GameComponents;
using BeyondYonder.src.Controls;

namespace BeyondYonder.src.Game_Screens
{
    public class GridScreen : BaseGameState
    {
        
        #region Field region
        Texture2D backgroundImage;
        public Map map;
        public Grid grid;
        LinkLabel startLabel;
        #endregion
        #region Constructor region
        public GridScreen(Game game, GameStateManager manager)
        : base(game, manager)
        {
        }
        #endregion
        #region XNA Method region
        protected override void LoadContent()
        {
            ContentManager Content = _gameRef.Content;
            backgroundImage = Content.Load<Texture2D>(@"GameScreenBackground.png");

            map = new Map(_gameRef);
            grid = new Grid(_gameRef,28, 21, 25);
            Components.Add(map);
            Components.Add(grid);
            base.LoadContent();

            startLabel = new LinkLabel();
            startLabel.Position = new Vector2(350, 600);
            startLabel.Text = "Pinch to begin";
            startLabel.Color = Color.Black;
            startLabel.TabStop = true;
            startLabel.HasFocus = true;
            startLabel.Selected += new EventHandler(startLabel_Selected);

            _controlManager.Add(startLabel);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _gameRef.SpriteBatch.Begin(); 

            base.Draw(gameTime);

            _gameRef.SpriteBatch.Draw(backgroundImage, _gameRef.ScreenRectangle, Color.Transparent);
            //map.Draw(gameTime);
            grid.Draw(gameTime);
            _controlManager.Draw(_gameRef.SpriteBatch);

            _gameRef.SpriteBatch.End();
        }
        #endregion
        #region Title Screen Methods        
        private void startLabel_Selected(object sender, EventArgs e)     
        {
            _stateManager.PushState(_gameRef.StartMenuScreen);  
        }        
        #endregion
    }
}
