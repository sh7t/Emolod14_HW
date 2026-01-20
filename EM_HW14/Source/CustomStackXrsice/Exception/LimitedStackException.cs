using System;

namespace EM_HW14.Source.CustomStackXrsice
{
    public class LimitedStackException : Exception
    {
        public LimitedStackException(string message) : base(message) { }
    }
}
