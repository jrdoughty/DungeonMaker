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
    public class TitleScreen : BaseGameState
    {
        #region Field region
        Texture2D backgroundImage;
        LinkLabel startLabel;
        LinkLabel exitLabel;
        #endregion
        #region Constructor region
        public TitleScreen(Game game, GameStateManager manager)
        : base(game, manager)
        {
        }
        #endregion
        #region XNA Method region
        protected override void LoadContent()
        {
            ContentManager Content = _gameRef.Content;
            backgroundImage = Content.Load<Texture2D>(@"Background.png");
            base.LoadContent();

            startLabel = new LinkLabel();
            startLabel.Position = new Vector2(350, 600);
            startLabel.Text = "Press ENTER to begin";
            startLabel.Color = Color.Black;
            startLabel.TabStop = true;
            startLabel.HasFocus = true;
            startLabel.Selected += new EventHandler(startLabel_Selected);

            exitLabel = new LinkLabel();
            exitLabel.Position = new Vector2(350, 630);
            exitLabel.Text = "EXIT";
            exitLabel.Color = Color.Black;
            exitLabel.TabStop = true;
            exitLabel.HasFocus = false;
            exitLabel.Selected += new EventHandler(exitLabel_Selected);

            _controlManager.Add(startLabel);
            _controlManager.Add(exitLabel);
        }
        public override void Update(GameTime gameTime)
        {
            _controlManager.Update(gameTime, PlayerIndex.One);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            _gameRef.SpriteBatch.Begin(); 

            base.Draw(gameTime);

            _gameRef.SpriteBatch.Draw(backgroundImage,
                _gameRef.ScreenRectangle, 
                Color.White);

            _controlManager.Draw(_gameRef.SpriteBatch);

            _gameRef.SpriteBatch.End();
        }
        #endregion

        #region Title Screen Methods
        private void startLabel_Selected(object sender, EventArgs e)
        {
            _stateManager.PushState(_gameRef.GridScreen);
        }
        private void exitLabel_Selected(object sender, EventArgs e)
        {
            _gameRef.Exit();
        }        
        #endregion
    }
}
