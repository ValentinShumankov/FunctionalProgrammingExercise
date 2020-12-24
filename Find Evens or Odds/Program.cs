using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main( string [ ] args )
        {
            Func<int,int,List<int>> generateArray = (int one,int two) =>
            {
                List<int> array = new List<int>();
                for (int i = one ; i <= two; i++)
                {
                    array.Add(i);
                }
                return array;
            };

            var splitString = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string condition = Console.ReadLine();
            int startIndex = int.Parse(splitString[0]);
            int endIndex = int.Parse(splitString[1]);
            List<int> nums = generateArray(startIndex,endIndex);

            switch (condition)
            {
                case "odd": 
                   Console.WriteLine(string.Join(" ",nums.Where(x => x % 2 != 0)));
                    break;
                case "even":
                    Console.WriteLine(string.Join(" ", nums.Where(x => x % 2 == 0)));
                    break;
            }
        }
    }
}
