using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;


namespace BeyondYonder.src.GameComponents
{
    class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        #region Field Regions
        #region Keyboard Field Region
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;
        #endregion

        #region Game Pad Field Region
        static GamePadState[] gamePadStates;
        static GamePadState[] lastGamePadStates;
        #endregion

        #region Touch Field Region
        static TouchCollection touchState;
        static TouchCollection lastTouchState;
        static GestureSample gesture;
        static GestureSample lastGesture;
        #endregion

        #region Mouse Field Region
        static MouseState mouseState;
        static MouseState lastMouseState;
        private int maxFramesSinceMouseMovement = 40;
        static int framesSinceMouseMove;
        #endregion
        #endregion
        #region Static Get Property Region
        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }

        public static GamePadState[] GamePadStates
        {
            get { return gamePadStates; }
        }

        public static GamePadState[] LastGamePadStates
        {
            get { return lastGamePadStates; }
        }

        public static TouchCollection CurrentTouchState
        {
            get { return touchState; }
        }

        public static TouchCollection LastTouchState
        {
            get { return lastTouchState; }
        }

        public static GestureSample CurrentGesture
        {
            get { return gesture; }
        }

        public static GestureSample LastGesture
        {
            get { return lastGesture; }
        }

        public static MouseState CurrentMouseState
        {
            get { return mouseState; }
        }

        public static MouseState LastMouseState
        {
            get { return lastMouseState; }
        }
        #endregion
        
        #region Constructor Region
        public InputHandler(Game game)
            : base(game)
        {
            keyboardState = Keyboard.GetState();
            framesSinceMouseMove = maxFramesSinceMouseMovement;
            gamePadStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];

            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
                gamePadStates[(int)index] = GamePad.GetState(index);


            touchState = TouchPanel.GetState();
        }
        #endregion
        #region XNA methods 
        //overriding in case of wanting to add functionality
        public override void Initialize()
        {
            TouchPanel.EnabledGestures = GestureType.Hold |
                GestureType.Tap |
                GestureType.DoubleTap |
                GestureType.FreeDrag |
                GestureType.Flick |
                GestureType.Pinch;
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            lastTouchState = touchState;
            touchState = TouchPanel.GetState();
            
            lastGamePadStates = gamePadStates;
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
                gamePadStates[(int)index] = GamePad.GetState(index);

            lastMouseState = mouseState;
            mouseState = Mouse.GetState();
            if (TouchPanel.IsGestureAvailable)//ReadGesture breaks without this check first
            {
                lastGesture = gesture;
                gesture = TouchPanel.ReadGesture();
            }
            if (
                mouseState.X != lastMouseState.X
                ||
                mouseState.Y != lastMouseState.Y
                ||
                mouseState.LeftButton == ButtonState.Pressed
                ||
                mouseState.RightButton == ButtonState.Pressed
                )
            {
                framesSinceMouseMove = 0;
                Game.IsMouseVisible = true;
            }
            else
            {
                framesSinceMouseMove++;
                if (framesSinceMouseMove > maxFramesSinceMouseMovement)
                    Game.IsMouseVisible = false;
            }
                                   
            base.Update(gameTime);
        }
        #endregion
        
        #region General Method Region
        public static void Flush()
        {
            lastKeyboardState = keyboardState;
            lastGamePadStates = gamePadStates;
            lastTouchState = touchState;
        }
        #endregion

        #region Keyboard Region
        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) &&
            lastKeyboardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) &&
            lastKeyboardState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }
        #endregion

        #region GamePad Region
        public static bool ButtonReleased(Buttons button, PlayerIndex playerIndex)
        {
            return gamePadStates[(int)playerIndex].IsButtonUp(button) &&
            lastGamePadStates[(int)playerIndex].IsButtonDown(button);
        }

        public static bool ButtonPressed(Buttons button, PlayerIndex playerIndex)
        {
            return gamePadStates[(int)playerIndex].IsButtonDown(button) &&
            lastGamePadStates[(int)playerIndex].IsButtonUp(button);
        }

        public static bool ButtonDown(Buttons button, PlayerIndex playerIndex)
        {
            return gamePadStates[(int)playerIndex].IsButtonDown(button);
        }
        #endregion

        #region Touch Region
        public static bool TouchReleased()
        {
            return lastTouchState.Count() > 0 &&
                touchState.Count() == 0;
        }

        public static bool TouchPressed()
        {
            return lastTouchState.Count() == 0 &&
                touchState.Count() > 0;
        }

        public static bool Touching()
        {
            return lastTouchState.Count() > 0;
        }
        #endregion

        #region Mouse Region
        //Didn't think this would have been the heaviest section
        public static bool LeftMouseButtonReleased()
        {
            return mouseState.LeftButton == ButtonState.Released &&
                lastMouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool LeftMouseButtonPressed()
        {
            return mouseState.LeftButton == ButtonState.Pressed &&
                lastMouseState.LeftButton == ButtonState.Released;
        }

        public static bool LeftMouseButtonDown()
        {
            return mouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool MiddleMouseButtonReleased()
        {
            return mouseState.MiddleButton == ButtonState.Released &&
                lastMouseState.MiddleButton == ButtonState.Pressed;
        }

        public static bool MiddleMouseButtonPressed()
        {
            return mouseState.MiddleButton == ButtonState.Pressed &&
                lastMouseState.MiddleButton == ButtonState.Released;
        }

        public static bool MiddleMouseButtonDown()
        {
            return mouseState.MiddleButton == ButtonState.Pressed;
        }

        public static bool RightMouseButtonReleased()
        {
            return mouseState.RightButton == ButtonState.Released &&
                lastMouseState.RightButton == ButtonState.Pressed;
        }

        public static bool RightMouseButtonPressed()
        {
            return mouseState.RightButton == ButtonState.Pressed &&
                lastMouseState.RightButton == ButtonState.Released;
        }

        public static bool RightMouseButtonDown()
        {
            return mouseState.RightButton == ButtonState.Pressed;
        }

        public static void SetMouseVisible()
        {
            //add mouse image
        }
        #endregion
    }

}