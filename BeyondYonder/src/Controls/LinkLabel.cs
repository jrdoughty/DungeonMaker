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
         Color selectedColor = Color.FromNonPremultiplied(200,200,200,255);
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
             if (HasFocus)    
                 spriteBatch.DrawString(SpriteFont, Text, Position, selectedColor,0,Vector2.Zero,1,SpriteEffects.None,0);
             else
                 spriteBatch.DrawString(SpriteFont, Text, Position, Color, 0, Vector2.Zero, 0.9f, SpriteEffects.None, 0);  
         }
         
         public override void HandleInput(PlayerIndex playerIndex) 
         {
             HasFocus = true;
             if (//trying new format for sake of clarity
                 InputHandler.KeyReleased(Keys.Enter) 
                 ||
                 InputHandler.ButtonReleased(Buttons.A, playerIndex) 
                 ||
                 InputHandler.CurrentGesture.GestureType == GestureType.Hold &&
                 InputHandler.CurrentGesture.Position.X > this.position.X &&
                 InputHandler.CurrentGesture.Position.X < this.position.X + SpriteFont.MeasureString(Text).X &&
                 InputHandler.CurrentGesture.Position.Y > this.position.Y &&
                 InputHandler.CurrentGesture.Position.Y < this.position.Y + SpriteFont.MeasureString(Text).Y 
                 ||
                 InputHandler.CurrentMouseState.LeftButton == ButtonState.Pressed &&
                 InputHandler.CurrentMouseState.X > this.position.X &&
                 InputHandler.CurrentMouseState.X < this.position.X + SpriteFont.MeasureString(Text).X &&
                 InputHandler.CurrentMouseState.Y > this.position.Y &&
                 InputHandler.CurrentMouseState.Y < this.position.Y + SpriteFont.MeasureString(Text).Y
                 ) 
                 base.OnSelected(null);  
         }
         #endregion   
     } 
}
