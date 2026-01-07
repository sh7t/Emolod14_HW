using System;

namespace EM_HW14.Source.Utils
{
    public static class ValidationHelper
    {
        // funcs
        public static bool IsPositive(int value) { return value > 0; }
        public static bool IsPositive(double value) { return value > 0; }

        public static bool IsNegative(int value) { return value < 0; }
        public static bool IsNegative(double value) { return value < 0; }

        public static bool IsNonPositive(int value) { return value <= 0; }
        public static bool IsNonPositive(double value) { return value <= 0; }

        public static bool IsNonNegative(int value) { return value >= 0; }
        public static bool IsNonNegative(double value) { return value >= 0; }

        public static void CheckForNull<T>(T value)
        {
            if (value == null) { throw new NullReferenceException("Null can't be a value here."); }
        }
    }
}
