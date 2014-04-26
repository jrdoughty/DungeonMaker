using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondYonder.src
{
    static class Die
    {

        public static int D20Roll()
        {
            Random random = new Random();
            return random.Next(0, 20);

        }

        public static int D12Roll()
        {
            Random random = new Random();
            return random.Next(0, 12);

        }

        public static int D10Roll()
        {
            Random random = new Random();
            return random.Next(0, 10);

        }

        public static int D100Roll()
        {
            Random random = new Random();
            return random.Next(0, 100);

        }

        public static int D8Roll()
        {
            Random random = new Random();
            return random.Next(0, 8);

        }

        public static int D6Roll()
        {
            Random random = new Random();
            return random.Next(0, 6);

        }

        public static int D4Roll()
        {
            Random random = new Random();
            return random.Next(0, 4);

        }
    }
}
