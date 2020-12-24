using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main( string [ ] args )
        {
            Console.WriteLine(string.Join(" ", CustomSort(Console.ReadLine())));
        }

        static int[] CustomSort(string input )
        {
            Func<int, bool> ifEven = x => x % 2 == 0;
            var array = input.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> evenList = new List<int>();
            List<int> oddList = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (ifEven(array[i]))
                {
                    evenList.Add(array [ i ]);
                }
                else
                {
                    oddList.Add(array [ i ]);
                }
            }
            List<int> result = new List<int>();
            result.AddRange(evenList.OrderBy(x => x).Concat(oddList.OrderBy(x => x)));
            return result.ToArray( );
        }
    }
}
