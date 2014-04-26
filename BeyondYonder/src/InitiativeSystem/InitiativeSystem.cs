using BeyondYonder.src.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondYonder.src.InitiativeSystem
{
    public class InitiativeSystem
    {
        private static InitiativeSystem _instance = null;

        private List<Actor> _actors;
        public List<Actor> Actors { get; }

        public static InitiativeSystem Instance()
        {
            if (_instance == null)
            {
                _instance = new InitiativeSystem();
            }
            return _instance;
        }

        private InitiativeSystem() { _actors = new List<Actor>(); }

        public void AddActor(Actor ao)
        {
            if (Actors.Count == 0)
            {
                Actors.Add(ao);
                return;
            }

            int index = 0;
            foreach (Actor a in Actors)
            {
                if (a.Initiative >= ao.Initiative)
                {
                    index++;
                }
            }

            if (index == Actors.Count)
            {
                Actors.Add(ao);
            }
            else
            {
                Actors.Insert(index, ao);
            }
        }

        public void MoveActor(Actor ao, int index)
        {
            Actors.Remove(ao);
            
            if (index >= Actors.Count)
            {
                Actors.Add(ao);
            }
            else
            {
                Actors.Insert(index, ao);
            }
        }
    }
}
