namespace Exercise
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Mover
    {
        public static int[] MoveRight(int[] data)
        {
            var collection = new int[data.Length];

            for (int i = 0; i < collection.Length; i++)
            {
                if (data.Length > i + 1)
                {
                    collection[i] = data[i + 1];
                }
                else
                {
                    collection[i] = data[i] + 1;
                }
            }

            return collection;
        }

        public static int[] MoveLeft(int[] data)
        {
            var collection = new int[data.Length];

            for (int i = 0; i < collection.Length; i++)
            {
                if (i > 0)
                {
                    collection[i] = data[i - 1];
                }
                else
                {
                    collection[i] = data[i] - 1;
                }
            }

            return collection;
        }
    }
}
