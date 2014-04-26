using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Graphics;

using BeyondYonder.src.GameComponents;

namespace BeyondYonder.src.Controls
{
     public class LinkLabel : Control  
     { 
         #region Fields and Properties
         Color selectedColor = Color.Red;
         public Color SelectedColor 
         {   
             get { return selectedColor; }   
             set { selectedColor = value; }  
         }   
         #endregion 
         
         #region Constructor Region   
         public LinkLabel() 
         {   
             TabStop = true;    
             HasFocus = false;   
             Position = Vector2.Zero;
         }   
         #endregion  
         
         #region Abstract Methods    
         public override void Update(GameTime gameTime) 
         {    
         }
         
         public override void Draw(SpriteBatch spriteBatch) 
         { 
             if (hasFocus)    
                 spriteBatch.DrawString(SpriteFont, Text, Position, selectedColor);
             else     
                 spriteBatch.DrawString(SpriteFont, Text, Position, Color);  
         }
         
         public override void HandleInput(PlayerIndex playerIndex) 
         {
             if (!HasFocus)      
                 return;   
             if (//trying new format for sake of clarity
                 InputHandler.KeyReleased(Keys.Enter) ||   
                 InputHandler.ButtonReleased(Buttons.A, playerIndex)||

                 InputHandler.CurrentGesture.GestureType == GestureType.Hold &&
                 InputHandler.CurrentGesture.Position.X > this.position.X &&
                 InputHandler.CurrentGesture.Position.X < this.position.X + this.Size.X &&
                 InputHandler.CurrentGesture.Position.Y > this.position.Y &&
                 InputHandler.CurrentGesture.Position.Y < this.position.Y + this.Size.Y
                 ) 
                 base.OnSelected(null);  
         }
         #endregion   
     } 
}
