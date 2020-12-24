using System;
using System.Collections.Generic;
using System.Linq;


namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main( string [ ] args )
        {
            Func<List<int>,List<int>> reverseNums = x =>
            {
                return x.ToArray().Reverse().ToList();
            };
            Func<string,List<int>> toListInt = x =>
            {
                return  x.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            };
            Func<List<int>,string> printNUms = x => string.Join(" ",x);
            string nums = Console.ReadLine();
            int excludeNum = int.Parse(Console.ReadLine());

            ReverseAndExlude(nums, excludeNum ,reverseNums,toListInt,printNUms);
        }


        public static void ReverseAndExlude( string stringNums, int excludeNum,
           Func<List<int>, List<int>> reverseNums,
           Func<string, List<int>> toListInt ,
           Func<List<int>, string> printNUms )
        {
            List<int> listNums = toListInt(stringNums);
            listNums = reverseNums(listNums);
            listNums = listNums.ToArray( ).Where(x => x % excludeNum != 0).ToList( );
            Console.WriteLine(printNUms(listNums));
        }
    }
}
