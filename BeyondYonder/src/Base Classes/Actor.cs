using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondYonder.src.Base_Classes
{
    public abstract class Actor
    {
        public enum SizeCat
        {
            Fine = 0,
            Diminuative = 1,
            Tiny = 2,
            Small = 3,
            Medium = 4,
            LargeTall = 5,
            LargeLong = 6,
            HugeTall = 7,
            Huge = 8,
            Gargantuan = 9,
            Gargantuan = 10,
            Gargantuan = 11,
            Gargantuan = 12
        }

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

        protected int initiativeBonus = 0;
        protected int dieRoll = 0;
        private Random random = new Random();

        protected Guid characterID;

        public Guid CharacterID
        {
            get { return characterID; }
        }

        public string Name { get; set; }
        public string Race { get; set; }
        public int Size { get; set; }
        public int MovementSpeed { get; set; }
        public bool Incapacitated { get; set; }
        public int Initiative { get; set; }

        public int DexMod
        {
            get { return (dexterityScore - 10) / 2; }
        }

        public int InitiativeBonus
        {
            get { return initiativeBonus + DexMod; }
            set { initiativeBonus = value; }
        }

        public int TotalInitiative
        {
            get { return InitiativeBonus + Initiative; }
        }

    }
}
