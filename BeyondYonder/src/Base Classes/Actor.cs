using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondYonder.src.Base_Classes
{
    abstract class Actor
    {
        protected string name;
        protected string race;
        protected int size;

        protected int strengthScore = 10;
        protected int dexterityScore = 10;
        protected int constitutionScore = 10;
        protected int intellegenceScore = 10;
        protected int wisdomScore = 10;
        protected int charismaScore = 10;

        protected int strengthScoreAdj = 0;
        protected int dexterityScoreAdj = 0;
        protected int constitutionScoreAdj = 0;
        protected int intellegenceScoreAdj = 0;
        protected int wisdomScoreAdj = 0;
        protected int charismaScoreAdj = 0;

        protected int movementSpeed;
        protected int initiativeBonus = 0;
        protected bool prone;
        private Random random = new Random();

        protected Guid characterID;

        public Guid CharacterID
        {
            get { return characterID; }
        }

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

        public int DexMod
        {
            get { return (dexterityScore - 10) / 2; }
        }

        public int InitiativeBonus
        {
            get { return initiativeBonus + DexMod; }
            set { initiativeBonus = value; }
        }

        public int DieRoll(int dieType)
        {
            return random.Next(0, dieType);
        }
    }
}
