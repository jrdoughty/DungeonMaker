using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BeyondYonder.src.GameComponents
{
    public abstract partial class GameState : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Fields and Properties

        private List<GameComponent> _childComponents;

        private GameState _tag;

        protected GameStateManager _stateManager;

        public List<GameComponent> Components
        {
            get { return _childComponents; }
        }

        public GameState Tag
        {
            get { return _tag; }
        }

        #endregion

        #region Constructor Region

        public GameState(Game game, GameStateManager manager)
            : base(game)
        {
            _stateManager = manager;

            _childComponents = new List<GameComponent>();
            _tag = this;
        }

        #endregion

        #region XNA Drawable Game Component Methods

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent component in _childComponents)
            {
                if (component.Enabled)
                    component.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent drawComponent;

            foreach (GameComponent component in _childComponents)
            {
                if (component is DrawableGameComponent)
                {
                    drawComponent = component as DrawableGameComponent;

                    if (drawComponent.Visible)
                        drawComponent.Draw(gameTime);
                }
            }

            base.Draw(gameTime);
        }

        #endregion

        #region GameState Method Region

        internal protected virtual void StateChange(object sender, EventArgs e)
        {
            if (_stateManager.CurrentState == Tag)
                Show();
            else
                Hide();
        }

        protected virtual void Show()
        {
            Visible = true;
            Enabled = true;
            foreach (GameComponent component in _childComponents)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = true;
            }
        }

        protected virtual void Hide()
        {
            Visible = false;
            Enabled = false;
            foreach (GameComponent component in _childComponents)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = false;
            }
        }

        #endregion
    }
}
