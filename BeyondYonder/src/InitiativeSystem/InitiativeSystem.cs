using BeyondYonder.src.Base_Classes;
using System.Collections;
using System.Collections.Generic;

namespace BeyondYonder.src.InitiativeSystem
{
    public class InitiativeSystem
    {
        private static InitiativeSystem _instance = null;

        private List<Actor> _actors;
        public List<Actor> Actors { get { return _actors; } }

        private IEnumerator _iterator;

        public static InitiativeSystem Instance()
        {
            if (_instance == null)
            {
                _instance = new InitiativeSystem();
            }
            return _instance;
        }

        private InitiativeSystem()
        {
            _actors = new List<Actor>();
            _iterator = _actors.GetEnumerator();
        }

        public void AddActor(Actor ao)
        {
            if (_actors.Count == 0)
            {
                _actors.Add(ao);
                return;
            }

            int index = 0;
            foreach (Actor a in _actors)
            {
                if (a.TotalInitiative >= ao.TotalInitiative)
                {
                    index++;
                }
            }

            if (index == _actors.Count)
            {
                _actors.Add(ao);
            }
            else
            {
                _actors.Insert(index, ao);
            }
        }

        public void MoveActor(Actor ao, int index)
        {
            _actors.Remove(ao);
            
            if (index >= _actors.Count)
            {
                _actors.Add(ao);
            }
            else
            {
                _actors.Insert(index, ao);
            }
        }

        public bool RemoveActor(Actor ao)
        {
            return _actors.Remove(ao);
        }

        public Actor GetNextActor()
        {
            // If we are past the end of the array then we reset to the first in line.
            if (_iterator.MoveNext())
            {
                _iterator.Reset();
                _iterator.MoveNext();
            }
            return (Actor)_iterator.Current;
        }

        public void NewEncounter()
        {
            _actors = new List<Actor>();
            _iterator = _actors.GetEnumerator();
        }
    }
}
