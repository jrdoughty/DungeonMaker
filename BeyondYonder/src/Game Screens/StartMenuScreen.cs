using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using BeyondYonder.src.Base_Classes;
using BeyondYonder.src.GameComponents;

namespace BeyondYonder.src.Game_Screens
{
    public class StartMenuScreen : BaseGameState
    {
        #region Field region        
        #endregion   
     
        #region Property Region       
        #endregion    
    
        #region Constructor Region       
        public StartMenuScreen(Game game, GameStateManager manager) 
            : base(game, manager) 
        {
        }
        #endregion

        #region XNA Method Region       
        public override void Initialize()    
        {         
            base.Initialize();   
        }      
        
        protected override void LoadContent()  
        {         
            base.LoadContent();   
        }  
   
        public override void Update(GameTime gameTime)
        {
            if (InputHandler.KeyReleased(Keys.Escape))
            {
                Game.Exit();
            }     
            base.Update(gameTime);   
        }   
  
        public override void Draw(GameTime gameTime)  
        {         
            base.Draw(gameTime);   
        }     
        #endregion   
        #region Game State Method Region   
        #endregion
    }
}
