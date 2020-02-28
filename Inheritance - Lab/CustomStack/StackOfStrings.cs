namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(ICollection<string> values)
        {
            foreach (var value in values)
            {
                this.Push(value);
            }

            return this;
        }
    }
}
