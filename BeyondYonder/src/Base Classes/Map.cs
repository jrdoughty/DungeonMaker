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

        public int Height { get; set; }
        public int Width { get; set; }

        public Vector2 mPosition = new Vector2(0, 0);
        public Texture2D mMapSpriteTexture;
        //public Sprite mMapSprite;

        
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
            //if(InputHandler.Touching())
            //{
            //    switch(InputHandler.CurrentGesture.GestureType)
            //    {
            //        //case GestureType.Tap:// pulled from https://github.com/CartBlanche/MonoGame-Samples/blob/master/TouchGesture/Game1.cs
            //        //case GestureType.DoubleTap:
            //        //    if (selectedSprite != null)
            //        //    {
            //        //        selectedSprite.ChangeColor();
            //        //    }
            //        //    break;

            //        //// on holds, if no sprite is selected, we add a new sprite at the
            //        //// hold position and make it our selected sprite. otherwise we
            //        //// remove our selected sprite.
            //        //case GestureType.Hold:
            //        //    if (selectedSprite == null)
            //        //    {
            //        //        // create the new sprite
            //        //        selectedSprite = new Sprite(cat);
            //        //        selectedSprite.Center = gesture.Position;

            //        //        // add it to our list
            //        //        sprites.Add(selectedSprite);
            //        //    }
            //        //    else
            //        //    {
            //        //        sprites.Remove(selectedSprite);
            //        //        selectedSprite = null;
            //        //    }
            //        //    break;

            //        //// on drags, we just want to move the selected sprite with the drag
            //        //case GestureType.FreeDrag:
            //        //    if (selectedSprite != null)
            //        //    {
            //        //        selectedSprite.Center += gesture.Delta;
            //        //    }
            //        //    break;

            //        //// on flicks, we want to update the selected sprite's velocity with
            //        //// the flick velocity, which is in pixels per second.
            //        //case GestureType.Flick:
            //        //    if (selectedSprite != null)
            //        //    {
            //        //        selectedSprite.Velocity = gesture.Delta;
            //        //    }
            //        //    break;

            //        // on pinches, we want to scale the selected sprite
            //        case GestureType.Pinch:
            //            if (mapSprite != null)
            //            {
            //                // get the current and previous locations of the two fingers
            //                Vector2 a = InputHandler.CurrentGesture.Position;
            //                Vector2 aOld = InputHandler.CurrentGesture.Position - InputHandler.CurrentGesture.Delta;
            //                Vector2 b = InputHandler.CurrentGesture.Position2;
            //                Vector2 bOld = InputHandler.CurrentGesture.Position2 - InputHandler.CurrentGesture.Delta2;

            //                // figure out the distance between the current and previous locations
            //                float d = Vector2.Distance(a, b);
            //                float dOld = Vector2.Distance(aOld, bOld);

            //                // calculate the difference between the two and use that to alter the scale
            //                float scaleChange = (d - dOld) * .01f;
            //                mMapSpriteTexture.Scale += scaleChange;
            //            }
            //            break;
            //    }
            //}
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            
            if (mMapSpriteTexture != null)
            {
                base.Draw(gameTime);
                _gameRef.SpriteBatch.Draw(mMapSpriteTexture, new Rectangle((int)mPosition.X, (int)mPosition.Y, Height, Width), Color.White);
            }
        }

        protected override void LoadContent()
        {
            string path = @"C:\\Users\\John\\Pictures\\Burial7.jpg";
            ContentManager Content = _gameRef.Content;
            mMapSpriteTexture = Content.Load<Texture2D>(@"Burial7.jpg");
            Height = mMapSpriteTexture.Height;
            Width = mMapSpriteTexture.Width;
            //mMapSpriteTexture = Game.Content.Load<Texture2D>(@"Burial7.png");
            base.LoadContent();
        }

    }
}
