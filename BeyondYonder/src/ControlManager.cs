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
using BeyondYonder.src.Controls;

namespace BeyondYonder.src
{
    public class ControlManager : List<Control>
    {
        #region Fields and Properties   
        int selectedControl = 0;  
        static SpriteFont spriteFont; 
        
        public static SpriteFont SpriteFont   
        { 
            get { return spriteFont; }    
        }  
        #endregion 
        
        #region Constructors
        public ControlManager(SpriteFont spriteFont)  
            : base() 
        { 
            ControlManager.spriteFont = spriteFont;  
        }       
        
        public ControlManager(SpriteFont spriteFont, int capacity)     
            : base(capacity)   
        {  
            ControlManager.spriteFont = spriteFont;  
        }
        
        public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collection) :    
            base(collection) 
        {
            ControlManager.spriteFont = spriteFont;
        }  
        #endregion   
        
        #region Methods   
        public void Update(GameTime gameTime, PlayerIndex playerIndex)
        {
            if (Count == 0)    
                return; 
            foreach (Control c in this) 
            { 
                if (c.Enabled)
                    c.Update(gameTime);
                
                if (c.HasFocus)  
                    c.HandleInput(playerIndex);
                else if (
                    InputHandler.CurrentMouseState.Y > c.Position.Y &&
                    InputHandler.CurrentMouseState.Y < c.Position.Y + c.SpriteFont.MeasureString(c.Text).Y &&
                    InputHandler.CurrentMouseState.X > c.Position.X &&
                    InputHandler.CurrentMouseState.X < c.Position.X + c.SpriteFont.MeasureString(c.Text).X
                    ||
                    InputHandler.CurrentGesture.Position.X > c.Position.X &&
                     InputHandler.CurrentGesture.Position.X < c.Position.X + SpriteFont.MeasureString(c.Text).X &&
                     InputHandler.CurrentGesture.Position.Y > c.Position.Y &&
                     InputHandler.CurrentGesture.Position.Y < c.Position.Y + SpriteFont.MeasureString(c.Text).Y
                    ){
                        SelectControl(c);
                }
            }
            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickUp, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadUp, playerIndex) ||
                InputHandler.KeyPressed(Keys.Up) ||
                InputHandler.TouchPressed() && InputHandler.CurrentGesture.GestureType == GestureType.Flick && InputHandler.CurrentGesture.Position.Y < InputHandler.LastGesture.Position.Y)
            {
                PreviousControl();
            }
            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickDown, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadDown, playerIndex) ||
                InputHandler.TouchPressed() && InputHandler.CurrentGesture.GestureType == GestureType.Flick && InputHandler.CurrentGesture.Position.Y > InputHandler.LastGesture.Position.Y ||
                InputHandler.KeyPressed(Keys.Down))
            {
                NextControl();
            }
        }
       
        public void Draw(SpriteBatch spriteBatch)    
        {   
            foreach (Control c in this)
            {
                if (c.Visible)    
                    c.Draw(spriteBatch);     
            }    
        }

        public void SelectControl(Control control)
        {
            if (Count == 0)
                return;
            int currentControl = selectedControl;
            this[selectedControl].HasFocus = false;
            do
            {
                selectedControl++;
                if (selectedControl == Count)
                    selectedControl = 0;
                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                    break;
            } while (currentControl != selectedControl);
            this[selectedControl].HasFocus = true;
        }

        public void NextControl()
        {
            if (Count == 0)
                return;
            int currentControl = selectedControl;
            this[selectedControl].HasFocus = false;
            do
            {
                selectedControl++;
                if (selectedControl == Count)
                    selectedControl = 0;
                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                    break;
            } while (currentControl != selectedControl);
            this[selectedControl].HasFocus = true;
        }      

        public void PreviousControl()  
        {
            if (Count == 0)    
                return;  
            int currentControl = selectedControl;   
            this[selectedControl].HasFocus = false;      
            do    
            { 
                selectedControl--;    
                if (selectedControl < 0)     
                    selectedControl = Count - 1;      
                if (this[selectedControl].TabStop && this[selectedControl].Enabled) 
                    break;  
            } while (currentControl != selectedControl);   
            this[selectedControl].HasFocus = true;    
        }        
        #endregion
    }
}
