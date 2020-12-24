using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main( string [ ] args )
        {
            Func<string,int> minNumber = MinNum;
            Console.WriteLine(MinNum(Console.ReadLine( )));
        }

        static int MinNum( string nums )
        {
            var input = nums.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return input.Min( );
        }
    }
}
