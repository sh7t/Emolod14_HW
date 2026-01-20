using EM_HW14.Source.Utils;
using System.Collections.Generic;

namespace EM_HW14.Source.CustomStackXrsice.Base
{
    public class LimitedStack<T>
    {
        // fields
        private List<T> stack;
        private readonly int _stackCapacity;

        // init
        public LimitedStack(int stackCapacity)
        {
            if (ValidationHelper.IsNonPositive(stackCapacity)) { throw new LimitedStackException("Limited stack's capacity must be greater than zero."); }
            _stackCapacity = stackCapacity;
            stack = new List<T>(_stackCapacity);
        }

        // getset / properties
        public int StackCapacity => _stackCapacity;
        public int Count => stack.Count;
        public bool IsFull => Count == StackCapacity;
        public bool IsEmpty => Count == 0;


        // funcs
        private string GetElementRatio()
        {
            return $"{Count}/{StackCapacity}";
        }
        public void Push(T item)
        {
            if (IsFull) { throw new LimitedStackException($"Not enough space for pushing a new element to limited stack ({GetElementRatio()})."); }
            stack.Add(item);
        }
        public T Pop()
        {
            if (IsEmpty) { throw new LimitedStackException($"Nothing to pop from limited stack ({GetElementRatio()})."); }

            T returnable = Peek();
            stack.RemoveAt(Count - 1);

            return returnable;
        }
        public T Peek() // чому не peak?
        {
            if (IsEmpty) { throw new LimitedStackException($"No available peak value from limited stack ({GetElementRatio()})."); }
            return stack[Count - 1];
        }
        public void Clear() { stack.Clear(); }
        public T[] ToArray() { return stack.ToArray(); }

    }
}
