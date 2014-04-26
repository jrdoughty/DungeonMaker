using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeyondYonder.src.GameComponents;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Content; 
using Microsoft.Xna.Framework.Graphics;

namespace BeyondYonder.src.Base_Classes
{
    public abstract partial class BaseGameState : GameState
    {
        #region Fields region
        protected Game1 _gameRef;

        protected ControlManager _controlManager;

        protected PlayerIndex playerIndexInControl;
        #endregion
        #region Properties region
        #endregion
        #region Constructor Region
        public BaseGameState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            _gameRef = (Game1)game;
        }
        #endregion

        #region XNA Method Region

        protected override void LoadContent() 
        { 
            ContentManager Content = Game.Content; 
            SpriteFont menuFont = Content.Load<SpriteFont>(@"Fonts\Segue");
            _controlManager = new ControlManager(menuFont); 
            base.LoadContent(); 
        }   
        
        public override void Update(GameTime gameTime) 
        {
            base.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime) 
        {
            base.Draw(gameTime);
        }

        #endregion
    }

}
