using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondYonder.src
{
    static class Die
    {
        public enum DieType
        {
            D4 = 4,
            D6 = 6,
            D8 = 8,
            D12 = 12,
            D20 = 20,
        }

        public static int DieRoll(DieType dieType)
        {
            Random random = new Random();
            return random.Next(0, (int)dieType);

        }
    }
}
