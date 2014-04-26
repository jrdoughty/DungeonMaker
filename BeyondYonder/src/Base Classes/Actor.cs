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
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Race
        {

            get { return race; }
            set { race = value; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public int MovementSpeed
        {
            get { return movementSpeed; }
            set { movementSpeed = value; }
        }

        public bool Prone
        {
            get { return prone; }
            set { prone = value; }
        }

    }
}
