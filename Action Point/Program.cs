using System;

namespace Action_Point
{
    class Program
    {
        static void Main( string [ ] args )
        {
            string[] names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> printNames = x => Console.WriteLine(string.Join("\n",x));
            printNames(names);
        }
    }
}
