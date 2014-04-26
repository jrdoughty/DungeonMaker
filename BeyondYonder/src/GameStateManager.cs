using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using BeyondYonder.src.GameComponents;

namespace BeyondYonder.src
{
    public class GameStateManager : GameComponent
    {
        #region Event Region

        public event EventHandler OnStateChange;

        #endregion

        #region Fields and Properties Region
        
        Stack<GameState> _gameStates = new Stack<GameState>();

        private const int _startDrawOrder = 5000;
        private const int _drawOrderInc = 100;
        private int _drawOrder;

        public GameState CurrentState
        {
            get { return _gameStates.Peek(); }
        }

        #endregion

        #region Constructor Region

        public GameStateManager(Game game)
            : base(game)
        {
            _drawOrder = _startDrawOrder;
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        #endregion

        #region Methods Region

        public void PopState()
        {
            if (_gameStates.Count > 0)
            {
                RemoveState();
                _drawOrder -= _drawOrderInc;

                if (OnStateChange != null)
                    OnStateChange(this, null);
            }
        }

        private void RemoveState()
        {
            GameState State = _gameStates.Peek();

            OnStateChange -= State.StateChange;
            Game.Components.Remove(State);
            _gameStates.Pop();
        }

        public void PushState(GameState newState)
        {
            _drawOrder += _drawOrderInc;
            newState.DrawOrder = _drawOrder;

            AddState(newState);

            if (OnStateChange != null)
                OnStateChange(this, null);
        }

        private void AddState(GameState newState)
        {
            _gameStates.Push(newState);

            Game.Components.Add(newState);

            OnStateChange += newState.StateChange;
        }

        public void ChangeState(GameState newState)
        {
            while (_gameStates.Count > 0)
                RemoveState();

            newState.DrawOrder = _startDrawOrder;
            _drawOrder = _startDrawOrder;

            AddState(newState);

            if (OnStateChange != null)
                OnStateChange(this, null);
        }

        #endregion
    }
}
    
    