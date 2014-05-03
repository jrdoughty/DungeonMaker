using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using BeyondYonder.src.GameComponents;


namespace BeyondYonder.src.Base_Classes
{
    public class Map : DrawableGameComponent
    {

        protected Game1 _gameRef;

        public float Height { get; set; }
        public float Width { get; set; }

        public bool bLockTheTexture = false;

        public Vector2 mPosition = new Vector2(0, 0);
        public Texture2D mMapSpriteTexture;

        
        public Map(Game game) : base(game)
        {
            _gameRef = (Game1)game;
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            #region Touch
            if (InputHandler.Touching())
            {
                switch (InputHandler.CurrentGesture.GestureType)
                {
                    //case GestureType.Tap:// pulled from https://github.com/CartBlanche/MonoGame-Samples/blob/master/TouchGesture/Game1.cs
                    case GestureType.DoubleTap:
                        bLockTheTexture = true;
                        break;

                    case GestureType.Hold:
                        
                        break;

                    //// on drags, we just want to move the selected map with the drag
                    case GestureType.FreeDrag:
                        if (InputHandler.LastGesture.GestureType == GestureType.FreeDrag && 
                            Math.Abs(InputHandler.CurrentGesture.Position.X - InputHandler.LastGesture.Position.X) < 50 && 
                            Math.Abs(InputHandler.CurrentGesture.Position.Y - InputHandler.LastGesture.Position.Y) < 50 && 
                            InputHandler.LastGesture.Position.X > 0 && 
                            InputHandler.LastGesture.Position.Y > 0 && !bLockTheTexture)
                        {
                            mPosition.X += InputHandler.CurrentGesture.Position.X - InputHandler.LastGesture.Position.X;
                            mPosition.Y += InputHandler.CurrentGesture.Position.Y - InputHandler.LastGesture.Position.Y;
                        }
                        break;
                    //case GestureType.Flick:
                    //    if (selectedSprite != null)
                    //    {
                    //        selectedSprite.Velocity = gesture.Delta;
                    //    }
                    //    break;

                    // on pinches, we want to scale the map
                    case GestureType.Pinch:
                        if (mMapSpriteTexture != null && !bLockTheTexture)
                        {
                            // get the current and previous locations of the two fingers
                            Vector2 a = InputHandler.CurrentGesture.Position;
                            Vector2 aOld = InputHandler.CurrentGesture.Position - InputHandler.CurrentGesture.Delta;
                            Vector2 b = InputHandler.CurrentGesture.Position2;
                            Vector2 bOld = InputHandler.CurrentGesture.Position2 - InputHandler.CurrentGesture.Delta2;

                           

                            // figure out the distance between the current and previous locations
                            float d = Vector2.Distance(a, b);
                            float dOld = Vector2.Distance(aOld, bOld);

                            // calculate the difference between the two and use that to alter the scale
                            float scaleChange = ((d - dOld) * .01f );
                            Height *= 1 + scaleChange;
                            Width *= 1 + scaleChange;
                        }
                        break;
                }
            }
            #endregion
            #region Mouse
            if (InputHandler.CurrentMouseState.LeftButton == ButtonState.Pressed && InputHandler.CurrentMouseState.RightButton == ButtonState.Pressed)
            {
                bLockTheTexture = true;
            }
            else if (InputHandler.CurrentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (InputHandler.LastMouseState.LeftButton == ButtonState.Pressed)
                {
                    if (
                            Math.Abs(InputHandler.CurrentMouseState.X - InputHandler.LastMouseState.X) < 50 &&
                            Math.Abs(InputHandler.CurrentMouseState.Y - InputHandler.LastMouseState.Y) < 50 &&
                            InputHandler.LastMouseState.X > 0 &&
                            InputHandler.LastMouseState.Y > 0 && 
                            !bLockTheTexture)
                    {
                        mPosition.X += InputHandler.CurrentMouseState.X - InputHandler.LastMouseState.X;
                        mPosition.Y += InputHandler.CurrentMouseState.Y - InputHandler.LastMouseState.Y;
                    }
                }
            }
            else if (InputHandler.CurrentMouseState.RightButton == ButtonState.Pressed)
            {
                if (InputHandler.LastMouseState.RightButton == ButtonState.Pressed)
                {
                    if (
                            Math.Abs(InputHandler.CurrentMouseState.X - InputHandler.LastMouseState.X) < 50 &&
                            Math.Abs(InputHandler.CurrentMouseState.Y - InputHandler.LastMouseState.Y) < 50 &&
                            InputHandler.LastMouseState.X > 0 &&
                            InputHandler.LastMouseState.Y > 0 && 
                            !bLockTheTexture)
                    {

                        // calculate the difference between the two and use that to alter the scale
                        float scaleChange = ((InputHandler.CurrentMouseState.X - InputHandler.LastMouseState.X + 
                            InputHandler.CurrentMouseState.Y - InputHandler.LastMouseState.Y) * .01f);
                        Height *= 1 + scaleChange;
                        Width *= 1 + scaleChange;
                    }
                }
            }
            #endregion
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            if (mMapSpriteTexture != null)
            {
                _gameRef.SpriteBatch.Draw(mMapSpriteTexture, new Rectangle((int)mPosition.X, (int)mPosition.Y, (int)Width, (int)Height), Color.White);
            }
            base.Draw(gameTime);
        }

        public string GetWidth()
        {
            return Width.ToString();
        }
        public string GetHeight()
        {
            return Height.ToString();
        }

        protected override void LoadContent()
        {
            //string path = @"C:\\Users\\John\\Pictures\\Burial7.jpg";//Need system to load local files
            ContentManager Content = _gameRef.Content;
            mMapSpriteTexture = Content.Load<Texture2D>(@"floor.jpg");
            Height = mMapSpriteTexture.Height;
            Width = mMapSpriteTexture.Width;
            //mMapSpriteTexture = Game.Content.Load<Texture2D>(@"Burial7.png");
            base.LoadContent();
        }

    }
}
