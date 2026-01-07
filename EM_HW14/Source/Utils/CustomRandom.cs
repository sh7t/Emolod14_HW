using System;

namespace EM_HW14.Source.Utils
{
    public static class CustomRandom
    {
        // fields
        private static Random random = new Random();

        // funcs
        public static int Next(int min, int max)
        {
            return random.Next(min, max);
        }
        public static int Next(int max)
        {
            return random.Next(max);
        }
    }
}
