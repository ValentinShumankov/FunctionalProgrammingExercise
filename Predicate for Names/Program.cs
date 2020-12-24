using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_for_Names
{
    class Program
    {
        static void Main( string [ ] args )
        {
            int minSize = int.Parse(Console.ReadLine());
            string names = Console.ReadLine();
            Console.WriteLine(SortNames(minSize,names));
        }

        public static string SortNames( int size ,string namesInput )
        {
            Func<string,bool> sizeOfName = x => x.Length <= size;

            List<string> result = namesInput.Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(sizeOfName).ToList();
            return string.Join("\n", result);
        }
    }
}
