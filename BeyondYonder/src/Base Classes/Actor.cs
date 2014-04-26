using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondYonder.src.Base_Classes
{
    class Actor
    {
        protected string name;
        protected string race;
        protected int size;

        //protected int strengthScore;
        //protected int dexterityScore;
        //protected int constitutionScore;
        //protected int intellegenceScore;
        //protected int wisdomScore;
        //protected int charismaScore;

        //protected int strengthScoreAdj;
        //protected int dexterityScoreAdj;
        //protected int constitutionScoreAdj;
        //protected int intellegenceScoreAdj;
        //protected int wisdomScoreAdj;
        //protected int charismaScoreAdj;

        protected int movementSpeed;
        protected bool prone;
        
        public string GetName()
        {
            return name;
        }

        public string GetRace()
        {
            return race;
        }

        public int GetSize()
        {
            return size;
        }

        public int GetMovementSpeed()
        {
            return movementSpeed;
        }

        public bool IsPlayerProne()
        {
            return prone;
        }

    }
}
